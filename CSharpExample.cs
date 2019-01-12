using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using InpOut32.CSharp.Net;

namespace InpOut32.Net
{
    public partial class CSharpExample : Form
    {
        public Boolean initPortFlag = false;

        public CSharpExample()
        {
            InitializeComponent();

            uint nResult = AplexOS7116GPIO.initInpOut32Lib();
            if (nResult == 0)
            {
                lblMessage.Text = "Unable to open InpOut32 driver";
                readByte.Enabled = false;
                writeByte.Enabled = false;
                readMode.Enabled = false;
                writeMode.Enabled = false;
                readValue.Enabled = false;
                writeValue.Enabled = false;
            }

        }

        private void readByte_Click(object sender, EventArgs e)
        {
            try
            {
                ushort c;
                // �ַ���ת16λshort��������
                short iPort = Convert.ToInt16(portAddr.Text, 16);

                if (AplexOS7116GPIO.m_bX64)
                    c = AplexOS7116GPIO.Inp32_x64(iPort);
                else
                    c = AplexOS7116GPIO.Inp32(iPort);
                
                // ����ȡ��������ʾ���� 
                portValue.Text = Convert.ToUInt16(c).ToString("X2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\n" + ex.Message);
            }
        }

        private void writeByte_Click(object sender, EventArgs e)
        {
            try
            {
                // �ַ���ת16λshort��������
                short iPort = Convert.ToInt16(portAddr.Text, 16);
                short iData = Convert.ToInt16(portValue.Text, 16);

                if (AplexOS7116GPIO.m_bX64)
                    AplexOS7116GPIO.Out32_x64(iPort, iData);
                else
                    AplexOS7116GPIO.Out32(iPort, iData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\n" + ex.Message);
            }
        }

        private void CSharpExample_FormClosing(object sender, FormClosingEventArgs e)
        {
            AplexOS7116GPIO.freeGPIO();
        }

        private void readMode_Click(object sender, EventArgs e)
        {
            try
            {
                short c;
                c = AplexOS7116GPIO.getPinsMode();
                
                // ����ȡ��������ʾ���� 
                portValue.Text = Convert.ToInt32(c).ToString("X2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\n" + ex.Message);
            }
        }

        private void writeMode_Click(object sender, EventArgs e)
        {
            try
            {
                short iData = Convert.ToInt16(portValue.Text, 16);
                AplexOS7116GPIO.setPinsMode(iData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\n" + ex.Message);
            }

        }

        private void readValue_Click(object sender, EventArgs e)
        {
            try
            {
                short c;
                c = AplexOS7116GPIO.getPinsVal();
                
                // ����ȡ��������ʾ���� 
                portValue.Text = Convert.ToInt32(c).ToString("X2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\n" + ex.Message);
            }

        }

        private void writeValue_Click(object sender, EventArgs e)
        {
            try
            {
                short iData = Convert.ToInt16(portValue.Text, 16);
                AplexOS7116GPIO.setPinsVal(iData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured:\n" + ex.Message);
            }

        }

        private void setPinValue_Click(object sender, EventArgs e)
        {
            if (this.initPortFlag)
            {
                AplexOS7116GPIO.setPinMode(AplexOS7116GPIO.hexStrToNum(pinIndex.Text.Trim()), AplexOS7116GPIO.hexStrToNum(pinMode.Text.Trim()));
                AplexOS7116GPIO.setPinVal(AplexOS7116GPIO.hexStrToNum(pinIndex.Text.Trim()), AplexOS7116GPIO.hexStrToNum(pinValue.Text.Trim()));
            } else {
                MessageBox.Show("Please Init Port");
            }
        }

        private void getPinValue_Click(object sender, EventArgs e)
        {
            if (this.initPortFlag)
            {
                AplexOS7116GPIO.setPinMode(AplexOS7116GPIO.hexStrToNum(pinIndex.Text.Trim()), AplexOS7116GPIO.hexStrToNum(pinMode.Text.Trim()));
                pinValue.Text = AplexOS7116GPIO.getPinVal(AplexOS7116GPIO.hexStrToNum(pinIndex.Text.Trim())).ToString("X") ;
            } else {
                MessageBox.Show("Please Init Port");
            }
        }

        private void pinInitPort_Click(object sender, EventArgs e)
        {

            AplexOS7116GPIO.addressPort = pinAddrPort.Text;
            AplexOS7116GPIO.dataPort = pinDataPort.Text;
            AplexOS7116GPIO.initGPIO();

            this.initPortFlag = true;
        }
    }
}