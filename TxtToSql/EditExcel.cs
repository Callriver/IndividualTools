
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtToSql
{
    class EditExcel
    {
        /// <summary>
        /// 打开excel文档
        /// </summary>
        /// <param name="filename">文件名称</param>
        /// <returns></returns>
        public static bool Open(string filename)
        {
            try
            {
                object missing = System.Reflection.Missing.Value;
                Application myExcel = new Application();//引用Excel对象
                myExcel.Application.Workbooks.Open(filename, missing, missing,
                    missing, missing, missing, missing, missing, missing,
                    missing, missing, missing, missing, missing, missing);
                myExcel.Application.Workbooks.Add(filename);
                myExcel.Visible = true;//设置Excel为可见  
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
