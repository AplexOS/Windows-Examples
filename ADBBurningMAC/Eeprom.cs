using System;
using System.Collections.Generic;

namespace ADBBurningMAC
{
    class Eeprom
    {
        public const byte macIdType1 = 0x01;
        public const byte macIdType2 = 0x02;
        public const byte SoftwarePartNumber = 0x03;
        public const byte backlight = 0x04;
        public const byte displayID = 0x10;
        public const byte powerOnLogo = 0x11;
        public const byte touchPanelID = 0x0a;
        public const byte EEPROM_END = 0x00;

        private const int length = 256;
        public static byte[] sendData = new byte[length];
        private static byte[] recvData;
        private static List<DataStruct> dataList = new List<DataStruct>();
        private static List<DataStruct> fileDataList = new List<DataStruct>();

        public static void cleanDataList()
        {
            dataList.Clear();
        }

        public static void initData()
        {
            for (int i = 0; i < length; i++)
            {
                // data[i] = (byte)i;
                sendData[i] = 0;
            }
        }

        public static void saveData()
        {
            Bin2File.saveByteArray(sendData);
        }

        public static bool readDataWithCompare(String path)
        {
            recvData = Bin2File.readByteArray(path);
            int i = 0;
            for (; i < recvData.Length; i++)
            {
                if (i > (length - 1))
                    break;

                if (sendData[i] != recvData[i])
                    return false;
            }

            if (i == sendData.Length)
                return true;
            else
                return false;
            // Bin2File.printByteArray(data);
        }

        public static void parseFileData()
        {
            int index = 0;
            while (true)
            {
                if (recvData[index] == 0)
                    break;

                DataStruct ds = new DataStruct();
                ds.type = recvData[index++];
                ds.length = recvData[index++];
                ds.data = new byte[ds.length];
                for (int i = 0; i < ds.length; i++)
                    ds.data[i] = recvData[index++];

                fileDataList.Add(ds);
            }
        }

        public static String[] getMac()
        {
            String[] Macs = new String[2];

            foreach (DataStruct ds in fileDataList)
            {
                if (ds.type == DataStruct.MAC_ID_TYPE_1)
                {
                    Macs[0] = String.Format("{0:X02}:{1:X02}:{2:X02}:{3:X02}:{4:X02}:{5:X02}", ds.data[0], ds.data[1], ds.data[2], ds.data[3], ds.data[4], ds.data[5]);
                }

                if (ds.type == DataStruct.MAC_ID_TYPE_2)
                {
                    Macs[1] = String.Format("{0:X02}:{1:X02}:{2:X02}:{3:X02}:{4:X02}:{5:X02}", ds.data[0], ds.data[1], ds.data[2], ds.data[3], ds.data[4], ds.data[5]);
                }
            }

            return Macs;
        }

        public static void setMac(String mac)
        {
            long macL = long.Parse(mac.Replace(":", ""), System.Globalization.NumberStyles.HexNumber);

            DataStruct data = new DataStruct();

            data.type = DataStruct.MAC_ID_TYPE_1;
            data.length = 0x06;
            data.data = new byte[data.length];

            for (int i = 0; i < 6; i++)
                data.data[i] = (byte)((macL >> ((5 - i) * 8)) & 0xff);

            dataList.Add(data);
        }

        public static void setMac(int index, String mac)
        {
            long macL = long.Parse(mac.Replace(":", ""), System.Globalization.NumberStyles.HexNumber);

            DataStruct data = new DataStruct();

            if (index == 0) 
                data.type = DataStruct.MAC_ID_TYPE_1;
            else
                data.type = DataStruct.MAC_ID_TYPE_2;

            data.length = 0x06;
            data.data = new byte[data.length];

            for (int i = 0; i < 6; i++)
                data.data[i] = (byte)((macL >> ((5 - i) * 8)) & 0xff);

            dataList.Add(data);
        }

