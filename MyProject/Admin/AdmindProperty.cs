using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using MyProject.Admin.NavPanel;
using MyProject.Admin.CententForm;

using AutoSize_Form;

namespace MyProject.Admin
{
    public class AdmindProperty : Form
    {

        /// <summary>
        /// 
        /// Main窗体的布局
        /// 
        /// </summary>
        
        NavMenu NM1 = new NavMenu();
        Label logo = new Label();
        Panel panelNav = new Panel();
        Panel panelCentent = new Panel();
        LinkLabel[] navLabel = new LinkLabel[10];

        MyResize mr;

        BaseInformation baseFrm = new BaseInformation();
        MyProject.Admin.CententForm.Employee.Index personFrm = new CententForm.Employee.Index();
        MyProject.Admin.CententForm.Employee.Information personInformation = new CententForm.Employee.Information();
        MyProject.Admin.CententForm.Employee.Department personDepartment = new CententForm.Employee.Department();


        public Panel PanelCentent
        {
            set { panelCentent = value; }
            get { return panelCentent; }
        }


        public void FrmAdmin()
        {
            this.Size = new Size(1366,768);
            this.CenterToScreen();

            this.Text = "后台管理系统";
            this.ShowIcon = false;
            this.Load += BaseTool_Click;
            //this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            mr = new MyResize(this);
            try
            {
                this.SizeChanged += FrmMaxChange_Click;
            }
            catch
            {
                TitelFont(logo);
            }
        }

        private void FrmMaxChange_Click(object sender,EventArgs e)   //窗口大小改变，界面、控件大小也一起改变
        {
            mr.ResizeFrm(this);
            int point_y =(int)(panelNav.Height * 0.02);
            logo.Size = new Size(this.Width, (int)((this.Height) * 0.065));
            try
            {
                logo.Font = new Font("楷体", (int)((this.Height) * 0.02888));
            }
            catch
            {
                TitelFont(logo);
            }
            panelNav.Size = new Size(203, this.Height);
            panelNav.Location = new Point(0,logo.Height);
            /*for (int i = 0; i < navLabel.Length; i++)
            {
                navLabel[i].Location = new Point(30, point_y += 40);
            }
            */
            NM1.panel1.Size = new Size(183, panelNav.Height - 150);
            NM1.panel2.Size = new Size(165, NM1.panel2.Height);
            panelCentent.Size = new Size(this.Width-205,this.Height);
            panelCentent.Location = new Point(203, logo.Height);
            baseFrm.Size = panelCentent.Size;
            personFrm.Size = panelCentent.Size;
            personInformation.Size = panelCentent.Size;
            personDepartment.Size = panelCentent.Size;
        }

        private void TopLOGO()
        {
            logo.Size = new Size(this.Width,(int)((this.Height) * 0.065));
            logo.BackColor = Color.FromArgb(255,0,174,255);
            logo.Location = new Point(0,0);
            logo.TextAlign = ContentAlignment.MiddleLeft;
            logo.Text = "欢迎使用，XX后台管理系统";
            TitelFont(logo);
            this.Controls.Add(logo);
        }    //顶部标签


        private void LeftNav()
        {
            PanelProperty();
            NavLabelProperty();
            
            


        }    //左侧的导航栏

        private void PanelProperty()
        {
            panelNav.BackColor = Color.FromArgb(255, 0, 96, 255);
            panelNav.Size = new Size(203, (int)(this.Height)/* - logo.Height)*/);
            panelNav.Location = new Point(0, logo.Height);
            panelNav.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panelNav);

            panelCentent.BackColor = Color.FromArgb(255,200,200,200);
            panelCentent.Size = new Size(1600 - 205, this.Height);
            panelCentent.Location = new Point(173,logo.Height);
            panelCentent.BorderStyle = BorderStyle.FixedSingle;
            panelCentent.AutoScroll = true;
            this.Controls.Add(panelCentent);
        }   //panelNav、penelCentent的属性


