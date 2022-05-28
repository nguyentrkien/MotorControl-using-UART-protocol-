#include <stdbool.h>
#include <stdint.h>
#include <string.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include "main.h"
extern void MotoSetDir(int8_t nDir);
extern void MotorSetDuty(uint16_t nDuty);
extern void	MotorInit(void);
extern uint16_t ConvertDegToPulse(uint16_t nDeg);
extern uint16_t ConverPulseToDeg(uint16_t nDeg);
extern void MotorGetPulse(uint32_t *nPulse);
extern void MotorMovePos(uint16_t nPos);
extern void MotorTuning(uint16_t nPos);

