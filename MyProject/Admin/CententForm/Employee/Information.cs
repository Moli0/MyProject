using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using MyProject;
using AutoSize_Form;



namespace MyProject.Admin.CententForm.Employee
{
    public partial class Information : Form
    {
        MyResize mr;
        LinkSQL linkSql = new LinkSQL();
        Label[] tableHead = new Label[11];
        Label[] tableLabel1 = new Label[110];
        Label[] tableLabel2 = new Label[110];
        bool autoSize = false;//由于第一次打开窗口时会自适应改变窗口大小，所以，第一次不进行调整

        string queryT_SQL = "";
        string selectDataLineT_SQL = "";
        int line = 0;
        int pageNo = 1;
        public Information()
        {
            InitializeComponent();
            mr = new MyResize(this);
            this.AutoScroll = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.Text = "员工信息查询";
            this.SizeChanged += Information_SizeChanged;
            this.E_ID.TextChanged += EmployeeTextChange_Click;
            this.query.Click += Query_Click;
            pageDown.Click += PageDown_Click;
            pageUp.Click += PageUp_Click;
            TabelHead();
            TabelLabel(tableLabel1);
            TabelLabel(tableLabel2);
            //SelectTableData();
            string sqlSelectStr = "select ID from department";
            LoadData(sqlSelectStr,D_NameID);
            sqlSelectStr = "select name from department";
            LoadData(sqlSelectStr,D_NameID);
            sqlSelectStr = "select ID from employee";
            LoadData(sqlSelectStr,E_ID);
            sqlSelectStr = "select name from employee";
            LoadData(sqlSelectStr, E_Name);
            sqlSelectStr = "select ID from post";
            LoadData(sqlSelectStr, P_NameID);
            sqlSelectStr = "select name from post";
            LoadData(sqlSelectStr, P_NameID);



        }


        private void LoadData(string sqlSelectStr, ComboBox C)   //加载检索数据
        {
            System.Data.SqlClient.SqlDataReader dataRead;
            C.Items.Clear();   //清空原数据
            linkSql.OpenSQL();   //打开数据库
            linkSql.SQLSelect(sqlSelectStr);  //执行查询
            dataRead = linkSql.Comm.ExecuteReader();   //
            while (dataRead.Read())
            {

                int i = 0;
                string s = "";
                s = (string)dataRead[i];     //记录下数据库中返回的内容
                C.Items.Add(s);    //将数据添到控件的选项中
                i++;
            }
            linkSql.CloseSQL();  //关闭数据库
        }

        private void EmployeeTextChange_Click(object sender, EventArgs e)//输入了员工编号的话会自动清空其他且禁用其他选项，因为员工编号是唯一的
        {
            if (E_ID.Text != "")
            {
                D_NameID.Enabled = false;
                D_NameID.Text = "";
                E_Name.Enabled = false;
                E_Name.Text = "";
                P_NameID.Enabled = false;
                P_NameID.Text = "";

            }
            else
            {
                D_NameID.Enabled = true;
                E_Name.Enabled = true;
                P_NameID.Enabled = true;
            }
        }

