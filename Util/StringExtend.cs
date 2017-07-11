using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yoedgeForm.Util
{
    public static class StringExtend
    {
        /// <summary>
        /// 字符串转数字,失败返回0
        /// </summary>
        /// <param name="str">需要</param>
        /// <returns></returns>
        public static int ToTryInt(this string str)
        {
            int result = 0;
            if (int.TryParse(str,out result))
            {
                return result;
            }
            return result;
        }

        public static string GetFileName(this string str)
        {
            int index = str.LastIndexOf("/");
            return str.Substring(index + 1, str.Length - index - 1);
        }
    }
}
