using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yoedgeForm.Util.FileTool
{
    public class Config
    {
        public int TaskNum { get; set; } = 3;
        public int NetSpeed { get; set; } = 1;

        public void save()
        {
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "Config.json", JObject.Parse(JsonConvert.SerializeObject(this)).ToString());
        }
    }

    public class DownloadItem
    {
        public string FilePath { get; set; }
        public bool Completed { get; set; }
    }
}
