using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace MyProject.Admin.CententForm.Employee.WinForm
{ 
    public partial class AddEmployee : Form
    {

        public AddEmployee()
        {
            InitializeComponent();
            this.Load += Frm_Load;
            this.IDCard.Leave += ID_Check;
            this.department_ID.Leave += comboBox_Check;
            this.employee_ID.Leave += comboBox_Check;
            this.sex.Leave += comboBox_Check;
            this.post.Leave += comboBox_Check;
            this.confirm.Click += Confirm_Click;
            //this.Load += new Load_Data()
        }

        private void Frm_Load(object sender,EventArgs e)//加载ComboBox的一些选项
        {
            LinkSQL linksql = new LinkSQL();        //创建数据库连接对象
            System.Data.SqlClient.SqlDataReader RD;     //创建一个对像接收查询的返回数据
            linksql.OpenSQL();          //打开数据库
            linksql.SQLSelect(@"select ID from department");        //查询部门编号
            RD = linksql.Comm.ExecuteReader();
            while (RD.Read())
            {
                department_ID.Items.Add(Convert.ToString(RD[0]));         //将查询的结果添加到department_ID上
            }

            sex.Items.Add("男");
            sex.Items.Add("女");
            linksql.CloseSQL();     //关闭数据库
            linksql.OpenSQL();          //打开数据库
            linksql.SQLSelect(@"select name from post");        //查询职位
            RD = linksql.Comm.ExecuteReader();
            while (RD.Read())
            {
                post.Items.Add(Convert.ToString(RD[0]));         //将查询的结果添加到post上
            }
            
            linksql.CloseSQL();     //关闭数据库
        }
        private void comboBox_Check(object sender, EventArgs e)  //检查输入的数据有效性，光标离开时自动触发
        {
            LinkSQL linksql = new LinkSQL();
            ComboBox comboxBox1 = (ComboBox)sender;
            int i;
            switch (comboxBox1.Name)
            {
                case "department_ID":
                    linksql.OpenSQL();
                    linksql.SQLSelect(@"select count(*) from department where ID = '" + department_ID.Text + "'");
                    i = int.Parse(linksql.Comm.ExecuteScalar().ToString());
                    if (i != 1)
                    {
                        MessageBox.Show("输入的部门不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        department_ID.SelectAll();
                    }
                    linksql.CloseSQL();
                    break;
                case "employee_ID":
                    linksql.OpenSQL();
                    linksql.SQLSelect(@"select count(*) from employee where ID = '" + employee_ID.Text + "'");
                    i = int.Parse(linksql.Comm.ExecuteScalar().ToString());
                    if (i != 0)
                    {
                        MessageBox.Show("该员工已存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        employee_ID.SelectAll();
                    }
                    linksql.CloseSQL();
                    break;
                case "sex":
                    if (sex.Text != "男" && sex.Text != "女")
                    {
                        MessageBox.Show("请选择男或女!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sex.SelectAll();
                    }    
                    break;
                case "post":
                    linksql.OpenSQL();
                    linksql.SQLSelect(@"select count(*) from employee where post = '" + employee_ID.Text + "'");
                    i = int.Parse(linksql.Comm.ExecuteScalar().ToString());
                    if (i != 0)
                    {
                        MessageBox.Show("该职位不存在!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        post.SelectAll();
                    }
                    linksql.CloseSQL();
                    break;
            }
        }

        private void ID_Check(object sender,EventArgs e) //身份证号码检索
        {
            LinkSQL linksql = new LinkSQL();
            int i;
            linksql.OpenSQL();
            linksql.SQLSelect(@"select count(*) from employee where ID_card = '" + IDCard.Text + "'");
            i = int.Parse(linksql.Comm.ExecuteScalar().ToString());
            if (i != 0)
            {
                MessageBox.Show("该员工已存在！","警告",MessageBoxButtons.OK,MessageBoxIcon.Information);
                IDCard.SelectAll();
            }
                linksql.CloseSQL();
        }
        private void Confirm_Click(object sender, EventArgs e)    //确认添加按钮事件
        {
            LinkSQL linksql = new LinkSQL();
            //System.Data.SqlClient.SqlDataReader RD;
            int i;
            linksql.OpenSQL();
            try
            {
                i = linksql.SQLInsert(@"insert sign(employee_ID,employee_Name) values('" + employee_ID.Text + "','" + name.Text + "')");
                if (i == 1)
                {
                    i = linksql.SQLInsert(@"insert employee values('" + department_ID.Text + "','" + employee_ID.Text + "','" + name.Text + "','" + sex.Text + "'," + float.Parse(wages.Text) + ",'" + IDCard.Text + "','" + address.Text + "','" + telephone.Text + "','" + post.Text + "','" + DateTime.Now.ToString() + "')");
                    if (i == 1)
                    {
                        MessageBox.Show("添加成功!", "提示"); this.Close();
                    }
                    else
                    {
                        MessageBox.Show("添加失败", "提示"); return;
                    }

                }
                else
                {
                    MessageBox.Show("添加失败!", "提示"); return;
                }
            }
            catch
            {
                MessageBox.Show("添加失败，请检查您输入的数据!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            linksql.CloseSQL();
        }

        private void callOff_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
