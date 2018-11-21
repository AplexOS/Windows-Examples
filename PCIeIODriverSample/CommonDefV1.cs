using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCIeIODriverSample
{
    class CommonDefV1
    {
        public static UInt32 DLL_SIMULATION_MODE = 1;
        public static UInt32 PCIE_MEMORY_MODE    = 2;

        public static UInt32 PCIE_MEMORY_LENGTH = 0x2000;
        public static UInt32[] I2C_ADDRS= {0x20, 0x23, 0x2C, 0x2F};
        public static UInt32 LIGHT_LEVEL_MAX = 0xFF;

        public class Trigger
        {
            
            public static UInt32[]  TRIGGER_T_BASE      = { REG_ADDR.T1_COUNT1, REG_ADDR.T1_COUNT2, REG_ADDR.T1_COUNT3, REG_ADDR.T1_COUNT4 };
            public static UInt32[]  TRIGGER_PLUSE_BASE  = { REG_ADDR.PULSE_COUNT1_L1, REG_ADDR.PULSE_COUNT2_L1, REG_ADDR.PULSE_COUNT3_L1, REG_ADDR.PULSE_COUNT4_L1 };
            public static UInt32[]  LIGHTOUT_PLUSE_BASE = { REG_ADDR.PULSE_COUNT_L5, REG_ADDR.PULSE_COUNT_L6, REG_ADDR.PULSE_COUNT_L7, REG_ADDR.PULSE_COUNT_L8};
            public static UInt32    TRIGGER_CLK_DIV     = REG_ADDR.CLK_COUNT;
            public static UInt32    TRIGGER_CONTROL     = REG_ADDR.TRIGGER_CONTROL_REG;
            public static UInt32    TRIGGEROUT_SELECT   = REG_ADDR.TRIGGEROUT_REG1;
            public static UInt32    TRIGGEROUT_ENALBE   = REG_ADDR.TRIGGEROUT_REG2;
            public static UInt32    TRIGGER_LIGHTOUT    = REG_ADDR.LIGHTOUT_REG;
            public static UInt32    TRIGGER_REG_LEN     = 57;

            public static UInt32 REG_Value(UInt32 current, UInt32 mask, Int32 offset, Int32 val)
            {
                if ((val != -1) && (val > 0))
                    current = (UInt32)((current & ~(mask << offset)) | (UInt32)(val << offset));

                return current;
            }

            public static UInt32 trigger_control(
                UInt32 current             = 0,
                Int32 index                = -1,
                Int32 triggerMode          = -1,
                Int32 triggerManual        = -1, 
                Int32 triggerManualEnable  = -1
                )
            {

                switch(index)
                {
                    case 1:
                        current = REG_Value(current, 0x7, 20, triggerMode);
                        current = REG_Value(current, 0x1, 16, triggerManual);
                        current = REG_Value(current, 0x1, 12, triggerManualEnable);
                        break;
                    case 2:
                        current = REG_Value(current, 0x7, 23, triggerMode);
                        current = REG_Value(current, 0x1, 17, triggerManual);
                        current = REG_Value(current, 0x1, 13, triggerManualEnable);
                        break;
                    case 3:
                        current = REG_Value(current, 0x7, 26, triggerMode);
                        current = REG_Value(current, 0x1, 18, triggerManual);
                        current = REG_Value(current, 0x1, 14, triggerManualEnable);
                        break;
                    case 4:
                        current = REG_Value(current, 0x7, 29, triggerMode);
                        current = REG_Value(current, 0x1, 19, triggerManual);
                        current = REG_Value(current, 0x1, 15, triggerManualEnable);
                        break;
                    default:
                        break;
                }

                return current;

            }

            public static UInt32 triggerout_select(
                UInt32 current          = 0,
                Int32 index             = -1,
                Int32 trigger1Select    = -1,
                Int32 trigger2Select    = -1,
                Int32 trigger3Select    = -1,
                Int32 trigger4Select    = -1
                )
            {
                switch (index)
                {
                    case 1:
                        current = REG_Value(current, 0x03,  6, trigger4Select);
                        current = REG_Value(current, 0x03,  4, trigger3Select);
                        current = REG_Value(current, 0x03,  2, trigger2Select);
                        current = REG_Value(current, 0x03,  0, trigger1Select);
                        break;
                    case 2:
                        current = REG_Value(current, 0x03, 14, trigger4Select);
                        current = REG_Value(current, 0x03, 12, trigger3Select);
                        current = REG_Value(current, 0x03, 10, trigger2Select);
                        current = REG_Value(current, 0x03,  8, trigger1Select);
                        break;
                    case 3:
                        current = REG_Value(current, 0x03, 22, trigger4Select);
                        current = REG_Value(current, 0x03, 20, trigger3Select);
                        current = REG_Value(current, 0x03, 18, trigger2Select);
                        current = REG_Value(current, 0x03, 16, trigger1Select);
                        break;
                    case 4:
                        current = REG_Value(current, 0x03, 30, trigger4Select);
                        current = REG_Value(current, 0x03, 28, trigger3Select);
                        current = REG_Value(current, 0x03, 26, trigger2Select);
                        current = REG_Value(current, 0x03, 24, trigger1Select);
                        break;
                    default:
                        break;
                }

                return current;

            }

            public static UInt32 triggerout_enable(
                UInt32 current          = 0,
                Int32 index             = -1,
                Int32 triggerEnable     = -1,
                Int32 signalMode        = -1
                )
            {
                switch (index)
                {
                    case 1:
                        current = REG_Value(current, 0x0F, 16, triggerEnable);
                        current = REG_Value(current, 0x03,  8, signalMode);
                        break;
                    case 2:
                        current = REG_Value(current, 0x0F, 20, triggerEnable);
                        current = REG_Value(current, 0x03, 10, signalMode);
                        break;
                    case 3:
                        current = REG_Value(current, 0x0F, 24, triggerEnable);
                        current = REG_Value(current, 0x03, 12, signalMode);
                        break;
                    case 4:
                        current = REG_Value(current, 0x0F, 28, triggerEnable);
                        current = REG_Value(current, 0x03, 14, signalMode);
                        break;
                    default:
                        break;
                }

                return current;

            }

            public static UInt32 trigger_lightout(
                UInt32 current          = 0,
                Int32 index             = -1,
                Int32 triggerSelect    = -1,
                Int32 signalMode       = -1
                )
            {
                switch (index)
                {
                    case 1:
                        current = REG_Value(current, 0x03, 24, triggerSelect);
                        current = REG_Value(current, 0x03, 16, signalMode);
                        break;
                    case 2:
                        current = REG_Value(current, 0x03, 26, triggerSelect);
                        current = REG_Value(current, 0x03, 18, signalMode);
                        break;
                    case 3:
                        current = REG_Value(current, 0x03, 28, triggerSelect);
                        current = REG_Value(current, 0x03, 20, signalMode);
                        break;
                    case 4:
                        current = REG_Value(current, 0x03, 30, triggerSelect);
                        current = REG_Value(current, 0x03, 22, signalMode);
                        break;
                    default:
                        break;
                }

                return current;
            }


            class REG_ADDR
            {
                public static UInt32 TRIGGER_CONTROL_REG = 0x00;
                public static UInt32 TRIGGEROUT_REG1     = 0x01;
                public static UInt32 TRIGGEROUT_REG2     = 0x02;
                public static UInt32 LIGHTOUT_REG        = 0x03;
                public static UInt32 CLK_COUNT           = 0x04;

                public static UInt32 T1_COUNT1           = 0x05;
                public static UInt32 T2_COUNT1           = 0x06;
                public static UInt32 N_COUNT1            = 0x07;

                public static UInt32 T1_COUNT2           = 0x08;
                public static UInt32 T2_COUNT2           = 0x09;
                public static UInt32 N_COUNT2            = 0x0A;

                public static UInt32 T1_COUNT3           = 0x0B;
                public static UInt32 T2_COUNT3           = 0x0C;
                public static UInt32 N_COUNT3            = 0x0D;

                public static UInt32 T1_COUNT4           = 0x0E;
                public static UInt32 T2_COUNT4           = 0x0F;
                public static UInt32 N_COUNT4            = 0x10;

                public static UInt32 PULSE_COUNT1_L1     = 0x11;
                public static UInt32 PULSE_COUNT1_H1     = 0x12;
                public static UInt32 PULSE_COUNT1_L2     = 0x13;
                public static UInt32 PULSE_COUNT1_H2     = 0x14;
                public static UInt32 PULSE_COUNT1_L3     = 0x15;
                public static UInt32 PULSE_COUNT1_H3     = 0x16;
                public static UInt32 PULSE_COUNT1_L4     = 0x17;
                public static UInt32 PULSE_COUNT1_H4     = 0x18;

                public static UInt32 PULSE_COUNT2_L1     = 0x19;
                public static UInt32 PULSE_COUNT2_H1     = 0x1A;
                public static UInt32 PULSE_COUNT2_L2     = 0x1B;
                public static UInt32 PULSE_COUNT2_H2     = 0x1C;
                public static UInt32 PULSE_COUNT2_L3     = 0x1D;
                public static UInt32 PULSE_COUNT2_H3     = 0x1E;
                public static UInt32 PULSE_COUNT2_L4     = 0x1F;
                public static UInt32 PULSE_COUNT2_H4     = 0x20;

                public static UInt32 PULSE_COUNT3_L1     = 0x21;
                public static UInt32 PULSE_COUNT3_H1     = 0x22;
                public static UInt32 PULSE_COUNT3_L2     = 0x23;
                public static UInt32 PULSE_COUNT3_H2     = 0x24;
                public static UInt32 PULSE_COUNT3_L3     = 0x25;
                public static UInt32 PULSE_COUNT3_H3     = 0x26;
                public static UInt32 PULSE_COUNT3_L4     = 0x27;
                public static UInt32 PULSE_COUNT3_H4     = 0x28;

                public static UInt32 PULSE_COUNT4_L1     = 0x29;
                public static UInt32 PULSE_COUNT4_H1     = 0x2A;
                public static UInt32 PULSE_COUNT4_L2     = 0x2B;
                public static UInt32 PULSE_COUNT4_H2     = 0x2C;
                public static UInt32 PULSE_COUNT4_L3     = 0x2D;
                public static UInt32 PULSE_COUNT4_H3     = 0x2E;
                public static UInt32 PULSE_COUNT4_L4     = 0x2F;
                public static UInt32 PULSE_COUNT4_H4     = 0x30;

                public static UInt32 PULSE_COUNT_L5     = 0x31 ;
                public static UInt32 PULSE_COUNT_H5     = 0x32 ;
                public static UInt32 PULSE_COUNT_L6     = 0x33 ;
                public static UInt32 PULSE_COUNT_H6     = 0x34 ;
                public static UInt32 PULSE_COUNT_L7     = 0x35 ;
                public static UInt32 PULSE_COUNT_H7     = 0x36 ;
                public static UInt32 PULSE_COUNT_L8     = 0x37 ;
                public static UInt32 PULSE_COUNT_H8     = 0x38 ;
            }
        }
    }
}
