using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HotDesk.Helpers
{
    public static class FileHelper
    {
        static string pathToData_App = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/data.txt";

        public static List<int> GetAppData()
        {
            string data;

            try
            {
                data = File.ReadAllText(pathToData_App).Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            var values = data.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            .Where(sValue => !string.IsNullOrWhiteSpace(sValue))
                            .Select(sValue => Int32.Parse(sValue.Trim()))
                            .ToList();

            return values;
        }

        public static void UpdateAppData(int num, bool isAvailable)
        {
            try
            {
                string text = File.ReadAllText(pathToData_App);
                string entry = num + ",";
                if (isAvailable)
                {
                    if (!text.Contains(entry))
                        text = text + entry;
                }
                else
                {
                    text = text.Replace(entry, string.Empty);
                }
                File.WriteAllText(pathToData_App, text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}