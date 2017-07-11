using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using yoedgeForm.Data;
using yoedgeForm.Util;

namespace yoedgeForm.HttpTool
{
    public class PageHelper
    {
        /// <summary>
        /// 获取章节信息
        /// </summary>
        /// <param name="pageString"></param>
        /// <param name="saveFolder"></param>
        /// <returns></returns>
        public static List<ChapterInfo> GetChapter(string pageString, ref string saveFolder)
        {
            List<ChapterInfo> list = new List<ChapterInfo>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(pageString);
            var comicName = doc.DocumentNode.SelectNodes("//div[@id='appcontent']/div/div[@class='am-u-sm-8']/abbr[1]");
            if (comicName != null)
            {
                saveFolder += comicName[0].InnerText + "\\";
            }
            else
            {
                saveFolder += "默认文件夹\\";
            }


            var nodes = doc.DocumentNode.SelectNodes("//div[@class='am-g']//a/@href");
            foreach (var n in nodes)
            {
                ChapterInfo ci = new ChapterInfo();
                ci.Guid = Guid.NewGuid().ToString();
                ci.Url = n.Attributes["href"].Value;
                if (string.IsNullOrWhiteSpace(ci.Url))
                {
                    continue;
                }
                ci.ChapterName = n.InnerText;
                var mp = Regex.Match(ci.Url, "smp-app/(?<No>.*)/shinmangaplayer", RegexOptions.IgnoreCase);
                ci.ChapterNo = mp.Groups["No"].Value.ToTryInt();
                list.Add(ci);
            }
            return list;
        }
    }
}
