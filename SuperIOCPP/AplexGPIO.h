#pragma once

#include "windows.h"
#include "stdio.h"

short hexStrToNum(char str[]);
UINT initInpOut32Lib();
void closeInpOut32Lib();
short readByte(short iPort);
void writeByte(short iPort, short iData);
void initGPIO();
void freeGPIO();
void setPinsMode(short iData);
short getPinsMode();
short getPinMode(short pin);
void setPinMode(short pin, short mode);
void setPinsVal(short iData);
short getPinsVal();
short getPinVal(short pin);
void setPinVal(short pin, short val);
