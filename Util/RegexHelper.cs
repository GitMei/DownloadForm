using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace yoedgeForm.Util
{
    public static  class RegexHelper
    {
        /// <summary>
        /// 检查网址是否符合
        /// </summary>
        /// <param name="url">检测的网址</param>
        /// <returns>检测结果 true/false</returns>
        public static bool CheckUrl(string url) {
            string pattern = "^http://smp\\d?.yoedge.com/";
            var re = Regex.Match(url, pattern);
            return re.Success;
        }
    }
}
