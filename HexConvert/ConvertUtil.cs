using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexConvert
{
    class ConvertUtil
    {
        /// <summary>
        /// 十六进制单字符转10进制数
        /// </summary>
        /// <param name="hexChar"></param>
        /// <returns></returns>
        public static int HexCharToValue(string hexChar)
        {
            switch (hexChar)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    return Convert.ToInt32(hexChar);
                case "a":
                case "A":
                    return 10;
                case "b":
                case "B":
                    return 11;
                case "c":
                case "C":
                    return 12;
                case "d":
                case "D":
                    return 13;
                case "e":
                case "E":
                    return 14;
                case "f":
                case "F":
                    return 15;
                default:
                    return 0;
            }
        }
        /// <summary>
        /// 返回转换后的数据
        /// </summary>
        /// <param name="HexStr"></param>
        /// <returns></returns>
        public static string HexStrToTen(string HexStr)
        {
            int ten = 0;
            for (int i = 0, j = HexStr.Length - 1; i < HexStr.Length; i++)
            {
                ten += HexCharToValue(HexStr.Substring(i, 1)) * ((int)Math.Pow(16, j));
                j--;
            }
            return ten.ToString();
        }
    }
}
