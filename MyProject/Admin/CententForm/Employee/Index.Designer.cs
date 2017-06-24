using System.Windows.Forms;

namespace MyProject.Admin.CententForm.Employee
{
    partial class Index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.panel1 = new System.Windows.Forms.Panel();
            this.addEmployee = new System.Windows.Forms.LinkLabel();
            this.department = new System.Windows.Forms.LinkLabel();
            this.applicants = new System.Windows.Forms.LinkLabel();
            this.personDemand = new System.Windows.Forms.LinkLabel();
            this.information = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.addEmployee);
            this.panel1.Controls.Add(this.department);
            this.panel1.Controls.Add(this.applicants);
            this.panel1.Controls.Add(this.personDemand);
            this.panel1.Controls.Add(this.information);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Location = new System.Drawing.Point(42, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 191);
            this.panel1.TabIndex = 1;
            // 
            // addEmployee
            // 
            this.addEmployee.AutoSize = true;
            this.addEmployee.Location = new System.Drawing.Point(177, 125);
            this.addEmployee.Name = "addEmployee";
            this.addEmployee.Size = new System.Drawing.Size(65, 12);
            this.addEmployee.TabIndex = 2;
            this.addEmployee.TabStop = true;
            this.addEmployee.Text = "添加新员工";
            // 
            // department
            // 
            this.department.AutoSize = true;
            this.department.Location = new System.Drawing.Point(177, 90);
            this.department.Name = "department";
            this.department.Size = new System.Drawing.Size(53, 12);
            this.department.TabIndex = 2;
            this.department.TabStop = true;
            this.department.Text = "部门管理";
            // 
            // applicants
            // 
            this.applicants.AutoSize = true;
            this.applicants.Location = new System.Drawing.Point(30, 160);
            this.applicants.Name = "applicants";
            this.applicants.Size = new System.Drawing.Size(65, 12);
            this.applicants.TabIndex = 2;
            this.applicants.TabStop = true;
            this.applicants.Text = "应聘者信息";
            // 
            // personDemand
            // 
            this.personDemand.AutoSize = true;
            this.personDemand.Location = new System.Drawing.Point(30, 125);
            this.personDemand.Name = "personDemand";
            this.personDemand.Size = new System.Drawing.Size(53, 12);
            this.personDemand.TabIndex = 2;
            this.personDemand.TabStop = true;
            this.personDemand.Text = "需求信息";
            // 
            // information
            // 
            this.information.AutoSize = true;
            this.information.Location = new System.Drawing.Point(30, 90);
            this.information.Name = "information";
            this.information.Size = new System.Drawing.Size(77, 12);
            this.information.TabIndex = 2;
            this.information.TabStop = true;
            this.information.Text = "员工信息查询";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("楷体", 30F);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Lime;
            this.linkLabel1.Location = new System.Drawing.Point(65, 28);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(177, 40);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "人员管理";
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1579, 801);
            this.Controls.Add(this.panel1);
            this.Name = "Index";
            this.Text = "Index";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel addEmployee;
        private System.Windows.Forms.LinkLabel department;
        private System.Windows.Forms.LinkLabel applicants;
        private System.Windows.Forms.LinkLabel personDemand;
        private System.Windows.Forms.LinkLabel information;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;

        public LinkLabel Applicants { get => applicants; set => applicants = value; }
    }
}