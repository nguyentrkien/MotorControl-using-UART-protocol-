#define MAX_LEN 18
#include "main.h"
#include <stdbool.h>
#include <stdint.h>
#include <string.h>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>



extern void SerialInit(void);
extern uint8_t *subString(uint8_t *pBuff, int nPos, int nIndex);
extern bool StrCompare(uint8_t *pBuff, uint8_t *pSample, uint8_t nSize);
extern void SerialWriteComm(uint8_t *pStrCmd, uint8_t *pOpt, uint8_t *pData);
extern void SerialParse(uint8_t *pBuff);
extern void SerialAcceptReceive(void);