        private void SelectTableData()    //条件查询语句-->
        {
            string sqlSelectStr = "select * from employee ";
            if (D_NameID.Text != "")     //如果用户输入了部门信息
            {
                //
                sqlSelectStr = sqlSelectStr + " where department_ID = (select ID from department where ID = \'" + D_NameID.Text + "\' or name = \'" + D_NameID.Text + "\') ";
                //根据信息查询部门
                if (E_Name.Text != "")  //如果用户输入了部门信息也输入了员工名字
                {
                    sqlSelectStr = sqlSelectStr + "and name = \'" + E_Name.Text + "\' ";
                    if (P_NameID.Text != "")    //如果用户把部门信息和员工名字还有所在职位都输入了
                    {
                        sqlSelectStr = sqlSelectStr + "and post = \'" + P_NameID.Text + "\' ";
                    }
                }
                if (E_Name.Text == "" && P_NameID.Text != "")    //没有输入名字，输入了部门和职位
                {
                    sqlSelectStr = sqlSelectStr + "and post = (select name from post where ID = \'" + P_NameID.Text + "\' or name = \'" + P_NameID.Text + "\')";
                }
            }


            if (E_ID.Text != "")    //如果用户输入员工编号，将禁用其他输入，因为编号是唯一的
            {
                sqlSelectStr += "where id = \'" + E_ID.Text + "\' ";
            }


            if (D_NameID.Text == ""&&E_Name.Text != "")    //如果用户输入员工名字
            {
                sqlSelectStr += "where name = \'" + E_Name.Text + "\' ";
                if (P_NameID.Text != "")    //如果用户把员工名字还有所在职位都输入了
                {
                    sqlSelectStr = sqlSelectStr + "and post = (select name from post where ID = \'"+ P_NameID.Text + "\' or name = \'"+ P_NameID.Text + "\')";
                }
            }
            if (D_NameID.Text == "" && E_Name.Text  == ""&&P_NameID.Text!= "")  //只输入职位查询
            {
                sqlSelectStr += " where post = (select name from post where ID = \'"+ P_NameID.Text + "\' or name = \'"+ P_NameID.Text + "\')";
            }
             queryT_SQL = sqlSelectStr;
        }//<--条件查询语句
        private void SelectDataLine()    //满足条件行数查询-->
        {
            string sqlSelectStr = "select count(*) from employee ";
            if (D_NameID.Text != "")     //如果用户输入了部门信息
            {
                //
                sqlSelectStr = sqlSelectStr + " where department_ID = (select ID from department where ID = \'" + D_NameID.Text + "\' or name = \'" + D_NameID.Text + "\') ";
                //根据信息查询部门
                if (E_Name.Text != "")  //如果用户输入了部门信息也输入了员工名字
                {
                    sqlSelectStr = sqlSelectStr + "and name = \'" + E_Name.Text + "\' ";
                    if (P_NameID.Text != "")    //如果用户把部门信息和员工名字还有所在职位都输入了
                    {
                        sqlSelectStr = sqlSelectStr + "and post = \'" + P_NameID.Text + "\' ";
                    }
                }
                if (E_Name.Text == "" && P_NameID.Text != "")    //没有输入名字，输入了部门和职位
                {
                    sqlSelectStr = sqlSelectStr + "and post = (select name from post where ID = \'" + P_NameID.Text + "\' or name = \'" + P_NameID.Text + "\')";
                }
            }


            if (E_ID.Text != "")    //如果用户输入员工编号，将禁用其他输入，因为编号是唯一的
            {
                sqlSelectStr += "where id = \'" + E_ID.Text + "\' ";
            }


            if (D_NameID.Text == "" && E_Name.Text != "")    //如果用户输入员工名字
            {
                sqlSelectStr += "where name = \'" + E_Name.Text + "\' ";
                if (P_NameID.Text != "")    //如果用户把员工名字还有所在职位都输入了
                {
                    sqlSelectStr = sqlSelectStr + "and post = (select name from post where ID = \'" + P_NameID.Text + "\' or name = \'" + P_NameID.Text + "\')";
                }
            }
            if (D_NameID.Text == "" && E_Name.Text == "" && P_NameID.Text != "")  //只输入职位查询
            {
                sqlSelectStr += " where post = (select name from post where ID = \'" + P_NameID.Text + "\' or name = \'" + P_NameID.Text + "\')";
            }
            selectDataLineT_SQL = sqlSelectStr;
        }//<--满足条件行数查询

