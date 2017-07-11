using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using yoedgeForm.Forms;
using yoedgeForm.Util.FileTool;

namespace yoedgeForm
{
    static class Program
    {
        public static Config config { get; set; }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Config.json"))
            {
                new Config
                {
                }.save();
            }
            try
            {
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Config.json"));
            }
            catch (Exception ex)
            {
                //LogTool.WriteLogError(typeof(Program), "读取配置文件出现错误", ex);
                MessageBox.Show("配置文件读取时出现意料之外的错误! 请删除程序目录下的Config.json重试!");
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
