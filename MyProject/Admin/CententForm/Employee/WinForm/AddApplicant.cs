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
    public partial class AddApplicant : Form
    {
        public AddApplicant()
        {
            InitializeComponent();
            joinTime.Text = DateTime.Now.ToString();
            timer1.Interval = 1000;
            timer1.Enabled = true;
        }
        /// <summary>
        /// 自动刷新时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            joinTime.Text = DateTime.Now.ToString();//刷新时间
        }
        /// <summary>
        /// 手动刷新时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            joinTime.Text = DateTime.Now.ToString();//手动刷新时间
        }
        /// <summary>
        /// 闭关窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 确认提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            /// <summary>受影响的行数 </summary>
            int infRow = 0;//受影响的行数
            int repeat = 0;//重复的数据数
            LinkSQL linkSql = new LinkSQL();
            try
            {
                try
                {
                    //--------------------
                    linkSql.OpenSQL();
                    linkSql.SQLSelect(@"select count(*) from applicants where ID_card = '" + id.Text + "' ");
                    repeat = int.Parse(linkSql.Comm.ExecuteScalar().ToString());
                    linkSql.Conn.Dispose();
                    linkSql.Comm.Dispose();
                    linkSql.CloseSQL();
                    //----------------------查询库中是否已存在数据
                }
                catch { MessageBox.Show("无法连接服务器，请重试"); return; }
                if (repeat == 0)
                {
                    linkSql.OpenSQL();
                    string insertStr = "insert into applicants values('" + name.Text + "','" + sex.Text + "'," + age.Text + ",'" + id.Text + "','" + post.Text + "','" + joinTime.Text + "')";
                    infRow = linkSql.SQLInsert(insertStr); 
                    linkSql.Comm.Dispose();
                    linkSql.Conn.Dispose();
                    linkSql.CloseSQL();
                }
                else
                {
                    MessageBox.Show("已存在此人，请勿插入重复数据！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);return;
                }
            }
            catch
            {
                MessageBox.Show("插入失败，请重试！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                linkSql.Conn.Dispose();
                linkSql.Comm.Dispose();
            }
            if (infRow == 1)
            {
                MessageBox.Show("添加成功!", "提示");
                foreach (Control a in this.Controls)
                {
                    if (a.GetType().Name == "TextBox")
                    {
                        a.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("添加失败","提示");
                return;
            }
        }
    }
}
