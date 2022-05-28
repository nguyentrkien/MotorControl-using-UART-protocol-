#include "motor.h"
#include <stdbool.h>
#include <stdint.h>
#include <string.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include "tim.h"
#include "pid.h"
#include "usart.h"

PROCESS_t tProcess;
PID_CONTROL_t tPIDControl;
PROFILE_t tProfile;

int32_t g_nDutyCycle;
float g_dCmdVel;
uint32_t g_nActPulse;
uint32_t g_nCmdPulse;
uint16_t g_nIndex = 0;
uint8_t g_nTxData1[2];

void MotorSetDir(int8_t nDir) //bo?
{
	switch (nDir)
	{
		case 0:
			HAL_GPIO_WritePin(GPIOB, GPIO_PIN_11, GPIO_PIN_RESET);
			break;
		case 1:
			HAL_GPIO_WritePin(GPIOB, GPIO_PIN_11, GPIO_PIN_SET);
			break;
		default:
			break;
	}
}

void MotorSetDuty( uint16_t nDuty)
{
	HAL_TIM_PWM_Start_IT(&htim3, TIM_CHANNEL_1);
	__HAL_TIM_SET_COMPARE(&htim3, TIM_CHANNEL_1, nDuty);
}
void MotorSetDutyCW( uint16_t nDuty)
{
	HAL_TIM_PWM_Start_IT(&htim3, TIM_CHANNEL_2);
	__HAL_TIM_SET_COMPARE(&htim3, TIM_CHANNEL_2, nDuty);
}

void MotorInit(void)
{
	HAL_TIM_Base_Start_IT(&htim2);
	HAL_TIM_PWM_Start(&htim3, TIM_CHANNEL_1);
	HAL_TIM_PWM_Start(&htim3, TIM_CHANNEL_2);
	HAL_TIM_Encoder_Start(&htim4, TIM_CHANNEL_1);
	HAL_TIM_Encoder_Start(&htim4, TIM_CHANNEL_2);
	
	PIDReset(&tPIDControl);
	PIDInit(&tPIDControl, 1., 0., 0.00);
	MotorSetDir(1);
}

uint16_t ConvertDegToPulse(uint16_t nDeg)
{
	float dPulse = nDeg*8700/360;
	
	return (uint16_t)dPulse;
}

uint16_t ConvertPulseToDeg(uint16_t nPulse)
{
	float dDeg = nPulse * 360/8700;
	return (uint16_t)dDeg;
}

void MotorGetPulse(uint32_t *nPulse)
{
	*nPulse = __HAL_TIM_GET_COUNTER(&htim4);
}

void MotorTuning(uint16_t nPos)
{
	uint32_t nPulse;
	MotorGetPulse(&nPulse);
	g_nActPulse = nPulse - 32768;
	
	g_nCmdPulse = ConvertDegToPulse(nPos);
	g_nDutyCycle = (int32_t) PIDCompute(&tPIDControl, g_nCmdPulse, g_nActPulse, 0.01f);
	if (g_nDutyCycle >= 0)
	{
		MotorSetDuty(abs(g_nDutyCycle));
	}
	else if (g_nDutyCycle < 0)
	{
		MotorSetDutyCW(abs(g_nDutyCycle));
	}
	
	
	tPIDControl.nSampleTuningPID[g_nIndex] = g_nActPulse;
	
	g_nTxData1[1] = (tPIDControl.nSampleTuningPID[g_nIndex]&0xFF00)>>8;
	g_nTxData1[0] = (tPIDControl.nSampleTuningPID[g_nIndex]&0xFF);

	HAL_UART_Transmit(&huart2,g_nTxData1, 2, 10);
	g_nIndex++;
}

void MotorMovePos(uint16_t nPos)
{
	uint32_t nPulse;
	MotorGetPulse(&nPulse);
	g_nActPulse = nPulse - 32768;
	
	g_nCmdPulse = ConvertDegToPulse(nPos);
	g_nDutyCycle = (int32_t) PIDCompute(&tPIDControl, g_nCmdPulse, g_nActPulse, 0.01f);
	if (g_nDutyCycle >= 0)
	{
		MotorSetDuty(abs(g_nDutyCycle));
	}
	else if (g_nDutyCycle < 0)
	{
		MotorSetDutyCW(abs(g_nDutyCycle));
	}
	if (tProfile.nTime > 6.01)
	{
		__HAL_TIM_SetCounter(&htim4, 32768);
		g_nDutyCycle = 0;
		tProfile.nTime = 0;
		tProcess = NONE;
		__HAL_TIM_SET_COMPARE(&htim3, TIM_CHANNEL_1, 0);	
		__HAL_TIM_SET_COMPARE(&htim3, TIM_CHANNEL_2, 0);	
	}
	else
	{
		tPIDControl.nActPosSample[g_nIndex] = ConvertPulseToDeg(g_nActPulse);
		g_nTxData1[1] = (tPIDControl.nActPosSample[g_nIndex]&0xFF00)>>8;
		g_nTxData1[0] = (tPIDControl.nActPosSample[g_nIndex]&0xFF);
		HAL_UART_Transmit(&huart2,g_nTxData1, 2, 10);
		g_nIndex++;
	}
	tProfile.nTime += 0.01;
}
