namespace MyProject.Admin.CententForm.Employee
{
    partial class Information
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
            this.tableLable = new System.Windows.Forms.Label();
            this.departmentS = new System.Windows.Forms.Label();
            this.D_NameID = new System.Windows.Forms.ComboBox();
            this.title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.E_ID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Name = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.P_NameID = new System.Windows.Forms.ComboBox();
            this.query = new System.Windows.Forms.Button();
            this.pageUp = new System.Windows.Forms.LinkLabel();
            this.page = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.allPage = new System.Windows.Forms.Label();
            this.pageDown = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLable
            // 
            this.tableLable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.tableLable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLable.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold);
            this.tableLable.Location = new System.Drawing.Point(104, 200);
            this.tableLable.Name = "tableLable";
            this.tableLable.Size = new System.Drawing.Size(100, 30);
            this.tableLable.TabIndex = 0;
            this.tableLable.Text = "姓名";
            this.tableLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // departmentS
            // 
            this.departmentS.AutoSize = true;
            this.departmentS.Font = new System.Drawing.Font("黑体", 12F);
            this.departmentS.Location = new System.Drawing.Point(45, 118);
            this.departmentS.Name = "departmentS";
            this.departmentS.Size = new System.Drawing.Size(112, 16);
            this.departmentS.TabIndex = 0;
            this.departmentS.Text = "部门名称/编号";
            // 
            // D_NameID
            // 
            this.D_NameID.FormattingEnabled = true;
            this.D_NameID.Location = new System.Drawing.Point(163, 114);
            this.D_NameID.Name = "D_NameID";
            this.D_NameID.Size = new System.Drawing.Size(122, 20);
            this.D_NameID.TabIndex = 1;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("黑体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.Location = new System.Drawing.Point(451, 22);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(360, 56);
            this.title.TabIndex = 2;
            this.title.Text = "员工信息查询";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F);
            this.label1.Location = new System.Drawing.Point(341, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "员工编号";
            // 
            // E_ID
            // 
            this.E_ID.FormattingEnabled = true;
            this.E_ID.Location = new System.Drawing.Point(419, 114);
            this.E_ID.Name = "E_ID";
            this.E_ID.Size = new System.Drawing.Size(122, 20);
            this.E_ID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F);
            this.label2.Location = new System.Drawing.Point(597, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "员工姓名";
            // 
            // E_Name
            // 
            this.E_Name.FormattingEnabled = true;
            this.E_Name.Location = new System.Drawing.Point(675, 114);
            this.E_Name.Name = "E_Name";
            this.E_Name.Size = new System.Drawing.Size(122, 20);
            this.E_Name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12F);
            this.label3.Location = new System.Drawing.Point(853, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "职位";
            // 
            // P_NameID
            // 
            this.P_NameID.FormattingEnabled = true;
            this.P_NameID.Location = new System.Drawing.Point(899, 114);
            this.P_NameID.Name = "P_NameID";
            this.P_NameID.Size = new System.Drawing.Size(122, 20);
            this.P_NameID.TabIndex = 1;
            // 
            // query
            // 
            this.query.Location = new System.Drawing.Point(1058, 111);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(75, 23);
            this.query.TabIndex = 3;
            this.query.Text = "查询";
            this.query.UseVisualStyleBackColor = true;
            // 
            // pageUp
            // 
            this.pageUp.AutoSize = true;
            this.pageUp.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pageUp.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.pageUp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pageUp.Location = new System.Drawing.Point(3, 12);
            this.pageUp.Name = "pageUp";
            this.pageUp.Size = new System.Drawing.Size(66, 19);
            this.pageUp.TabIndex = 4;
            this.pageUp.TabStop = true;
            this.pageUp.Text = "上一页";
            // 
            // page
            // 
            this.page.AutoSize = true;
            this.page.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.page.Location = new System.Drawing.Point(153, 15);
            this.page.Name = "page";
            this.page.Size = new System.Drawing.Size(16, 16);
            this.page.TabIndex = 5;
            this.page.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(169, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "/";
            // 
            // allPage
            // 
            this.allPage.AutoSize = true;
            this.allPage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.allPage.Location = new System.Drawing.Point(188, 15);
            this.allPage.Name = "allPage";
            this.allPage.Size = new System.Drawing.Size(16, 16);
            this.allPage.TabIndex = 7;
            this.allPage.Text = "1";
            // 
            // pageDown
            // 
            this.pageDown.AutoSize = true;
            this.pageDown.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pageDown.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.pageDown.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pageDown.Location = new System.Drawing.Point(288, 12);
            this.pageDown.Name = "pageDown";
            this.pageDown.Size = new System.Drawing.Size(66, 19);
            this.pageDown.TabIndex = 4;
            this.pageDown.TabStop = true;
            this.pageDown.Text = "下一页";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(26, 155);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 473);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pageDown);
            this.panel2.Controls.Add(this.page);
            this.panel2.Controls.Add(this.allPage);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pageUp);
            this.panel2.Location = new System.Drawing.Point(353, 405);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 38);
            this.panel2.TabIndex = 8;
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1140, 635);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.query);
            this.Controls.Add(this.title);
            this.Controls.Add(this.P_NameID);
            this.Controls.Add(this.E_Name);
            this.Controls.Add(this.E_ID);
            this.Controls.Add(this.D_NameID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.departmentS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Information";
            this.Text = "Information";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label tableLable;
        private System.Windows.Forms.Label departmentS;
        private System.Windows.Forms.ComboBox D_NameID;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox E_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox E_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox P_NameID;
        private System.Windows.Forms.Button query;
        private System.Windows.Forms.LinkLabel pageUp;
        private System.Windows.Forms.Label page;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label allPage;
        private System.Windows.Forms.LinkLabel pageDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}