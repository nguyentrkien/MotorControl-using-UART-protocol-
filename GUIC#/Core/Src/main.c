/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2022 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"
#include "tim.h"
#include "usart.h"
#include "gpio.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include <stdbool.h>
#include <stdint.h>
#include <string.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>

#include "pid.h"
#include "motor.h"
#include "serial.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */
/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/

/* USER CODE BEGIN PV */

/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
/* USER CODE BEGIN PFP */

/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */
extern PID_CONTROL_t tPIDControl;
extern PROCESS_t tProcess;
extern PROFILE_t tProfile;

extern bool g_bDataAvailable;
extern uint8_t nTxBuff[MAX_LEN];
extern uint8_t g_strCommand[4];
extern uint8_t g_nOption[3];
extern uint8_t g_nData[8];

extern uint32_t g_nActPulse;
extern uint32_t g_nCmdPulse;
extern uint16_t g_nIndex;
extern float g_dPIDError;

uint8_t g_strTxCommand[4];
uint8_t g_nTxOption[3];
uint8_t g_nTxData[8];
uint16_t g_nTuningSampleCount = 0;
uint8_t g_nTxData2[2];
int b = 0;
long last = 0;
int T = 10;
float Output = 0;
float real_speed = 0;
float desire_speed = 0;
int idx = 0;
int rotation = 0;
/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
	{
  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_TIM2_Init();
  MX_TIM3_Init();
  MX_TIM4_Init();
  MX_USART2_UART_Init();
  /* USER CODE BEGIN 2 */
	SerialInit();
	MotorInit();
	tProcess = NONE;
	HAL_TIM_Encoder_Start(&htim4, TIM_CHANNEL_1 | TIM_CHANNEL_2);
	HAL_TIM_PWM_Start(&htim3, TIM_CHANNEL_1 | TIM_CHANNEL_2);
	last = HAL_GetTick();
	__HAL_TIM_SET_COUNTER(&htim4, 0);	
  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
  while (1)
  {
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
		
		if (g_bDataAvailable == true)
		{
			if (StrCompare(g_strCommand, (uint8_t *)"SPID", 4))
			{
				tProcess = SPID;
			}
			else if (StrCompare(g_strCommand, (uint8_t *)"CTUN", 4))
			{
				tProcess = CTUN_RES;
			}
			else if (StrCompare(g_strCommand, (uint8_t *)"GPID", 4))
			{
				tProcess = GPID;
			}
			else if (StrCompare(g_strCommand, (uint8_t *)"CSET", 4))
			{
				tProcess = CSET;
			}
			else if (StrCompare(g_strCommand, (uint8_t *)"CRUN", 4))
			{
				tProcess = CRUN_RES;
			}
			else if (StrCompare(g_strCommand, (uint8_t *)"GRMS", 4))
			{
				tProcess = GRMS;
			}
			else if (StrCompare(g_strCommand, (uint8_t *)"STOP", 4))
			{
				tProcess = STOP;
			}
			else if (StrCompare(g_strCommand, (uint8_t *)"ROTN", 4))
			{
				tProcess = ROTN;
			}
			else 
			{
				tProcess = NONE;
			}
			g_bDataAvailable = false;
			}
		switch(tProcess)
		{
			case NONE:
				SerialAcceptReceive();
				break;
			case SPID:
				g_nCmdPulse = 0;
				g_nActPulse = 0;
				MotorInit();
				PIDReset(&tPIDControl);
				__HAL_TIM_SetCounter(&htim4, 32768);
				g_nIndex = 0;
			
				tPIDControl.dKp = (float)g_nData[0] + (float)g_nData[1]/10;
				tPIDControl.dKi = (float)g_nData[2] + (float)g_nData[3]/(pow((float)10, (float)g_nData[4]));
				tPIDControl.dKd = (float)g_nData[5] + (float)g_nData[6]/(pow((float)10, (float)g_nData[7]));
			
				tProcess = NONE;
				break;
			case CTUN_RES:
				tProcess = CTUN;
				break;
			case CTUN:
				break;
			case GPID:
				__HAL_TIM_SetCounter(&htim4, 32768);
				idx = 0;
				g_nActPulse = 0;
				g_nCmdPulse = 0;
				PIDReset(&tPIDControl);
				g_nIndex = 0;
				desire_speed = (float)((g_nData[6] >> 4) * 4096) + (float)((g_nData[6] & 0x0F)*256)
					+(float)((g_nData[7]>>4)*16) + (float)((g_nData[7] & 0x0F)*1);	
				tProcess = GRMS;
				break;
			case CSET:
				g_nActPulse = 0;
				g_nCmdPulse = 0;
				PIDReset(&tPIDControl);
				g_nIndex = 0;
				tProfile.dPosMax = (float)((g_nData[6] >> 4) * 4096) + (float)((g_nData[6] & 0x0F)*256)+(float)
					((g_nData[7]>>4)*16) + (float)((g_nData[7] & 0x0F)*1);				
				tProcess = NONE;
				break;
			case CRUN_RES:
				g_nCmdPulse = 0;
				g_nActPulse = 0;
				PIDReset(&tPIDControl);
				__HAL_TIM_SetCounter(&htim4, 32768);
				g_nIndex = 0;
				tProcess = CRUN;
			case CRUN:
				break;
			case GRMS:			
				if (HAL_GetTick() - last >= T )
				{				
					last = HAL_GetTick();
					b = __HAL_TIM_GET_COUNTER(&htim4);
					__HAL_TIM_SET_COUNTER(&htim4, 32768);	
					real_speed = round(((float)abs(b-32768)*60*100/8700)*100)/100; 					
					Output = PIDSpeed(&tPIDControl, Output, desire_speed, real_speed);
					if (rotation == 1)
					{
					htim3.Instance->CCR2 = Output;
					}
					else 
					{
						htim3.Instance->CCR1 = Output;
					}
					tPIDControl.nActPosSample[idx] = 100*real_speed;
					if (idx < 601)
					{
						g_nTxData2[1] = (tPIDControl.nActPosSample[idx]&0xFF00)>>8;
						g_nTxData2[0] = (tPIDControl.nActPosSample[idx]&0xFF);
						HAL_UART_Transmit(&huart2,g_nTxData2, 2, 10);
						idx++;
					}
					
				}
			tProcess = GRMS;
			SerialAcceptReceive();
			break;
			case STOP:
				__HAL_TIM_SET_COMPARE(&htim3, TIM_CHANNEL_1, 0);	
				__HAL_TIM_SET_COMPARE(&htim3, TIM_CHANNEL_2, 0);
				tProcess = NONE;
			case ROTN:
				if (g_nData[0] == 1)
				{
					rotation = 1;
				}
				else 
				{
					rotation = 0;
				}
				tProcess = NONE;
			}
		}
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Configure the main internal regulator output voltage
  */
  __HAL_RCC_PWR_CLK_ENABLE();
  __HAL_PWR_VOLTAGESCALING_CONFIG(PWR_REGULATOR_VOLTAGE_SCALE1);
  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSE;
  RCC_OscInitStruct.HSEState = RCC_HSE_ON;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSE;
  RCC_OscInitStruct.PLL.PLLM = 8;
  RCC_OscInitStruct.PLL.PLLN = 336;
  RCC_OscInitStruct.PLL.PLLP = RCC_PLLP_DIV2;
  RCC_OscInitStruct.PLL.PLLQ = 4;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }
  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV4;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV2;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_5) != HAL_OK)
  {
    Error_Handler();
  }
}

/* USER CODE BEGIN 4 */
void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim)
{
	if (htim->Instance == htim2.Instance)
	{
		switch (tProcess)
		{
			case NONE:
				break;
			case SPID:
				break;
			case CTUN_RES:
				break;
			case CTUN:
				if (g_nIndex <= 599)
				{
				MotorTuning(90);
				}
				else 
				{
					__HAL_TIM_SET_COMPARE(&htim3, TIM_CHANNEL_1, 0);	
					__HAL_TIM_SET_COMPARE(&htim3, TIM_CHANNEL_2, 0);
					tProcess = NONE;
				}
				break;
			case GPID:
				break;
			case CSET:
				break;
			case CRUN:
				MotorMovePos(tProfile.dPosMax);
				break;
			case GRMS:
				break;
		}
	}
}
/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */

