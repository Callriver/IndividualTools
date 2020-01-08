using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GbCodeInspection;
using System.Net;
using System.IO;

namespace GbCodeInspection
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //国标码集合
            List<string> list = null;
            string result = "";
            //把memoedit内容转为list
            if (memoEdit1.Text!=null||memoEdit1.Text!="")
            {
                list = memoEdit1.Lines.ToList();
            }
            else
            {
                XtraMessageBox.Show("国标码不能为空");
            }
            //循环调用
            foreach (string item in list)
            {
                //RestClient client = new RestClient("http://www.sptxm.com/?s="+item);
                //string result =  client.Get("api/Values");
                string serviceAddress = "http://www.sptxm.com/?s=" + item;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                if (retString.Contains("无效的商品条形码，请核对您的输入"))
                {
                    result = result + "\r" + item;
                }
            }
            //输出
            memoEdit2.Text = "";
            memoEdit2.Text = result;
        }
    }
}
