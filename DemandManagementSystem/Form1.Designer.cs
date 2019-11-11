namespace DemandManagementSystem
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
            this.userLable = new DevExpress.XtraEditors.LabelControl();
            this.passLable = new DevExpress.XtraEditors.LabelControl();
            this.userText = new DevExpress.XtraEditors.TextEdit();
            this.passText = new DevExpress.XtraEditors.TextEdit();
            this.projectLable = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.userText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // userLable
            // 
            this.userLable.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userLable.Location = new System.Drawing.Point(26, 22);
            this.userLable.Name = "userLable";
            this.userLable.Size = new System.Drawing.Size(31, 17);
            this.userLable.TabIndex = 0;
            this.userLable.Text = "用 户:";
            // 
            // passLable
            // 
            this.passLable.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passLable.Location = new System.Drawing.Point(26, 56);
            this.passLable.Name = "passLable";
            this.passLable.Size = new System.Drawing.Size(31, 17);
            this.passLable.TabIndex = 1;
            this.passLable.Text = "密 码:";
            // 
            // userText
            // 
            this.userText.Location = new System.Drawing.Point(82, 20);
            this.userText.Name = "userText";
            this.userText.Size = new System.Drawing.Size(163, 20);
            this.userText.TabIndex = 2;
            this.userText.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.userText_PreviewKeyDown);
            // 
            // passText
            // 
            this.passText.Location = new System.Drawing.Point(82, 54);
            this.passText.Name = "passText";
            this.passText.Size = new System.Drawing.Size(163, 20);
            this.passText.TabIndex = 3;
            this.passText.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.passText_PreviewKeyDown);
            // 
            // projectLable
            // 
            this.projectLable.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.projectLable.Location = new System.Drawing.Point(26, 91);
            this.projectLable.Name = "projectLable";
            this.projectLable.Size = new System.Drawing.Size(31, 17);
            this.projectLable.TabIndex = 4;
            this.projectLable.Text = "项 目:";
            // 
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Location = new System.Drawing.Point(82, 89);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Size = new System.Drawing.Size(163, 20);
            this.comboBoxEdit1.TabIndex = 6;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(154, 124);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(91, 23);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "登录";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(24, 126);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "记住密码";
            this.checkEdit1.Size = new System.Drawing.Size(75, 19);
            this.checkEdit1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 167);
            this.Controls.Add(this.checkEdit1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.projectLable);
            this.Controls.Add(this.passText);
            this.Controls.Add(this.userText);
            this.Controls.Add(this.passLable);
            this.Controls.Add(this.userLable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Office 2010 Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "需求管理系统v1.0.0.1";
            ((System.ComponentModel.ISupportInitialize)(this.userText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl userLable;
        private DevExpress.XtraEditors.LabelControl passLable;
        private DevExpress.XtraEditors.TextEdit userText;
        private DevExpress.XtraEditors.TextEdit passText;
        private DevExpress.XtraEditors.LabelControl projectLable;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;

    }
}