        private void NavLabelProperty()
        {
            baseFrm = new BaseInformation();
            personFrm = new CententForm.Employee.Index();
            NM1.TopLevel = false;
            NM1.FormBorderStyle = FormBorderStyle.None;
            panelNav.Controls.Add(NM1);
            NM1.Size = new Size(203,1100);
            NM1.panel1.Size = new Size(183, 650);
            NM1.panel2.Size = new Size(165, NM1.panel2.Height);
            NM1.BaseTool.Click += BaseTool_Click;
            NM1.PersonTool.Click += PersonIndex_Click;
            NM1.PersonInformation.Click += PersonInformation_Click;
            NM1.PersonDepartment.Click += PersonDepartment_Click;
            NM1.PersonAddEmployee.Click += PersonAddEmployee_Click;
            NM1.PersonDemand.Click += PersonDemand_Click;
            NM1.PersonApplicants.Click += PersonApplicants;
            NM1.Applicants.Click += PersonApplicants;

            baseFrm.Person.Click += PersonIndex_Click;
            baseFrm.PersonInformation.Click += PersonInformation_Click;
            baseFrm.PersonDepartment.Click += PersonDepartment_Click;
            baseFrm.AddEmployee.Click += PersonAddEmployee_Click;
            baseFrm.PersonDemand.Click += PersonDemand_Click;
            baseFrm.Applicants.Click += PersonApplicants;


            personFrm.Information.Click += PersonInformation_Click;
            personFrm.Department.Click += PersonDepartment_Click;
            personFrm.AddEmployee.Click += PersonAddEmployee_Click;
            personFrm.PersonDemand.Click += PersonDemand_Click;
            personFrm.Applicants.Click += PersonApplicants;


            NM1.Show();



        }      //导航属性

        private void BaseTool_Click(object sender, EventArgs e)    //显示首页
        {
            //throw new NotImplementedException();
            TopLOGO();                  //窗口顶部的LOGO
            LeftNav();                  //左侧的导航栏
            foreach (Control a in panelCentent.Controls)
            {
                panelCentent.Controls.Remove(a);
            }
            baseFrm.TopLevel = false;
            panelCentent.Controls.Add(baseFrm);
            baseFrm.Show();
        }

        public void PersonIndex_Click(object sender, EventArgs e)    //链接到员工管理系统的首页
        {
            
            personFrm.TopLevel = false;
            foreach (Control a in panelCentent.Controls)
            {
                panelCentent.Controls.Remove(a);
            }
            panelCentent.Controls.Add(personFrm);
            personFrm.Show();
        }

        public void PersonInformation_Click(object sender, EventArgs e)  //链接到员工信息查询
        {
            personInformation = new CententForm.Employee.Information();
            personInformation.Size = panelCentent.Size;
            personInformation.TopLevel = false;
            foreach (Control a in panelCentent.Controls)
            {
                panelCentent.Controls.Remove(a);
            }
            panelCentent.Controls.Add(personInformation);
            
            personInformation.Show();
            this.MaximizeBox = true;
        }

        private void PersonDepartment_Click(object sender, EventArgs e)//链接到部门管理界面
        {
            personDepartment = new CententForm.Employee.Department();
            personDepartment.Size = panelCentent.Size;
            personDepartment.TopLevel = false;
            foreach (Control a in panelCentent.Controls)
            {
                panelCentent.Controls.Remove(a);
            }
            panelCentent.Controls.Add(personDepartment);
            personDepartment.Show();
            this.MaximizeBox = false;
        }

        private void PersonAddEmployee_Click(object sender, EventArgs e)  //打开添加员工的窗口
        {
            CententForm.Employee.WinForm.AddEmployee addemployee = new CententForm.Employee.WinForm.AddEmployee();
            addemployee.ShowDialog();
        }

        private void PersonDemand_Click(object sender, EventArgs e)//链接到需求管理的窗口
        {
            panelCentent.Controls.Clear();
            CententForm.Employee.Demand demand = new CententForm.Employee.Demand();
            demand.TopLevel = false;
            panelCentent.Controls.Add(demand);
           demand.Show();
            this.MaximizeBox = false;
        }


        private void PersonApplicants(object sender, EventArgs e)  //链接到应聘者查询窗口
        {
            panelCentent.Controls.Clear();
            CententForm.Employee.Applicants applicants = new CententForm.Employee.Applicants();
            applicants.TopLevel = false;
            panelCentent.Controls.Add(applicants);
            applicants.Show();
            this.MaximizeBox = false;
        }

        private void NavFont(Control c)
        {
            //c.ForeColor = Color.FromArgb(255, 250, 0, 0);
            c.Font = new Font("宋体",10 ,FontStyle.Bold);
            
        }
        private void TitelFont(Control s)
        {
            s.Font = new Font("楷体",24);
        }    //标题字体
    }
}
