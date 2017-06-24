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
    /// <summary>
    /// 需求管理界面
    /// </summary>
    public partial class Demand : Form
    {
        /// <summary>
        /// 表头
        /// </summary>
        private Label[] tableHead = new Label[5];
        /// <summary>
        /// 表格
        /// </summary>
        private Label[,] table = new Label[20, 5];
        /// <summary>
        /// 删除需求的按钮
        /// </summary>
        private Button[] delButton = new Button[20];
        /// <summary>
        /// 修改需求的按钮
        /// </summary>
        private Button[] alterButton = new Button[20];
        /// <summary>
        /// 记录详细介绍
        /// </summary>
        private string[] detail = new string[20];
        /// <summary>
        /// 记录原始大小
        /// </summary>
        Size[] oldSize = new Size[20];
        /// <summary>
        /// 记录原始位置
        /// </summary>
        Point[,] oldPoint = new Point[20, 5];
        /// <summary>
        /// 控制变化后表格的大小
        /// </summary>
        Size size = new Size(350, 165);

        public Demand()
        {
            InitializeComponent();
            Initialize_Table(table);
            Initialize_DelButton();
            Initialize_AlterButton();
            this.Load += InitializeData;

            //panel1.BorderStyle = BorderStyle.FixedSingle;
        }
        /// <summary>
        /// 初始化表格或刷新表格数据
        /// </summary>
        private void InitializeData()
        {
            foreach (Control a in panel1.Controls)
            {
                if (a.GetType().Name=="Button")
                {
                    a.Visible = false;
                }
            }
            LinkSQL linkSql = new LinkSQL();
            System.Data.SqlClient.SqlDataReader DR;  //TODO:载入表格数据
            linkSql.OpenSQL();
            linkSql.SQLSelect("select *from demand");
            DR = linkSql.Comm.ExecuteReader();
            int i = 0;
            while (DR.Read())
            {
                panel1.Controls.Add(delButton[i]);
                panel1.Controls.Add(alterButton[i]);
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j].Visible = true;
                    table[i, j].Text = DR[j].ToString();
                    if (DR[j].ToString() == "PU0001")
                    {
                        table[i, j].Text = "采购部";
                    }
                    if (DR[j].ToString() == "ST0001")
                    {
                        table[i, j].Text = "仓储部";
                    }
                    if (j == table.GetLength(1) - 1)
                    {
                        detail[i] = table[i, j].Text;       //把完整的介绍提取出来
                        table[i, j].Size = new Size(350, 33);
                        if (table[i, j].Text.Length > 18)           //将详细介绍收缩
                        {
                            table[i, j].Text = table[i, j].Text.Substring(0, 18);   //截断字符串
                            table[i, j].Text += "...";
                        }
                    }
                    if (j == 0)
                    {
                        table[i, j].Text = (i + 1).ToString();
                    }
                }
                i++;
            }
            linkSql.CloseSQL();
        }
        /// <summary>
        /// 初始化表格或刷新表格数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InitializeData(object sender, EventArgs e)
        {
            InitializeData();
        }
        /// <summary>
        /// 添加应聘者信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            WinForm.AddApplicant addApplicat = new WinForm.AddApplicant();
            DialogResult dr = addApplicat.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                RefreshData();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 添加需求事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int number = 22;  //记录当前的需求信息的数量
            try
            {
                LinkSQL linkSql = new LinkSQL();
                linkSql.OpenSQL();
                linkSql.SQLSelect(@"select count(*) from demand");
                number = int.Parse(linkSql.Comm.ExecuteScalar().ToString());
                linkSql.CloseSQL();
            }
            catch
            {
                MessageBox.Show("无法连接到服务器！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (number >= 20)
            {
                MessageBox.Show("最大只可发布20条招聘信息，请先删除部分的招聘信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (number == 22)
            {
                MessageBox.Show("无法连接到服务器！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CententForm.Employee.WinForm.AddDemand addDemand = new CententForm.Employee.WinForm.AddDemand();
            DialogResult dr = addDemand.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                RefreshData();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 编辑需求事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < delButton.Length; i++)
            {
                delButton[i].Visible = true;
                alterButton[i].Visible = true;
            }
        }
        /// <summary>
        /// 查看按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 初始化删除按钮
        /// </summary>
        private void Initialize_DelButton()
        {
            int Y = 10;
            for (int i = 0; i < delButton.Length; i++)
            {
                delButton[i] = new Button();
                delButton[i].Name = (i+1).ToString();
                delButton[i].Text = "删除";
                delButton[i].Size = new Size(40, 20);
                delButton[i].Location = new Point(850, Y);
                delButton[i].BackColor = Color.FromArgb(255, 200, 200, 200);
                delButton[i].ForeColor = Color.White;
                delButton[i].FlatStyle = FlatStyle.Popup;
                delButton[i].Visible = false;
                delButton[i].Click += DeleteData;
                //panel1.Controls.Add(delButon[i]);
                //table[i, 4].Controls.Add(delButon[i]);
                Y += 33;
            }
        }
        /// <summary>
        /// 初始化修改按钮
        /// </summary>
        private void Initialize_AlterButton()
        {
            int Y = 10;
            for (int i = 0; i < alterButton.Length; i++)
            {
                alterButton[i] = new Button();
                alterButton[i].Name = i.ToString();
                alterButton[i].Text = "修改";
                alterButton[i].Size = new Size(40, 20);
                alterButton[i].Location = new Point(900, Y);
                alterButton[i].BackColor = Color.FromArgb(255, 200, 200, 200);
                alterButton[i].ForeColor = Color.White;
                alterButton[i].FlatStyle = FlatStyle.Popup;
                alterButton[i].Visible = false;
                alterButton[i].Click += AlterButton_Click;
                //panel1.Controls.Add(alterButton[i]);
                //table[i, 4].Controls.Add(alterButton[i]);
                Y += 33;
            }
        }
        /// <summary>
        /// 修改按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlterButton_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            CententForm.Employee.WinForm.AddDemand addDemand = new CententForm.Employee.WinForm.AddDemand();
            int buttonName = int.Parse(((Button)sender).Name);//获取要修改的数据所在行
            int No = 0;   
            int y = 0;
            LinkSQL linkSql = new LinkSQL();
            try
            {
                linkSql.OpenSQL();
            }
            catch
            {
                MessageBox.Show("无法连接数据库！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            linkSql.SQLSelect(@"select No from demand");
            System.Data.SqlClient.SqlDataReader DR = linkSql.Comm.ExecuteReader();
            while (DR.Read())
            {
                if ( buttonName == y)
                {
                    No = int.Parse(DR[0].ToString());
                }
                y++;
            }
            addDemand.UpDataNo = No;
            addDemand.Department_ID.Text = table[buttonName, 1].Text;
            if (table[buttonName, 1].Text == "采购部") addDemand.Department_ID.Text = "PU0001";
            if (table[buttonName, 1].Text == "仓储部") addDemand.Department_ID.Text = "ST0001";
            addDemand.Post.Text = table[buttonName, 2].Text;
            addDemand.Rec_Number.Text = table[buttonName, 3].Text;
            addDemand.Explain.Text = detail[buttonName];
            DialogResult dr = addDemand.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                RefreshData();
            }
            else
            {
                return;
            }


        }

        int t_X = 3, t_Y = -33;
        /// <summary>
        /// 初始化表格样式
        /// </summary>
        /// <param name="table">二维Label数组</param>
        private void Initialize_Table(Label[,] table)
        {

            for (int i = 0; i < table.Length / table.GetLength(1); i++)
            {
                t_Y += 33;
                t_X = 0;
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = new Label();
                    table[i, j].Name = i.ToString();
                    table[i, j].AutoSize = false;
                    table[i, j].Size = new Size(100, 33);
                    table[i, j].Location = new Point(t_X, t_Y);
                    table[i, j].BorderStyle = BorderStyle.FixedSingle;
                    table[i, j].Visible = false;
                    table[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    table[i, j].Font = new Font("楷体", 12);
                    //table[i, j].Text = "椅套棋人傣地越洋鴮枯井回复丢撒韩国进口大厦看觉得是否是否尽快沙发算了降幅达考虑时间发放";
                    if (j == table.GetLength(1) - 1)
                    {
                        detail[i] = table[i, j].Text;       //把完整的介绍提取出来
                        table[i, j].Size = new Size(350, 33);
                        table[i, j].MouseEnter += MouseEnterTable;
                        table[i, j].MouseLeave += MouseLeaveTable;
                        if (table[i, j].Text.Length > 10)           //将详细介绍收缩
                        {
                            table[i, j].Text = table[i, j].Text.Substring(0, 10);   //截断字符串
                            table[i, j].Text += "...";
                        }
                    }
                    panel1.Controls.Add(table[i, j]);
                    if (j != 2)
                        t_X += 100;
                    else
                    {
                        t_X += 180;
                        table[i, j].Size = new Size(180, 33);
                    }
                }
            }
        }
        /// <summary>
        /// 鼠标离开后恢复原样
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLeaveTable(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            int row = int.Parse(lb.Name);
            for (int j = 0; j < table.GetLength(1); j++)
            {
                table[row, j].Size = oldSize[j];
            }
            for (int i = 0; i < table.Length / table.GetLength(1); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j].Location = oldPoint[i, j];
                    if (table[i, j].Text.Length > 18)           //将详细介绍收缩
                    {
                        table[i, j].Text = table[i, j].Text.Substring(0, 18);   //截断字符串
                        table[i, j].Text += "...";
                    }
                }
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshData()
        {
            this.Controls.Clear();
            t_X = 3; t_Y = -33;
            InitializeComponent();
            Initialize_Table(table);
            Initialize_DelButton();
            Initialize_AlterButton();
            InitializeData();
        }
        /// <summary>
        /// 刷新按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        /// <summary>
        /// 鼠标所在一行表格会显示出全部内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseEnterTable(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            int row = int.Parse(lb.Name);
            for (int j = 0; j < table.GetLength(1); j++)
            {
                oldSize[j] = table[row, j].Size;
                table[row, j].Size = new Size(100, size.Height);
                table[row, table.GetLength(1) - 1].Text = detail[row];
                if (j == table.GetLength(1) - 1)
                {
                    table[row, j].Size = size;
                }
                if (j == 2)
                {
                    table[row, j].Size = new Size(180, size.Height);
                }
            }
            for (int i = 0; i < table.Length / table.GetLength(1); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    oldPoint[i, j] = new Point(table[i, j].Location.X, table[i, j].Location.Y);
                }
            }
            int Y = table[row, 0].Location.Y + 165;
            while (row < table.Length / table.GetLength(1) - 1)
            {
                row++;
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[row, j].Location = new Point(table[row, j].Location.X, Y);
                }
                Y += 33;
            }

        }
        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteData(object sender, EventArgs e)
        {
            DialogResult Re = MessageBox.Show("确认删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Re == DialogResult.OK)
            {
                int No = int.Parse(((Button)sender).Name);//获取要删除的数据所在行
                int y = 0;//找出要删除的行
                LinkSQL linkSql = new LinkSQL();
                try
                {
                    linkSql.OpenSQL();
                }
                catch
                {
                    MessageBox.Show("无法连接数据库！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                linkSql.SQLSelect(@"select No from demand");
                System.Data.SqlClient.SqlDataReader DR = linkSql.Comm.ExecuteReader();
                while (DR.Read())
                {
                    y++;
                    if (y == No)
                    {
                        No = int.Parse(DR[0].ToString());
                    }
                }
                linkSql.CloseSQL();
                try
                {
                    linkSql.OpenSQL();
                }
                catch
                {
                    MessageBox.Show("无法连接数据库！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                linkSql.SQLInsert(@"delete demand where No = " + No.ToString());
                linkSql.SQLSelect(@"dbcc checkident('demand',reseed,0)");
                linkSql.Comm.ExecuteNonQuery();
                linkSql.CloseSQL();
                RefreshData();
            }
            else
            {
                return;
            }
        }
    }
}
