using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace ApplicationLog
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathFolder = ConfigurationManager.AppSettings["CompletPathFolder"];
            string appendText = string.Empty;
            string readText = string.Empty;
            string dateTimeTodayToLong = string.Empty;

            try
            {
                dateTimeTodayToLong = DateTime.Today.ToLongDateString();
                
                if (!File.Exists(pathFolder))
                {
                    File.WriteAllText(pathFolder, string.Empty);
                }
                else
                {
                    readText = File.ReadAllText(pathFolder);

                    Console.WriteLine(readText);

                    //readText = File.ReadLines(pathFolder).Any() ? File.ReadLines(pathFolder).Last() : string.Empty;

                    if (!readText.Contains(DateTime.Today.ToLongDateString()))
                    {
                        File.AppendAllText(pathFolder, Environment.NewLine + dateTimeTodayToLong);
                    }
                }
                
                Console.WriteLine(Environment.NewLine + "Type your message:");
                appendText += Environment.NewLine + Environment.NewLine + "[" + DateTime.Now.ToLongTimeString() + "] - " + Console.ReadLine();
                File.AppendAllText(pathFolder, appendText);

            }
            catch (Exception ex)
            {
                Console.WriteLine("OOOPS!!! Deu erro.", ex.Message);
            }
        }
    }
}
