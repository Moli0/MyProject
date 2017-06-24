using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// rec_Number  招聘人数输入框（TextBox）
/// department  部门iD输入框    post  职位输入框  （ComboBox）
/// explain     应聘要求
/// </summary>
namespace MyProject.Admin.CententForm.Employee.WinForm
{
    public partial class AddDemand : Form
    {
        private int upDateNO = 0;
        public AddDemand()
        {
            InitializeComponent();
            this.Load += Frm_Load;
            //explain.Enabled = false;
            explain.Enter += Explain_Enter;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            explain.MaxLength = 120;
            department_ID.TextChanged += DepartmentTextChange_Click;
        }

        private void Frm_Load(object sender, EventArgs e)//加载ComboBox的一些选项
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

            //sex.Items.Add("男");
            //sex.Items.Add("女");
            linksql.CloseSQL();     //关闭数据库
            linksql.OpenSQL();          //打开数据库
            linksql.SQLSelect(@"select name from post where department_ID='"+department_ID.Text+"'");        //查询职位
            RD = linksql.Comm.ExecuteReader();
            while (RD.Read())
            {
                post.Items.Add(Convert.ToString(RD[0]));         //将查询的结果添加到post上
            }

            linksql.CloseSQL();     //关闭数据库
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (department_ID.Text != "" && post.Text != "" && rec_Number.Text != "" && explain.Text != "")
            {
                AddData();
            }
            else
            {
                MessageBox.Show("尚有数据未输入，无法添加！","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            this.DialogResult = DialogResult.Cancel;
        }

        private void DepartmentTextChange_Click(object sender, EventArgs e)
        {
            post.Items.Clear();
            LinkSQL linksql = new LinkSQL();        //创建数据库连接对象
            System.Data.SqlClient.SqlDataReader RD;     //创建一个对像接收查询的返回数据
            linksql.OpenSQL();          //打开数据库
            linksql.SQLSelect(@"select name from post where department_ID='" + department_ID.Text + "'");        //查询职位
            RD = linksql.Comm.ExecuteReader();
            while (RD.Read())
            {
                post.Items.Add(Convert.ToString(RD[0]));         //将查询的结果添加到post上
            }

            linksql.CloseSQL();     //关闭数据库
        }
        private void Explain_Enter(object sender, EventArgs e)
        {
            explain.Enabled = true;
            explain.Text = "";
            explain.BackColor = Color.White;
            explain.ForeColor = Color.Black;
        }


        private void AddData()
        {
            int i = 0, k = 0;  //i记录影响行数，K记录重复行数
            string insertStr = @"insert demand values('" + department_ID.Text + "','" + post.Text + "'," + rec_Number.Text + ",'" + explain.Text + "')";
            LinkSQL linksql = new LinkSQL();
            try
            {
                linksql.OpenSQL();
                linksql.SQLSelect("select count(*) from demand where post = '" + post.Text + "'");
                k = int.Parse(linksql.Comm.ExecuteScalar().ToString());
                linksql.SQLSelect("select NO from demand where post = '" + post.Text + "'");
                linksql.CloseSQL();//关闭连接
                if (k == 0)
                {
                    linksql.OpenSQL();//打开连接 
                    i = linksql.SQLInsert(insertStr);
                    linksql.CloseSQL();//关闭连接
                }
                else
                {
                    linksql.OpenSQL();//打开连接 
                    My.MyMessageBox messageBox = new My.MyMessageBox();
                    messageBox.Show("该信息已存在，是否修改招聘信息？","提示",My.MyMessageBox.MyMessageBoxButton.OKCancel,My.MyMessageBox.MyMessageBoxIcon.Question);
                    DialogResult DR = messageBox.DialogResult;
                    if (DR == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                    else
                    {
                        //upDateNO = int.Parse(linksql.Comm.ExecuteScalar().ToString());
                        string upDateStr = @"update demand set department_id = '" + department_ID.Text + "',post = '" + post.Text + "',rec_Number = " + rec_Number.Text + ",exlain = '" + explain.Text + "' where NO = " + upDateNO.ToString();
                        i =linksql.SQLInsert(upDateStr);
                    }
                    linksql.CloseSQL();//关闭连接
                }
            }
            catch       //插入或更新出错尝试重新插入更新（20次）
            {
                linksql.CloseSQL();
                linksql.OpenSQL();//打开连接 
                //upDateNO = int.Parse(linksql.Comm.ExecuteScalar().ToString());
                string upDateStr = @"update demand set department_id = '" + department_ID.Text + "',post = '" + post.Text + "',rec_Number = " + rec_Number.Text + ",exlain = '" + explain.Text + "' where NO = " + upDateNO.ToString();
                for (int x = 0; x < 20; x++)
                {
                    try
                    {
                        if (k == 0)
                        {
                            i = linksql.SQLInsert(insertStr); break;
                        }
                        else
                        {
                            i = linksql.SQLInsert(upDateStr);
                        }
                    }
                    catch { continue; }
                }
                linksql.CloseSQL();
                if (i == 1)
                {
                    MessageBox.Show("添加成功！", "提示");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("插入失败,请重试！如多次提示，请尝试删除一个招聘信息后再次修改", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                return;
            }
            linksql.CloseSQL();
            if (i == 1)//判断添加数据结果
            {
                MessageBox.Show("添加成功！", "提示");
                this.Close();
                
            }
            else
            {
                MessageBox.Show("插入失败,请重试！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// department外部访问属性
        /// </summary>
        public ComboBox Department_ID
        {
            get { return department_ID; }
            set { department_ID = value; }
        }
        /// <summary>
        /// post外部访问属性
        /// </summary>
        public ComboBox Post
        {
            set { post = value; }
            get { return post; }
        }
        public TextBox Rec_Number
        {
            set { rec_Number = value; }
            get { return rec_Number; }
        }
        public int UpDataNo
        {
            set { upDateNO = value; }
            get { return upDateNO; }
        }
        public TextBox Explain
        {
            set { explain = value; }
            get { return explain; }
        }
    }
}
