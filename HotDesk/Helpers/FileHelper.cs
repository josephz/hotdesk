using System;
using System.Collections.Generic;
using System.IO;

namespace HotDesk.Helpers
{
    public static class FileHelper
    {
        static string pathToData_App = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/data.txt";

        public static List<int> GetAppData()
        {
            var result = new List<int>();
            IEnumerable<string> data;

            try
            {
                data = File.ReadLines(pathToData_App);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            foreach (var line in data)
            {
                if (!string.IsNullOrEmpty(line))
                    result.Add(int.Parse(line));
            }

            return result;
        }

        public static void UpdateAppData(int num, bool isAvailable)
        {
            try
            {
                string text = File.ReadAllText(pathToData_App);
                if (isAvailable)
                {                    
                    text = text + num + "\r\n";
                }
                else
                {
                    text = text.Replace(num.ToString(), string.Empty);
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