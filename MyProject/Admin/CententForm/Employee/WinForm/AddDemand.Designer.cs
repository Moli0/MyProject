namespace MyProject.Admin.CententForm.Employee.WinForm
{
    partial class AddDemand
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
            this.label1 = new System.Windows.Forms.Label();
            this.department_ID = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.post = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rec_Number = new System.Windows.Forms.TextBox();
            this.explain = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部门编号";
            // 
            // department_ID
            // 
            this.department_ID.FormattingEnabled = true;
            this.department_ID.Location = new System.Drawing.Point(110, 21);
            this.department_ID.Name = "department_ID";
            this.department_ID.Size = new System.Drawing.Size(121, 20);
            this.department_ID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "职位";
            // 
            // post
            // 
            this.post.FormattingEnabled = true;
            this.post.Location = new System.Drawing.Point(110, 65);
            this.post.Name = "post";
            this.post.Size = new System.Drawing.Size(121, 20);
            this.post.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "招聘人数";
            // 
            // rec_Number
            // 
            this.rec_Number.Location = new System.Drawing.Point(110, 109);
            this.rec_Number.Name = "rec_Number";
            this.rec_Number.Size = new System.Drawing.Size(121, 21);
            this.rec_Number.TabIndex = 2;
            // 
            // explain
            // 
            this.explain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.explain.ForeColor = System.Drawing.SystemColors.GrayText;
            this.explain.Location = new System.Drawing.Point(259, 18);
            this.explain.Multiline = true;
            this.explain.Name = "explain";
            this.explain.Size = new System.Drawing.Size(443, 111);
            this.explain.TabIndex = 3;
            this.explain.Text = "详细说明（不超过120字）";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(526, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "完成";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(627, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AddDemand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(717, 177);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.explain);
            this.Controls.Add(this.rec_Number);
            this.Controls.Add(this.post);
            this.Controls.Add(this.department_ID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddDemand";
            this.ShowIcon = false;
            this.Text = "添加新的需求信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox department_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox post;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rec_Number;
        private System.Windows.Forms.TextBox explain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}