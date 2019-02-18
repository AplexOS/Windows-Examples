// SupperIOCPP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "AplexGPIO.h"

int main(int argc, char* argv[])
{
	if (argc < 3)
	{
		//too few command line arguments, show usage
		printf("\n \
***** Usage *****\n\n \
SuperIOCPP mode <pin number -- [0:7]> <pin mode -- 0: output, 1: input> \n \
or \n \
SuperIOCPP read <pin number> \n \
or \n \
SuperIOCPP write <pin number -- [0:7]> <pin value -- 0: high level, 1: low level>\n\n \
");

	}
	else
	{
		if (initInpOut32Lib() == 0) {
			initGPIO();
			if (!strcmp(argv[1], "mode"))
			{
				if (argc < 4)
				{
					printf("SupperIOCPP mode <pin number -- [0:7]> <pin mode -- 0: output, 1: input> \n\n");
					goto finish;
				}

				short pin = atoi(argv[2]);
				short mode = atoi(argv[3]);
				setPinMode(pin, mode);
				printf("Data write to pin %s mode is %d \n\n", argv[2], mode);
			}
			else if (!strcmp(argv[1], "read"))
			{
				short pin = atoi(argv[2]);
				short val = getPinVal(pin);
				printf("Data read from pin %s value is %d \n\n", argv[2], val);
			}
			else if (!strcmp(argv[1], "write"))
			{
				if (argc < 4)
				{
					printf("SupperIOCPP write <pin number -- [0:7]> <pin value -- 0: high level, 1: low level>\n\n");
					goto finish;
				}

				short pin = atoi(argv[2]);
				short val = atoi(argv[3]);
				setPinVal(pin, val);
				printf("Data write to pin %s value is %d \n\n\n\n", argv[2], val);
			}

		}
finish:
		closeInpOut32Lib();

		return 0;
	}

	return -2;
}