        public static void setSoftwarePartNumber(String softwarePartNumber)
        {
            if (softwarePartNumber.Length > 12)
                return;
        
            DataStruct data = new DataStruct();

            data.type = DataStruct.SOFTWARE_PART_NUMBER;
            data.length = 6; //(short)(softwarePartNumber.Length);
            data.data = new byte[data.length];

            int prefix = int.Parse(softwarePartNumber.Substring(0, 4));
            uint subfix = uint.Parse(softwarePartNumber.Substring(4, 8));

            data.data[0] = (byte)((prefix >> 8) & 0xff);
            data.data[1] = (byte)((prefix) & 0xff);

            data.data[2] = (byte)((subfix) >> (8 * 3) & 0xff);
            data.data[3] = (byte)((subfix) >> (8 * 2) & 0xff);
            data.data[4] = (byte)((subfix) >> (8 * 1) & 0xff);
            data.data[5] = (byte)((subfix) >> (8 * 0) & 0xff);

            dataList.Add(data);
        }

        public static void setBacklightControl(byte polarity, byte min, int frequency)
        {
            if (min <= 0)
                min = 0;

            if (min >= 40)
                min = 40;

            if (frequency >= 50000)
                frequency = 50000;

            if (frequency <= 100)
                frequency = 100;
              
            DataStruct data = new DataStruct();

            data.type = DataStruct.BACKLIGHT_CTRL;
            data.length = 4;
            data.data = new byte[data.length];

            data.data[0] = polarity;
            data.data[1] = min;
            data.data[2] = (byte)((frequency >> 8) & 0xff);
            data.data[3] = (byte)((frequency) & 0xff);

            dataList.Add(data);
        }

        public static void setDisplayID(byte resolution, byte colorDepth, byte frameRate, byte displayType)
        {
            if (frameRate <= 30)
                frameRate = 30;

            if (frameRate >= 100)
                frameRate = 100;

            DataStruct data = new DataStruct();

            data.type = DataStruct.DISPlAY_ID;
            data.length = 4;
            data.data = new byte[data.length];

            data.data[0] = resolution;
            data.data[1] = colorDepth;
            data.data[2] = frameRate;
            data.data[3] = displayType;

            dataList.Add(data);
        }

        public static void setPowerOnLogo(byte logoIndex)
        {
            DataStruct data = new DataStruct();

            data.type = DataStruct.DISPlAY_ID;
            data.length = 1;
            data.data = new byte[data.length];

            data.data[0] = logoIndex;

            dataList.Add(data);
        }

        public static void dataListConvertToDataArray(short version)
        {
            initData();

            //int listSize = dataList.Count();
            int index = 0;
            foreach (DataStruct ds in dataList)
            {
                sendData[index++] = ds.type;
                sendData[index++] = ds.length;

                for (int i = 0; i < ds.length; i++)
                    sendData[index++] = ds.data[i];
            }

            sendData[0xfe] = (byte)((version >> 8) & 0xff);
            sendData[0xff] = (byte)(version & 0xff);

            Console.WriteLine("index: " + index);
        }
    }

    class DataStruct
    {
        public const byte MAC_ID_TYPE_1 = 0x01;
        public const byte MAC_ID_TYPE_2 = 0x02;
        public const byte SOFTWARE_PART_NUMBER = 0x03;
        public const byte BACKLIGHT_CTRL = 0x04;
        public const byte DISPlAY_ID = 0x10;
        public const byte POWER_ON_LOGO = 0x11;
        public const byte TOUCH_PANEL_ID = 0x0a;
        public const byte EEPROM_END = 0x00;

        public byte type;
        public byte length;
        public byte[] data;

        public void toString()
        {
            Console.Write("DataStruct: {{ type = 0x{0:X02}, length = 0x{1:X02}, data = {{ ", type, length);
            int i = 0;
            for (; i < (length - 1); i++)
                Console.Write("0x{0:X02}, ", data[i]);

            Console.WriteLine("0x{0:X02} }}}}", data[i]);
        }
    }
}