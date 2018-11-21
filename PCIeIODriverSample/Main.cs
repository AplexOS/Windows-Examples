using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PCIeIODriverSample
{
    public partial class Main : Form
    {
        [DllImport("PCIeIODriverDLL.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 OpenPCIeDeviceInterface(UInt32 workMode);

        [DllImport("PCIeIODriverDLL.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 ClosePCIeDeviceInterface();

        [DllImport("PCIeIODriverDLL.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 PCIeI2CMasterInit();

        [DllImport("PCIeIODriverDLL.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 PCIeI2CWriteAD5141Byte(UInt32 index, UInt32 val);

        [DllImport("PCIeIODriverDLL.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 PCIeI2CReadAD5141Byte(UInt32 index, UInt32[] val);

        [DllImport("PCIeIODriverDLL.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 PCIeGetTrigger(UInt32[] offset, UInt32[] val, UInt32 len);

        [DllImport("PCIeIODriverDLL.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 PCIeSetTrigger(UInt32[] offset, UInt32[] val, UInt32 len);

        [DllImport("PCIeIODriverDLL.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 PCIeSetOutput(UInt32 val);

        [DllImport("PCIeIODriverDLL.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 PCIeGetOutput(UInt32[] val);

        [DllImport("PCIeIODriverDLL.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern Int32 PCIeGetIntput(UInt32[] val);

        public Main()
        {
            int ret = 0;

            InitializeComponent();

            OutputVoltageIndex.Enabled = true;
            OutputVoltage.Enabled = true;

            ret = OpenPCIeDeviceInterface(CommonDef.PCIE_MEMORY_MODE);
            if (ret == 0)
            {
                InfoText.Text = "Open PCIe Device Success.\r\n";
                // DumpMemory.Enabled = true;
                OutputVoltageIndex.Enabled = true;
                OutputVoltage.Enabled = true;

                ret = PCIeI2CMasterInit();
                if (ret != 0)
                    InfoText.Text = "Set I2C Master Device Error\r\n";

            } else if (ret == -5)
            {
                InfoText.Text = "Please use admin permission: " + ret + "\r\n";
            } else
                InfoText.Text = "Open PCIe Device Faild: " + ret + "\r\n";

            UInt32[] vals = { 0 };
            ret = PCIeI2CReadAD5141Byte(Convert.ToUInt32(OutputVoltageIndex.Text) - 1, vals);
            InfoText.Text += "ret: " + ret + ": vales[0] " + vals[0] + "\r\n";

            InfoText.Text += CommonDef.GetTimestamp();
        }

        public string UInt32ArrayToString(UInt32[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            for (int index = 0; index < ba.Length; index++)
            {
                if ((index % 8) == 0)
                    hex.AppendFormat("\r\n [{0:x4}]: ", index);
                hex.AppendFormat(" {0:x8}", ba[index]);
            }

            return hex.ToString();
        }

        private void OutputVoltageValueChanged(object sender, MouseEventArgs e)
        {
            int ret = PCIeI2CWriteAD5141Byte(Convert.ToUInt32(OutputVoltageIndex.Text) - 1, CommonDef.LIGHT_LEVEL_MAX - Convert.ToUInt32(OutputVoltage.Value));
            if (ret != 0)
                InfoText.Text = "Set Voltage Device Error\r\n";

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePCIeDeviceInterface();
        }

        private void trigger_reset(Int32 reset)
        {
            int ret;

            UInt32[] addr = { CommonDef.Trigger.REG_ADDR.TRIGGEROUT_REG2 };
            UInt32[] val  = { 0 };

            ret = PCIeGetTrigger(addr, val, 1);
            if (ret != 0)
            {
                InfoText.Text += "reset get value error\r\n";
            }
            val[0] = CommonDef.Trigger.trigger_reset(val[0], reset);
            ret = PCIeSetTrigger(addr, val, 1);
            InfoText.Text += "reset value: 0x" + val[0].ToString("X") + "\r\n";
            if (ret != 0)
            {
                InfoText.Text += "reset set value error\r\n";
            }

        }

        private void WriteConfigure_Click(object sender, EventArgs e)
        {
            int ret;

            UInt32[] addr = new UInt32[CommonDef.Trigger.TRIGGER_REG_LEN];
            UInt32[] val  = new UInt32[CommonDef.Trigger.TRIGGER_REG_LEN];

            InfoText.Text = "";
            for (uint index = 0; index < CommonDef.Trigger.TRIGGER_REG_LEN; index++)
            {
                addr[index] = index;
                val[index]  = 0;
            }

            trigger_reset(1);

            ret = PCIeGetTrigger(addr, val, CommonDef.Trigger.TRIGGER_REG_LEN);
            if (ret != 0)
            {
                InfoText.Text += "PCIe read register error: " + ret + "\r\n";
                return;
            }

            InfoText.Text += DateTime.Now.ToString("MM/dd/yyyy h:mm tt");
            InfoText.Text += "\r\n" + UInt32ArrayToString(val) + "\r\n";

            try
            {
                val[CommonDef.Trigger.TRIGGER_CLK_DIV] = Convert.ToUInt32(ClockDivision.Text);

                int triggerOutIndex = Convert.ToInt32(TriggerOutIndex.Text);
                int lightOutIndex = Convert.ToInt32(LightOutIndex.Text);
                int triggerInIndex = Convert.ToInt32(TriggerInIndex.Text);

                // set TRIGGER_CONTROL reg
                int triggerInControl = TriggerInControl.SelectedIndex;
                int triggerOutMode   = TriggerOutMode.SelectedIndex;
                int lightOutMode     = LightOutMode.SelectedIndex;
                val[CommonDef.Trigger.TRIGGER_CONTROL] = CommonDef.Trigger.trigger_control(val[CommonDef.Trigger.TRIGGER_CONTROL], triggerInIndex, triggerInControl + 1, 0, triggerOutMode, lightOutMode);

                val[CommonDef.Trigger.TRIGGER_T_BASE[triggerInIndex - 1] + 0x00] = Convert.ToUInt32(T1.Text);
                val[CommonDef.Trigger.TRIGGER_T_BASE[triggerInIndex - 1] + 0x01] = Convert.ToUInt32(T2.Text);
                val[CommonDef.Trigger.TRIGGER_T_BASE[triggerInIndex - 1] + 0x02] = Convert.ToUInt32(T3.Text);

                // set TRIGGEROUT reg
                int p1TriggerInIndex = Convert.ToInt32(P1TriggerInIndex.Text) - 1;
                int p2TriggerInIndex = Convert.ToInt32(P2TriggerInIndex.Text) - 1;
                int p3TriggerInIndex = Convert.ToInt32(P3TriggerInIndex.Text) - 1;
                int p4TriggerInIndex = Convert.ToInt32(P4TriggerInIndex.Text) - 1;
                int pathEnable       = Convert.ToInt32(PathEnable.Text, 16);

                val[CommonDef.Trigger.TRIGGEROUT_SELECT] = CommonDef.Trigger.triggerout_select(val[CommonDef.Trigger.TRIGGEROUT_SELECT], triggerOutIndex, p1TriggerInIndex, p2TriggerInIndex, p3TriggerInIndex, p4TriggerInIndex);
                val[CommonDef.Trigger.TRIGGEROUT_ENALBE] = CommonDef.Trigger.triggerout_enable(val[CommonDef.Trigger.TRIGGEROUT_ENALBE], triggerOutIndex, pathEnable, triggerInIndex - 1, TriggerOutEnable.Text == "Enable" ? 1 : 0);

                val[CommonDef.Trigger.TRIGGER_PLUSE_BASE[triggerOutIndex - 1] + 0x00] = Convert.ToUInt32(P1TriggerInIndexL.Text);
                val[CommonDef.Trigger.TRIGGER_PLUSE_BASE[triggerOutIndex - 1] + 0x01] = Convert.ToUInt32(P1TriggerInIndexH.Text);
                val[CommonDef.Trigger.TRIGGER_PLUSE_BASE[triggerOutIndex - 1] + 0x02] = Convert.ToUInt32(P2TriggerInIndexL.Text);
                val[CommonDef.Trigger.TRIGGER_PLUSE_BASE[triggerOutIndex - 1] + 0x03] = Convert.ToUInt32(P2TriggerInIndexH.Text);
                val[CommonDef.Trigger.TRIGGER_PLUSE_BASE[triggerOutIndex - 1] + 0x04] = Convert.ToUInt32(P3TriggerInIndexL.Text);
                val[CommonDef.Trigger.TRIGGER_PLUSE_BASE[triggerOutIndex - 1] + 0x05] = Convert.ToUInt32(P3TriggerInIndexH.Text);
                val[CommonDef.Trigger.TRIGGER_PLUSE_BASE[triggerOutIndex - 1] + 0x06] = Convert.ToUInt32(P4TriggerInIndexL.Text);
                val[CommonDef.Trigger.TRIGGER_PLUSE_BASE[triggerOutIndex - 1] + 0x07] = Convert.ToUInt32(P4TriggerInIndexH.Text);

                // set LIGHTOUT reg
                int lightOutTriggerInIndex = Convert.ToInt32(LightOutTriggerInIndex.Text) - 1;
                val[CommonDef.Trigger.TRIGGER_LIGHTOUT] = CommonDef.Trigger.trigger_lightout(val[CommonDef.Trigger.TRIGGER_LIGHTOUT], 
                    lightOutIndex, lightOutTriggerInIndex, lightOutTriggerInIndex, LightOutEnable.Text == "Enable" ? 1 : 0);

                val[CommonDef.Trigger.LIGHTOUT_PLUSE_BASE[lightOutIndex - 1] + 0x00] = Convert.ToUInt32(LightOutL.Text);
                val[CommonDef.Trigger.LIGHTOUT_PLUSE_BASE[lightOutIndex - 1] + 0x01] = Convert.ToUInt32(LightOutH.Text);

                val[CommonDef.Trigger.DEBOUNCE_BASE + (triggerInIndex - 1)] = Convert.ToUInt32(DebounceValue.Text);

            } catch (Exception ex)
            {
                InfoText.Text = "Please Check data format:" + ex.Message + "\r\n";
            }

            ret = PCIeSetTrigger(addr, val, CommonDef.Trigger.TRIGGER_REG_LEN);
            if (ret != 0)
            {
                InfoText.Text += "PCIe write register error: " + ret + "\r\n";
                return;
            }

            trigger_reset(0);

            InfoText.Text += "\r\n" + UInt32ArrayToString(val) + "\r\n";
        }

        private void GetGPIOInput_Click(object sender, EventArgs e)
        {
            int ret       = 0;
            UInt32[] val  = { 0 };

            ret = PCIeGetIntput(val);
            if (ret != 0)
            {
                InfoText.Text += "PCIe get input error: " + ret + "\r\n";
                return;
            }

            GPIOInputVal.Text = val[0].ToString("X");

        }

        private void GetGPIOOutput_Click(object sender, EventArgs e)
        {
            int ret       = 0;
            UInt32[] val  = { 0 };

            ret = PCIeGetOutput(val);
            if (ret != 0)
            {
                InfoText.Text += "PCIe get Output error: " + ret + "\r\n";
                return;
            }

            GPIOOutputVal.Text = val[0].ToString("X");

        }

        private void SetGPIOOutput_Click(object sender, EventArgs e)
        {
            int ret    = 0;
            UInt32 val = 0;
            try
            {
                val  = Convert.ToUInt32(GPIOOutputVal.Text, 16);

            } catch
            {
                InfoText.Text += "Please check data format.\r\n";
            }

            ret = PCIeSetOutput(val);
            if (ret != 0)
            {
                InfoText.Text += "PCIe set Output error: \r\n" + ret;
                return;
            }

        }

        private void TriggerInMode_SelectedValueChanged(object sender, EventArgs e)
        {
            InfoText.Text += "Select " + TriggerOutMode.Text + " mode\r\n";
        }

        private void ManualHigh_Click(object sender, EventArgs e)
        {
            int ret = 0;
            UInt32[] addr = { CommonDef.Trigger.TRIGGER_CONTROL };
            UInt32[] val = { 0 };
            int manualIndex = Convert.ToInt32(ManualIndex.Text);

            InfoText.Text = manualIndex + "\r\n";

            ret = PCIeGetTrigger(addr, val, (UInt32)(addr.Length));
            if (ret != 0)
            {
                InfoText.Text += "PCIe read register error: " + ret + "\r\n";
                return;
            }

            InfoText.Text += UInt32ArrayToString(val);
            val[0] = CommonDef.Trigger.trigger_control(val[0], manualIndex, -1, 1, -1, -1);
            InfoText.Text += UInt32ArrayToString(val);

            ret = PCIeSetTrigger(addr, val, (UInt32)(addr.Length));
            if (ret != 0)
            {
                InfoText.Text += "PCIe read register error: " + ret + "\r\n";
                return;
            }
        }

        private void ManualLow_Click(object sender, EventArgs e)
        {
            int ret = 0;
            UInt32[] addr = { CommonDef.Trigger.TRIGGER_CONTROL };
            UInt32[] val = { 0 };
            int manualIndex = Convert.ToInt32(ManualIndex.Text);

            InfoText.Text = manualIndex + "\r\n";

            ret = PCIeGetTrigger(addr, val, (UInt32)(addr.Length));
            if (ret != 0)
            {
                InfoText.Text += "PCIe read register error: " + ret + "\r\n";
                return;
            }

            InfoText.Text += UInt32ArrayToString(val);
            val[0] = CommonDef.Trigger.trigger_control(val[0], manualIndex, -1, 0, -1, -1);
            InfoText.Text += UInt32ArrayToString(val);

            ret = PCIeSetTrigger(addr, val, (UInt32)(addr.Length));
            if (ret != 0)
            {
                InfoText.Text += "PCIe read register error: " + ret + "\r\n";
                return;
            }
        }
    }
}
