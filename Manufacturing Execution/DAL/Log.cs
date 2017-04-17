using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DAL
{
    public class Log
    {
        public static void LogWrite(string logStr)
        {
            if (!Directory.Exists("Log"))
            {
                Directory.CreateDirectory("Log");
            }
            if (!File.Exists(@"Log/log.txt"))
            {
                File.Create(@"Log/log.txt").Close();
            }
            using (StreamWriter sw = new StreamWriter(@"Log/log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\t\n"+logStr );
            }
        }
    }
}
