using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manufacturing_Execution
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //利用C#反射打开指定窗体
            string stratSystem = string.Empty;
            string stratClass = string.Empty;
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] t = new string[assembly.GetTypes().Length];
            stratSystem = assembly.GetName().Name.Replace(" ", "_");
            stratClass = ConfigurationManager.AppSettings["FormName"].ToString();
            Type type = assembly.GetType(stratSystem + "." + stratClass);
            MetroAppForm obj = (MetroAppForm)Activator.CreateInstance(type);
            Application.Run(obj);
            //Application.Run(new Manufacturing3());
        }
    }
}
