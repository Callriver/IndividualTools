namespace FieldComparisonUtil
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.memoEdit3 = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(12, 30);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(82, 190);
            this.memoEdit1.TabIndex = 0;
            this.memoEdit1.UseOptimizedRendering = true;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "数据字典:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(120, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "现表:";
            // 
            // memoEdit2
            // 
            this.memoEdit2.Location = new System.Drawing.Point(120, 30);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Size = new System.Drawing.Size(82, 190);
            this.memoEdit2.TabIndex = 3;
            this.memoEdit2.UseOptimizedRendering = true;
            // 
            // memoEdit3
            // 
            this.memoEdit3.Location = new System.Drawing.Point(228, 30);
            this.memoEdit3.Name = "memoEdit3";
            this.memoEdit3.Size = new System.Drawing.Size(82, 150);
            this.memoEdit3.TabIndex = 4;
            this.memoEdit3.UseOptimizedRendering = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(228, 194);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(82, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "比较差异";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 229);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.memoEdit3);
            this.Controls.Add(this.memoEdit2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.memoEdit1);
            this.LookAndFeel.SkinName = "Visual Studio 2013 Light";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Form1";
            this.Text = "表结构差异比较工具";
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit3.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraEditors.MemoEdit memoEdit3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;

    }
}

