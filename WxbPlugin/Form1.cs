using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WxbPlugin
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            ClearTabControlPages();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ribbonControl1.Minimized = true;
        }
        private void ClearTabControlPages()
        {
            if (xtraTabControl1.TabPages.Count > 0)
            {
                for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                {
                    this.xtraTabControl1.TabPages.RemoveAt(i);
                }
                ClearTabControlPages();
            }
        }

        private void ribbonControl1_DoubleClick(object sender, EventArgs e)
        {

        }




    }
}
