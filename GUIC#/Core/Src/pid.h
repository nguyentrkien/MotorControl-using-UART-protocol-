#include <stdbool.h>
#include <stdint.h>
#include <string.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include "main.h"

typedef struct {
	float dKp, dKi, dKd;
	float dErrorTerm,pre_dErrorTerm,pre_out;
	float dIntergral;
	uint16_t nSampleTuningPID[1000];
	uint16_t nActPosSample[1000];
}PID_CONTROL_t;

typedef struct {
	float dAcce1Max;
	float dVe1Max;
	float dPosMax;
	float dA1;
	float dA2, dB2;
	float dA3, dB3, dC3;
	float dMidStep1;
	float dMidStep2;
	float dMidStep3;
	float nTime;
}PROFILE_t;


typedef enum {
	NONE = 1,
	SPID,
	CTUN,
	CTUN_RES,
	GPID,
	CSET,
	CRUN,
	CRUN_RES,
	GRMS,
	STOP,
	ROTN
}PROCESS_t;


extern void PIDReset(PID_CONTROL_t *PID_Ctrl);
extern void PIDInit(PID_CONTROL_t *PID_Ctrl, float dKp, float dKi, float dKd);
extern void	PIDTuningSet(PID_CONTROL_t *PID_Ctrl, float dKp, float dKi, float dKd);
extern float PIDCompute(PID_CONTROL_t *PID_Ctrl, float dCmdValue, float dActValue, float dTs);
extern int PIDSpeed(PID_CONTROL_t *PID_Ctrl, float Output,float desire_speed,float real_speed);