        private void Query_Click(object sender, EventArgs e)//查询按钮事件-->
        {
            System.Data.SqlClient.SqlDataReader DR;
            System.Data.SqlClient.SqlDataReader DRL;

            int dataLine = 0;

            SelectTableData();
            SelectDataLine();
            //int z = 0;
            foreach (Label L in tableLabel1)    //清空表格中的数据-->
            {
                L.Text = "";
                L.Visible = false;
            }
            for (int i = 0; i < tableLabel2.Length; i++)
            {
                if (i % 10 != 0)
                    tableLabel2[i].Text = "";
                tableLabel2[i].Visible = false;
                panel1.Controls.Add(tableLabel2[i]);
            }
            pageNo = 1;
            page.Text = pageNo.ToString();
            //<--清空表格中的数据

            try
            {
                linkSql.OpenSQL();   //-->打开数据库<--
            }
            catch
            {
                MessageBox.Show("数据库打开失败!");
                return;
            }
            linkSql.SQLSelect(selectDataLineT_SQL);//-->执行查询语句<--
            DRL = linkSql.Comm.ExecuteReader();
            int iii = 0;
            while (DRL.Read())          //查询满足条件的数量-->
            {

                line = Convert.ToInt32(DRL[iii]);
                iii++;
            }                           //<--查询满足条件的数量



            linkSql.CloseSQL();            //关闭数据库

            try
            {
                linkSql.OpenSQL();   //-->打开数据库<--
            }
            catch
            {
                MessageBox.Show("数据库打开失败!");
                return;
            }
            linkSql.SQLSelect(queryT_SQL);//-->执行查询语句<--
            DR = linkSql.Comm.ExecuteReader();
            int r = 0;
            if (line <= 10)
            {
                dataLine = 0;
                while (DR.Read())          //输入数据到表格中  -->   
                {
                    dataLine++;
                    for (int i = 0; i < DR.FieldCount; i++)
                    {
                        string s = "";
                        s = Convert.ToString(DR[i]);    //-->记录下数据库中返回的内容<--
                        tableLabel1[i + r + 1].Text = s;    //-->将数据填充到每一个单元格中<--
                        tableLabel1[i + r + 1].Visible = true;
                        // }
                    }
                    tableLabel1[r].Visible = true;
                    tableLabel1[r].Text = dataLine.ToString();
                    r += 11;                       //表格的下一行

                }           // <--输出数据到表格中
            }
            else
            {
                dataLine = 0;
                int j = 0;
                while (DR.Read())
                {
                    dataLine++;
                    if (j < 10)
                    {
                        for (int i = 0; i < DR.FieldCount; i++)
                        {
                            string s = "";
                            s = Convert.ToString(DR[i]);    //-->记录下数据库中返回的内容<--
                            tableLabel1[i + r + 1].Text = s;    //-->将数据填充到每一个单元格中<--
                            tableLabel1[i + r + 1].Visible = true;
                            // }
                        }
                        tableLabel1[r].Visible = true;
                        tableLabel1[r].Text = dataLine.ToString();
                        r += 11;                       //表格的下一行
                    }
                    if (dataLine%11 == 0)
                    { r = 0; }
                    if (j >= 10 && j < 20)
                    {
                        for (int i = 0; i < DR.FieldCount; i++)
                        {
                            string s = "";
                            s = Convert.ToString(DR[i]);    //-->记录下数据库中返回的内容<--
                            tableLabel2[i + r + 1].Text = s;    //-->将数据填充到每一个单元格中<--
                            tableLabel2[i + r + 1].Visible = true;
                            // }
                        }
                        tableLabel2[r].Visible = true;
                        tableLabel2[r].Text = dataLine.ToString();
                        r += 11;                       //表格的下一行
                    }
                    j++;
                }
                for (int i = (j%10) * 11; i < 110; i++)     //i=行数，如果有5行，则55个单元格后的全部隐藏
                {
                    tableLabel2[i].Visible = false;
                }
            }
            linkSql.CloseSQL();            //关闭数据库
            r = 0;
            allPage.Text = ((line / 10) + 1).ToString();
            MessageBox.Show("查询共有" + line.ToString() + "条数据","查询情况");
        }//<--“查询”按钮事件

        private void PageDown_Click(object sender, EventArgs e)
        {
            if (line / 10 >= 1)
            {
                if (pageNo < int.Parse(allPage.Text))
                {
                    pageNo++;
                }
                page.Text = pageNo.ToString();
                foreach (Label a in tableLabel1)
                {
                    a.Visible = false;
                }
                foreach (Label a in tableLabel2)
                {
                    if (a.Visible == false)
                    {
                        a.Visible = false;
                    }
                    else
                    {
                        a.Visible = true;
                    }
                }
            }
        }       //下一页

        private void PageUp_Click(object sender, EventArgs e)       //上一页
        {
            if (pageNo > 1)
            {
                pageNo--;

                page.Text = pageNo.ToString();
                foreach (Label a in tableLabel1)
                {
                    a.Visible = true;
                }
            }

        }



