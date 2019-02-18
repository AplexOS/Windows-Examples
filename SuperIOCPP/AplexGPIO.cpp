#include "stdafx.h"
#include "AplexGPIO.h"

typedef void(__stdcall *lpOut32)(short, short);
typedef short(__stdcall *lpInp32)(short);
typedef BOOL(__stdcall *lpIsInpOutDriverOpen)(void);
typedef BOOL(__stdcall *lpIsXP64Bit)(void);

//Some global function pointers (messy but fine for an example)
lpOut32 gfpOut32;
lpInp32 gfpInp32;
lpIsInpOutDriverOpen gfpIsInpOutDriverOpen;
lpIsXP64Bit gfpIsXP64Bit;
HINSTANCE hInpOutDll;

static bool m_bX64 = false;

static short OUTPUT_MODE   = 0;
static short INPUT_MODE    = 1;
static short PIN_SIZE      = 8;

// modify this port for your board
static char addressPort[] = "4E";
static char dataPort[]    = "4F";

short hexStrToNum(char str[])
{
	return (short)strtol(str, NULL, 16);
}

UINT initInpOut32Lib()
{
	UINT nResult = 0;

	//Dynamically load the DLL at runtime (not linked at compile time)
	hInpOutDll = LoadLibrary(L"InpOut32.DLL");	//The 32bit DLL. If we are building x64 C++ 
												//applicaiton then use InpOutx64.dll
	if (hInpOutDll != NULL)
	{
		gfpOut32 = (lpOut32)GetProcAddress(hInpOutDll, "Out32");
		gfpInp32 = (lpInp32)GetProcAddress(hInpOutDll, "Inp32");
		gfpIsInpOutDriverOpen = (lpIsInpOutDriverOpen)GetProcAddress(hInpOutDll, "IsInpOutDriverOpen");
		gfpIsXP64Bit = (lpIsXP64Bit)GetProcAddress(hInpOutDll, "IsXP64Bit");

		if (gfpIsInpOutDriverOpen())
		{
			return 0;
		}
		else
		{
			printf("Unable to open InpOut32 Driver!\n");
			return -2;
		}
	}
	else
	{
		printf("Unable to load InpOut32 DLL!\n");
		return -1;
	}
}

void closeInpOut32Lib() {
	if (hInpOutDll != NULL)
		FreeLibrary(hInpOutDll);
}


short readByte(short iPort)
{
	USHORT c = 0;

	c = gfpInp32(iPort);

	return (short)(c & 0xFF);
}

void writeByte(short iPort, short iData)
{
	gfpOut32(iPort, iData);
}

void initGPIO()
{
	char portVal[] = "87";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal));
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal));

	char portVal1[] = "07";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal1));
	writeByte(hexStrToNum(dataPort), hexStrToNum(portVal1));

	char portVal2[] = "1C";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal2));
	writeByte(hexStrToNum(dataPort), hexStrToNum(portVal2));

	char portVal3[] = "30";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal3));
	char portVal4[] = "DF";
	writeByte(hexStrToNum(dataPort), hexStrToNum(portVal4));
}

void freeGPIO()
{
	char portVal[] = "AA";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal));
}

void setPinsMode(short iData)
{
	char portVal[] = "E8";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal));
	writeByte(hexStrToNum(dataPort), iData);
}

short getPinsMode()
{
	short c = 0;

	char portVal[] = "E8";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal));
	c = readByte(hexStrToNum(dataPort));

	return c;
}

short getPinMode(short pin)
{
	short c = 0;

	if (pin < 0 || pin >(PIN_SIZE - 1))
	{
		return c;
	}

	char portVal[] = "E8";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal));
	c = readByte(hexStrToNum(dataPort));

	return (short)((c >> pin) & 0x01);
}

void setPinMode(short pin, short mode)
{
	if (pin < 0 || pin >(PIN_SIZE - 1))
	{
		return;
	}
	if (mode < 0 || mode > 1)
	{
		return;
	}

	short c = (short)getPinsMode();
	if (mode == OUTPUT_MODE)
	{
		c = (short)(c & (~(1 << pin)));
	}
	else if (mode == INPUT_MODE)
	{
		c = (short)(c | (1 << pin));
	}
	setPinsMode(c);
}

void setPinsVal(short iData)
{
	char portVal[] = "E9";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal));
	writeByte(hexStrToNum(dataPort), iData);
}

short getPinsVal()
{
	short c = 0;

	char portVal[] = "E9";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal));
	c = readByte(hexStrToNum(dataPort));

	return c;
}

short getPinVal(short pin)
{
	short c = 0;

	if (pin < 0 || pin >(PIN_SIZE - 1))
	{
		return c;
	}

	char portVal[] = "E9";
	writeByte(hexStrToNum(addressPort), hexStrToNum(portVal));
	c = readByte(hexStrToNum(dataPort));

	return (short)((c >> pin) & 0x01);
}

void setPinVal(short pin, short val)
{
	if (pin < 0 || pin >(PIN_SIZE - 1))
	{
		return;
	}
	if (val < 0 || val > 1)
	{
		return;
	}

	short c = (short)getPinsVal();
	if (val == 0)
	{
		c = (short)(c & (~(1 << pin)));
	}
	else if (val == 1)
	{
		c = (short)(c | (1 << pin));
	}
	setPinsVal(c);
}