using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ADBBurningMAC
{
    class SystemConfig
    {
        public static Display display = new Display();
        public static Logo logo = new Logo();

        public static void parserConfig(String path)
        {

            JObject systemConfig = JObject.Parse(File.ReadAllText(path));

            pushJsonDataToCollection(systemConfig["display"]["resolution"], display.resolution);
            pushJsonDataToCollection(systemConfig["display"]["color_depth"], display.color_depth);
            pushJsonDataToCollection(systemConfig["display"]["display_type"], display.display_type);
            pushJsonDataToCollection(systemConfig["logo_ID"], logo.type);
            

            print();
        }

        public static void pushJsonDataToCollection(JToken jtokens, Dictionary<int, String> dict)
        {
            foreach (JToken item in jtokens)
            {
                JObject obj = JObject.Parse("{" + item.ToString() + "}");
                foreach(var pair in obj)
                {
                    if (pair.Key.ToString().Trim().Length > 0 && pair.Value.ToString().Trim().Length >0)
                    {
                        dict.Add(Convert.ToInt32(pair.Key.ToString(), 16), pair.Value.ToString());
                    }
                }
            }

        }

        public static void print()
        {
            Console.WriteLine("Resolution");
            foreach( KeyValuePair<int, String> kvp in display.resolution)
            {
                Console.WriteLine("key={0},value={1}", kvp.Key, kvp.Value);
            }

            Console.WriteLine("Color Depth");
            foreach( KeyValuePair<int, String> kvp in display.color_depth)
            {
                Console.WriteLine("key={0},value={1}", kvp.Key, kvp.Value);
            }

            Console.WriteLine("Display Type");
            foreach( KeyValuePair<int, String> kvp in display.display_type)
            {
                Console.WriteLine("key={0},value={1}", kvp.Key, kvp.Value);
            }

            Console.WriteLine("Logo Type");
            foreach( KeyValuePair<int, String> kvp in logo.type)
            {
                Console.WriteLine("key={0},value={1}", kvp.Key, kvp.Value);
            }

            Console.WriteLine("logo.type[1]: " + logo.type[1]);
        }
    }

    class Display
    {
        public Dictionary<int, String> resolution = new Dictionary<int, string>();
        public Dictionary<int, String> color_depth = new Dictionary<int, string>();
        public Dictionary<int, String> display_type = new Dictionary<int, string>();
    }

    class Logo
    {
        public Dictionary<int, String> type = new Dictionary<int, string>();
    }
}