        private void TabelLabel(Label[] tableLabel)        //表格属性     
        {
            int z = 0;
            int X = -100, Y = 0;
            for (int i = 0; i < 10; i++)
            {
                Y += 30;
                for (int t = 0; t < 11; t++)
                {
                    tableLabel[t + z] = new Label();
                    tableLabel[t+z].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                    tableLabel[t+z].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    tableLabel[t+z].Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold);
                    tableLabel[t+z].Location = new System.Drawing.Point(X += 100, Y);
                    tableLabel[t+z].Name = "tableLable";
                    tableLabel[t+z].Size = new System.Drawing.Size(100, 30);
                    tableLabel[t+z].TabIndex = 0;
                    tableLabel[t + z].Visible = true;
                    //tableLabel[t+z].Text = (t + z).ToString();
                    tableLabel[t+z].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    panel1.Controls.Add(tableLabel[t+z]);
                    if ((t + z)%11 == 6)
                    {
                        tableLabel[t + z].Size = new Size(200,30);
                    }
                    if ((t + z) % 11 == 7)
                    {
                        tableLabel[t + z].Size = new Size(250, 30);
                        tableLabel[t + z].Location = new Point(tableHead[7].Location.X, Y);
                    }
                    if ((t + z) % 11 == 8)
                    {
                        tableLabel[t + z].Size = new Size(120, 30);
                        tableLabel[t + z].Location = new Point(tableHead[8].Location.X, Y);
                    }
                    if ((t + z) % 11 == 9)
                    {
                        tableLabel[t + z].Size = new Size(200, 30);
                        tableLabel[t + z].Location = new Point(tableHead[9].Location.X, Y);
                    }
                    if ((t + z) % 11 == 10)
                    {
                        tableLabel[t + z].Size = new Size(100, 30);
                        tableLabel[t + z].Location = new Point(tableHead[10].Location.X, Y);
                    }
                    if ((t + z) % 11 == 0)
                    {
                        tableLabel[t + z].Size = new Size(50, 30);
                        tableLabel[t + z].Location = new Point(50, Y);
                        tableLabel[t + z].Text = (i+1).ToString();
                    }
                }
                z += 11;
                X = -100;
            }
        }  

        private void TabelHead()   //表头属性
        {
            int locationX = -100, locationY = 0;
            //tableLbabl表头
            for (int i = 0; i < tableHead.Length; i++)
            {
                tableHead[i] = new Label();
                tableHead[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                tableHead[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                tableHead[i].Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold);
                tableHead[i].Location = new System.Drawing.Point(locationX += 100, locationY);
                tableHead[i].Name = "tableLable";
                tableHead[i].Size = new System.Drawing.Size(100, 30);
                tableHead[i].TabIndex = 0;
                tableHead[i].Text = i.ToString();
                tableHead[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                panel1.Controls.Add(tableHead[i]);
            }
            tableHead[0].Size = new Size(50,30);tableHead[6].Size = new Size(200,30); tableHead[7].Size = new Size(250,30);tableHead[8].Size = new Size(120, 30);tableHead[9].Size = new Size(200, 30);

            tableHead[0].Location = new Point(50,0);tableHead[7].Location = new Point(800,0); tableHead[8].Location = new Point(1050, 0); tableHead[9].Location = new Point(1150, 0);tableHead[10].Location = new Point(1350,0);
            
            tableHead[0].Text = ""; tableHead[1].Text = "部门编号"; tableHead[2].Text = "员工编号"; tableHead[3].Text = "姓名";
            tableHead[4].Text = "姓别"; tableHead[5].Text = "工资"; tableHead[6].Text = "身份证号码"; tableHead[7].Text = "家庭地址"; tableHead[8].Text = "电话号码";tableHead[9].Text = "职位";tableHead[10].Text = "入职时间";

        }


        private void Information_SizeChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (autoSize)
            {
                mr.ResizeFrm(this);
                panel2.Left = (panel1.Width - panel2.Width) / 2;
            }
            else
            {
                autoSize = true;
            }
            /*
            title.Location = new Point((this.Width - title.Width) / 2, title.Location.Y);
            this.AutoScroll = true;*/
        }
    }
}
