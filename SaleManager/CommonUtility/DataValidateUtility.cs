using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace CommonUtility
{
    /// <summary>
    /// 通用验证类
    /// </summary>
    public class DataValidateUtility
    {
        /// <summary>
        /// 验证正整数
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsInteger(string txt)
        {
            Regex objReg = new Regex(@"^[1-9]\d*$");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 验证是否是Email
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsEmail(string txt)
        {
            Regex objReg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 验证身份证
        /// 1.校验生日
        /// 2.校验最后一位（校验和）
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsIdentityCard(string txt)
        {
            Regex objReg = new Regex(@"^(\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$");
            string birthday = string.Empty;
            if (!objReg.IsMatch(txt))
            {
                return false;
            }

            if (txt.Length == 15)
            {
                //取生日
                birthday = "19" + txt.Substring(7, 6);
                return IsDate(birthday);
            }
            else if (txt.Length == 18)
            {
                //取生日
                birthday = txt.Substring(6, 8);
                if (IsDate(birthday))
                {
                    // 校验表
                    int[] check = { 7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2 };
                    char[] checkSum = { '1', '0', 'X', '9', '8', '7', '6', '5', '4', '3', '2' };
                    // 校验源
                    string checkSource = txt.Substring(0, 17);
                    // 校验源转换成数字
                    List<int> source = new List<int>();
                    for (int i = 0; i < checkSource.Length; i++)
                    {
                        source.Add(Convert.ToInt32(checkSource.Substring(i, 1)));
                    }
                    // 校验源的校验和
                    string checkLast = txt.Substring(17);
                    int sum = 0;
                    // 对应项求积，再把所有积求和
                    for (int i = 0; i < source.Count; i++)
                    {
                        sum += source[i] * check[i];
                    }
                    // 取余
                    int remainder = sum % 11;
                    if (string.Equals(checkLast, checkSum[remainder].ToString()))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// 匹配格式：
        /// 11位手机号码
        /// 3-4位区号，7-8位直播号码，1－4位分机号
        /// 如：12345678901、1234-12345678-1234
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string txt)
        {
            Regex objReg = new Regex(@"((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)");
            return objReg.IsMatch(txt);
        }
        /// <summary>
        /// 可匹配
        /// yyyyMMdd
        /// yyyy-MM-dd
        /// yyyy/MM/dd
        /// yyyy.MM.dd
        /// yyyy_MM_dd
        /// 且能过滤闰年
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool IsDate(string txt)
        {
            Regex objReg = new Regex(@"((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._]?)(10|12|0?[13578])([-\/\._]?)(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._]?)(11|0?[469])([-\/\._]?)(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._]?)(0?2)([-\/\._]?)(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([3579][26]00)([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([1][89][0][48])([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([2-9][0-9][0][48])([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([1][89][2468][048])([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([2-9][0-9][2468][048])([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([1][89][13579][26])([-\/\._]?)(0?2)([-\/\._]?)(29)$)|(^([2-9][0-9][13579][26])([-\/\._]?)(0?2)([-\/\._]?)(29)$))");
            return objReg.IsMatch(txt);
        }
    }
}
