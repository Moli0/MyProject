using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject.Admin.CententForm.Employee
{
    public partial class Applicants : Form
    {
        private Label[,] table = new Label[200, 7];
        private CheckBox[] del = new CheckBox[200];
        public Applicants()
        {
            InitializeComponent();
            Initialize_Table(table,0,0,new Size(100,30));
            this.Load += Applicants_Load;
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
        }

        private void Applicants_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }


        /// <summary>
        /// 全选CheckBox,点击后会进行全选或取消选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (checkBox1.Checked == true) //全选的CheckBox选中后，其余CheckBox全部选中
            {
                foreach (CheckBox a in del)
                {
                    if (a.Visible == true)
                    {
                        a.Checked = true;       //当前CheckBox全部选中
                    }
                }
            }
            else
            {
                if (CheckedAll())
                {
                    foreach (CheckBox a in del)
                    {
                        if (a.Visible == true)
                        {
                            a.Checked = false;   //如果所有的CheckBox为已选中，则全取消选中
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 检测是否全选,全选返回true，否则返回false
        /// </summary>
        /// <returns>返回一个bool值</returns>
        private bool CheckedAll()
        {
            int All = 0;
            foreach (CheckBox a in del)
            {
                if (a.Visible == true)
                {

                    ++All;       //计算所有CheckBox的数量
                }

            }
            int check = All;
            foreach (CheckBox a in del)
            {
                if (a.Visible == true)
                {

                    if (a.Checked == false)
                    {
                        check -= 1;
                    }
                }

            }
            if (check == All)
            {
                return true;
            }
            else { return false; }
        }
        private void CheckedAll(object sender, EventArgs e)
        {
            if (CheckedAll())
            {
                 checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
        }

        /// <summary>
        /// 初始化表格样式及del复选框
        /// </summary>
        /// <param name="table">要初始化的二维表</param>
        /// <param name="t_X">初始位置X</param>
        /// <param name="t_Y">初始位置Y</param>
        /// <param name="size">单元格大小</param>
        private void Initialize_Table(Label[,] table,int t_X,int t_Y,Size size)
        {
            int X = t_X;
            for (int i = 0; i < table.Length / table.GetLength(1); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = new Label();
                    table[i, j].Name = i.ToString();
                    table[i, j].AutoSize = false;
                    table[i, j].Size = size;
                    table[i, j].Location = new Point(t_X, t_Y);
                    table[i, j].BorderStyle = BorderStyle.FixedSingle;
                    table[i, j].Visible = false;
                    table[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    table[i, j].Font = new Font("楷体", 12);
                    if (j == 0)
                    {
                        table[i, j].Size = new Size(size.Width -50, size.Height);
                        table[i, j].Location = new Point(t_X, t_Y);
                        t_X -= 50;
                    }
                    if (j > 3)
                    {
                        table[i, j].Size = new Size(size.Width + 100, size.Height);
                        table[i, j].Location = new Point(t_X, t_Y);
                        t_X += 100;
                    }
                    if (i % 2 == 0)
                    {
                        table[i, j].BackColor = Color.FromArgb(255,180,180,180);
                    }
                    t_X += size.Width;
                    panel1.Controls.Add(table[i,j]);
                }


                del[i] = new CheckBox();
                del[i].Location = new Point(t_X + 10, t_Y+5);
                del[i].Size = new Size(20,20);
                del[i].Name = i.ToString();
                del[i].Visible = false;
                if (del[i].Visible == true)
                    del[i].CheckedChanged += CheckedAll;
                panel1.Controls.Add(del[i]);


                t_Y += size.Height;
                t_X = X;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString());
        }
        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string selectStr = "select * from applicants";

            LinkSQL linkSql = new LinkSQL();
            linkSql.OpenSQL();
            
            linkSql.CloseSQL();
        }
    }
}
