using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility
{
    public class NumericUtility
    {
        /// <summary>
        /// 把小数转换为带分号的，两位小数的字符串
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string ToMoneyFormat(double number)
        {
            return string.Format("{0:N}", number);
        }
    }
}
