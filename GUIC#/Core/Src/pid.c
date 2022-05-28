#include "pid.h"
#include "tim.h"


float g_dPIDError = 0;
float error = 0;
float last_error = 0;

void PIDReset(PID_CONTROL_t *PID_Ctrl)
{
	PID_Ctrl->dIntergral = 0.0f;
	PID_Ctrl->dErrorTerm = 0.0f;
	g_dPIDError = 0;

}
void PIDInit(PID_CONTROL_t *PID_Ctrl, float dKp, float dKi, float dKd)
{
	PIDReset(PID_Ctrl);
	PID_Ctrl->dKp = dKp;
	PID_Ctrl->dKi = dKi;
	PID_Ctrl->dKd = dKd;
	__HAL_TIM_SetCounter(&htim4, 32768);
}
void PIDTuningSet(PID_CONTROL_t *PID_Ctrl, float dKp, float dKi, float dKd)
{
	if (dKp<0.0f || dKi < 0.0f || dKp < 0.0f)
	{
		return;
	}
	
	PID_Ctrl->dKp = dKp;
	PID_Ctrl->dKi = dKi;
	PID_Ctrl->dKd = dKd;
}

float PIDCompute(PID_CONTROL_t *PID_Ctrl, float dCmdValue, float dActValue, float dTs)
{
	float dPIDResult;
	g_dPIDError = dCmdValue - dActValue;
	float a = 0, b =  0, y = 0;
	
	a = 2*dTs*(PID_Ctrl->dKp) + (PID_Ctrl->dKi)*dTs*dTs + 2*PID_Ctrl->dKd;
	b = (PID_Ctrl->dKi)*dTs*dTs - 4*PID_Ctrl->dKd - 2*dTs*PID_Ctrl->dKp;
	y = 2*PID_Ctrl->dKd;
	dPIDResult = (a*g_dPIDError + b*PID_Ctrl->dErrorTerm + y*PID_Ctrl->pre_dErrorTerm + 2*dTs*PID_Ctrl->pre_out)/(2*dTs);
	PID_Ctrl->pre_out = dPIDResult;
  PID_Ctrl->pre_dErrorTerm = PID_Ctrl->dErrorTerm;
	PID_Ctrl->dErrorTerm = g_dPIDError;
	 
	return dPIDResult;
}
int PIDSpeed(PID_CONTROL_t *PID_Ctrl, float Output, float desire_speed,float real_speed)
{
	float outpid = 0;
	error = desire_speed - real_speed;
	PID_Ctrl->dIntergral += error; 
	outpid = (PID_Ctrl->dKp*error) + PID_Ctrl->dKi * 0.005 * PID_Ctrl->dIntergral+ (PID_Ctrl->dKd*(error - last_error)/0.01);
	last_error = error;
	if (Output + outpid >= 999)
	{
		Output = 999;
	}
	else 
	{
		Output = Output + outpid;
	}
	return Output;
}

