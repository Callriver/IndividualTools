using DevExpress.XtraEditors;
using Oracle.ManagedDataAccess.Client;
using Rxsoft.Util.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PropertyMaintenance
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        //连接字符串
        private string connectionString = "User Id=wfyerp;Password=wfyerp;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=47.104.131.48)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)))";
        List<string> xtwpksList = new List<string>();
        List<string> xtwpdmList = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sxlbdm = textEdit1.Text.Trim();
            string xtwpsx = textEdit2.Text.Trim();
            int successCount = 0;
            int failuresNumber = 0;
            Dictionary<string,string[]> updateDictionary=new Dictionary<string,string[]>();
            Dictionary<string, string[]> inserteDictionary = new Dictionary<string, string[]>();
            List<string> updateList = new List<string>();
            List<string> insertList = new List<string>();
            //1.清空原始数据
            xtwpksList.Clear();
            xtwpdmList.Clear();
            //2.获取款号集合
            xtwpksList = getKuanhao();
            //3.遍历添加
            foreach (string item in xtwpksList)
            {
               xtwpdmList.AddRange(getWpdmByKuanhao(item));
            }
            //4.遍历物品代码集合开始数据处理
            foreach (string xtwpdm in xtwpdmList)
            {
                bool isExists = findShuxingByXtwpdm(xtwpdm, sxlbdm);
                if (isExists)
                {
                    //执行update操作
                    int i = updateWpsx(xtwpdm, sxlbdm, xtwpsx);
                    if (i == 1)
                    {
                        successCount++;
                    }
                    else
                    {
                        failuresNumber++;
                    }


                    //构造更新的list集合
                    //updateList.Add(xtwpdm);
                }
                else
                {
                    //执行insert操作
                    int i = insertWpsx(xtwpdm, sxlbdm, xtwpsx);
                    if (i==1)
                    {
                        successCount++;
                    }
                    else
                    {
                        failuresNumber++;
                    }

                }
            }

            //6.提示
            XtraMessageBox.Show("成功操作:"+successCount+"条记录,失败操作:"+failuresNumber+"条记录");
        }
        /// <summary>
        /// 根据多行文本框取到款号集合
        /// </summary>
        /// <returns></returns>
        private List<string> getKuanhao()
        {
            List<string> list = new List<string>();//临时集合
            List<string> kuanhao = new List<string>();//款号集合
            if (memoEdit1.Text == null || memoEdit1.Text.Equals(""))
            {
                XtraMessageBox.Show("款号不能为空");
            }
            else if (textEdit1.Text == null || textEdit1.Text.Equals(""))
            {
                XtraMessageBox.Show("属性类别代码不能为空");
            }
            else if (textEdit2.Text == null || textEdit2.Text.Equals(""))
            {
                XtraMessageBox.Show("属性值代码不能为空");
            }
            else
            {
                //清空集合
                kuanhao.Clear();

                //把memoEdit的每行的值分别放入list集合
                kuanhao.AddRange(memoEdit1.Lines.ToList());
            }
            //循环遍历取list中有用的值到kuanhao集合
            foreach (string item in list)
            {
                if (item != null && item != "")
                {
                    kuanhao.Add(item.Trim());
                }
            }
            return kuanhao;
        }
        /// <summary>
        /// 按一个款号获取到对应款物品代码
        /// </summary>
        /// <param name="xtwpks"></param>
        /// <returns></returns>
        private List<string> getWpdmByKuanhao(string xtwpks){
            string sql = "select xtwpdm from xtm12 where xtwpks=:xtwpks";
            OracleParameter[] prams = new OracleParameter[1];
            prams[0] = new OracleParameter(":xtwpks",xtwpks);
            //获得datatable结果集
            DataTable result=OracleHelper.ExecuteDataTable(connectionString,CommandType.Text,sql,prams);
            List<string>xtwpdm=new List<string>();
            //遍历每行,将物品代码放入物品代码集合
            foreach (DataRow row in result.Rows)
            {
                xtwpdm.Add(row["xtwpdm"].ToString());
            }
            return xtwpdm;
        }
        /// <summary>
        /// 根据物品代码和属性类别查找是该物品是否有该属性
        /// </summary>
        /// <param name="xtwpdm"></param>
        /// <returns></returns>
        private bool findShuxingByXtwpdm(string xtwpdm,string sxlbdm) {
            string sql = "select 1 from xtm12_6 where xtwpdm=:xtwpdm and sxlbdm=:sxlbdm";
            OracleParameter[] prams = new OracleParameter[2];
            prams[0] = new OracleParameter(":xtwpdm", xtwpdm);
            prams[1] = new OracleParameter(":sxlbdm", sxlbdm);
            object result = OracleHelper.ExecuteScalar(connectionString,CommandType.Text,sql,prams);
            if (result!=null && result.ToString()=="1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 单条更新属性
        /// </summary>
        private int updateWpsx(string xtwpdm, string sxlbdm, string xtwpsx)
        {
            string sql = "update xtm12_6 set xtwpsx=:xtwpsx where xtwpdm=:xtwpdm and sxlbdm=:sxlbdm and exists(select * from xtm12_5 where sxlbdm=:sxlbdm and sxsxdm=:xtwpsx)";
            OracleParameter[] prams = new OracleParameter[5];
            prams[0] = new OracleParameter(":xtwpsx", xtwpsx);
            prams[1] = new OracleParameter(":xtwpdm", xtwpdm);
            prams[2] = new OracleParameter(":sxlbdm", sxlbdm);
            prams[3] = new OracleParameter(":sxlbdm", sxlbdm);
            prams[4] = new OracleParameter(":xtwpsx", xtwpsx);
            int i=OracleHelper.ExecuteNonQuery(connectionString,CommandType.Text,sql,prams);
            return i;
        }
        /// <summary>
        /// 单条插入属性
        /// </summary>
        /// <returns></returns>
        private int insertWpsx(string xtwpdm, string sxlbdm, string xtwpsx)
        {
            string sql = "insert into xtm12_6 values(:sxlbdm,:xtwpdm,:xtwpsx)";
            OracleParameter[] prams = new OracleParameter[3];
            prams[0] = new OracleParameter(":sxlbdm", sxlbdm);
            prams[1] = new OracleParameter(":xtwpdm", xtwpdm);
            prams[2] = new OracleParameter(":xtwpsx", xtwpsx);
            int i = OracleHelper.ExecuteNonQuery(connectionString, CommandType.Text, sql, prams);
            return i;
        }
        /// <summary>
        /// 批量插入物品属性
        /// </summary>
        /// <param name="xtwpdm"></param>
        /// <param name="sxlbdm"></param>
        /// <param name="xtwpsx"></param>
        /// <returns></returns>
        private int plInsertWpsx(List<string>xtwpdm, List<string> sxlbdm, List<string> xtwpsx)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("xtwpdm", xtwpdm.ToArray());
            dictionary.Add("sxlbdm", sxlbdm.ToArray());
            dictionary.Add("xtwpsx", xtwpsx.ToArray());
            return OracleHelper.BatchInsert("xtm12_6", dictionary,connectionString,500);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //主界面加载后Oracle数据库初始化
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            connectionString = textEdit3.Text.Trim();
            XtraMessageBox.Show("数据库连接方式设置成功");
        }
    }
}
