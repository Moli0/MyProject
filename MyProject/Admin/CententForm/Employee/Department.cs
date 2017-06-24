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
    public partial class Department : Form
    {
        Label[] tableHead = new Label[5];    //定义表格的表头
        Label[] tableLabel1 = new Label[40];        //表格
        Label[] tableLabel2 = new Label[40];        //第二页表格
        TextBox[] tableTextBox1 = new TextBox[16];    //修改时接收信息的控件
        string[] textBoxName = new string[16];
        float width, height;
        int s = 0,ss=0;

        int count = 0;

        public Department()
        {
            InitializeComponent();
            TableHead();
            TableLabel(tableLabel1);
            TableLabel(tableLabel2);
            TableTextBox(tableTextBox1);
            department1.Click += Department1_Clicked;
            department2.Click += Department2_Clicked;
            this.title.Location = new System.Drawing.Point((this.Width - this.title.Width) / 2, 80);
            this.SizeChanged += FrmSizeChange_Click;
            updateNotice.Click += UpdateNotice_Click;
            lookUp1.Click += LookUp1_Click;
            lookUp2.Click += LookUp2_Click;
            lookUp3.Click += LookUp2_Click;
            alter1.Click += LookUp1_Click;
            alter2.Click += Alter2_Click;
            alter3.Click += Alter2_Click;
            add.Click += Add_Click;
            putIn.Click += PutIn_Click;
            BulletinBoardCententText.Leave += BulletinContentChange_Click;
            width = this.Width;
            height = this.Height;
            //this.OnResizeEnd += OnResizeEnd;
        }
        private void FrmSizeChange_Click(object sender, EventArgs e)        //TODO:自动大小未设置
        {
            this.title.Location = new System.Drawing.Point((this.Width - this.title.Width) / 2, 80);//标题居中
            float widthRatio, heightRatio;  //改变的比例
            widthRatio = this.Width / width;
            heightRatio = this.Height / height;
        }

        private void UpdateNotice_Click(object sender, EventArgs e)     //修改公告,这里主要只是显示输入框，实现方法在下面BulletinContentChange_Click(object sender, EventArgs e)
        {
            if (updateNotice.Text == "修改公告")
            {
                BulletinBoardCentent.Visible = false;
                BulletinBoardCententText.Visible = true;
                updateNotice.Text = "确定";
            }
            else
            {
                BulletinBoardCentent.Visible = true;
                BulletinBoardCententText.Visible = false;
                updateNotice.Text = "修改公告";
            }
        }

        private void BulletinContentChange_Click(object sender, EventArgs e)   //当光标离开公告栏的textBox时发生
        {
            LinkSQL linksql = new LinkSQL();
            DialogResult dr = MessageBox.Show("确认修改？", "修改公告", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                try
                {
                    linksql.OpenSQL();       //打开数据库
                    int i = 0;
                    if (label4.Text == "采购部")
                    {
                        i = linksql.SQLInsert(@"insert notice values('PU0001',GETDATE(),'" + BulletinBoardCententText.Text + "')");
                    }
                    if (label4.Text == "仓储部")
                    {
                        i = linksql.SQLInsert(@"insert notice values('ST0001',GETDATE(),'" + BulletinBoardCententText.Text + "')");
                    }
                    if (i > 0)
                    {
                        MessageBox.Show("修改成功！", "修改结果");
                        if (label4.Text == "采购部")
                        {
                            linksql.SQLSelect(@"select content from notice where department_id = 'PU0001' order by date desc");
                            BulletinBoardCentent.Text = linksql.Comm.ExecuteScalar().ToString();
                        }
                        if (label4.Text == "仓储部")
                        {
                            linksql.SQLSelect(@"select content from notice where department_id = 'ST0001' order by date desc");
                            BulletinBoardCentent.Text = linksql.Comm.ExecuteScalar().ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("修改失败！请重新修改!", "修改结果", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    linksql.CloseSQL();
                }
                catch
                {
                    string str = BulletinBoardCententText.Text;
                    dr = MessageBox.Show("本次修改将不进行保存，是否依然修改？", "修改结果", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.OK)
                    {
                        BulletinBoardCentent.Text = str;
                    }
                }
                BulletinBoardCentent.Visible = true;
                BulletinBoardCententText.Visible = false;
                updateNotice.Text = "修改公告";
            }
            else
            {
                MessageBox.Show("修改失败！您取消了修改！","修改提示");
                BulletinBoardCentent.Visible = true;
                BulletinBoardCententText.Visible = false;
                updateNotice.Text = "修改公告";
            }
        }

        private void Button_State()//隐藏或显示部份控件
        {
            putIn.Visible = false;      ///
            add.Visible = false;         ///
            callOff.Visible = false;     ///关闭修改的相关按钮
            label13.Visible = true;     ///
            pageNow.Visible = true;     ///
            pageAll.Visible = true;     ///显示页数
        }

        private void Initial_Data()//刷新表格页面
        {
            Button_State();
            ss = 0;
            s = 0;
            tableHead[0].Text = "员工编号";
            tableHead[1].Text = "姓名";
            tableHead[2].Text = "要求";
            tableHead[3].Text = "签到";
            tableHead[4].Text = "职位";
            foreach (Label a in tableHead)
            {
                a.Visible = false;
            }
            foreach (Label a in tableLabel1)
            {
                a.Visible = false;
            }
            if (count >= 8)
            {
                foreach (Label a in tableLabel2)
                {
                    a.Visible = false;
                }
            }
            foreach (TextBox a in tableTextBox1)
            {
                a.Visible = false;
            }

            foreach (TextBox a in tableTextBox1)
            {
                a.Leave += TextBoxLevel_Click;      //保证存在有事件相关联
                a.Leave -= TextBoxLevel_Click;
                a.TextChanged += TextBoxChange_Click; //保证存在有事件相关联
                a.TextChanged -= TextBoxChange_Click;
            }
        }

        private void LookUp1_Click(object sender, EventArgs e)  //部门人数查看，修改按钮事件
        {
            
            int z = 0;count = 0;        //z格式控制，count数据的行数
            Initial_Data();     //初始化表格
            tableHead[0].Text = "";
            tableHead[1].Text = "员工编号";
            tableHead[2].Text = "姓名";
            tableHead[3].Text = "姓别";
            tableHead[4].Text = "职位";
            foreach (Label a in tableHead)
            {
                a.Visible = true;
            }
            LinkSQL linksql = new LinkSQL();    //创建数据库连接对像linksql
            System.Data.SqlClient.SqlDataReader RD;
            linksql.OpenSQL();    //打开数据库
            switch (label4.Text)        //根据部门选择查询
            {
                case "采购部":
                    linksql.SQLSelect(@"select ID,Name,sex,post from employee where department_Id = 'PU0001'");
                    break;
                case "仓储部":
                    linksql.SQLSelect(@"select ID,Name,sex,post from employee where department_Id = 'ST0001'");
                    break;
            }
                    RD = linksql.Comm.ExecuteReader();      //接收查询结果
                    while (RD.Read())       //输入查询结果 TODO:暂时只能输出十六条数据 
                    {
                        count++;
                        if (count <= 8)      //小于8行，用表1记录
                        {
                            for (int i = 0; i < RD.FieldCount; i++)
                            {
                                tableLabel1[z].Text = ((z / 5) + 1).ToString();
                                tableLabel1[z].Visible = true;
                                tableLabel1[i + z + 1].Text = Convert.ToString(RD[i]);
                                tableLabel1[i + z + 1].Visible = true;
                            }

                        }
                if (count % 8 == 0)
                { z = 0; }
                        if (count > 8 && count <= 16)   //8-16行用表2记录
                        {
                            z = 0;
                            for (int i = 0; i < RD.FieldCount; i++)
                            {
                                tableLabel2[z].Text = (((z / 5) + 1) + 8).ToString();
                                tableLabel2[z].Visible = false;
                                tableLabel2[i + z + 1].Text = Convert.ToString(RD[i]);
                                tableLabel2[i + z + 1].Visible = false;
                            }
                        }

                        z += 5;
                    }
                    pageNow.Text = "1";     //当前页码
                    pageAll.Text = ((count / 9) + 1).ToString();    //总页面数量  
                    
            linksql.CloseSQL();     //闭关数据库
            //if (((Button)sender).Name == "lookUp1")
            //{
                if (int.Parse(pageAll.Text) > 1)
                {
                    pageUp.Visible = true;
                    pageDown.Visible = true;
                    MessageBox.Show("共" + pageAll.Text + "页");
                }
            //}
            if (((Button)sender).Name == "alter1")
            {
                add.Visible = true;
                callOff.Visible = true;
            }

        }

        private void Add_Click(object sender, EventArgs e)//添加新员工
        {
            WinForm.AddEmployee addForm = new WinForm.AddEmployee();
            addForm.ShowDialog();
        }

        private void LookUp2_Click(object sender, EventArgs e)      //应到、签到人数查看按钮事件
        {
            Initial_Data();
            foreach (Label a in tableHead)
            {
                a.Visible = true;
            }
            int z = 0;
            count = 0;      //z格式控制，count数据的行数
            //--------------------------------------以上为初始化---------------------------//
            LinkSQL linksql = new LinkSQL();//创建数据库连接对像linksql
            System.Data.SqlClient.SqlDataReader RD;

            linksql.OpenSQL();
            switch (((Button)sender).Name)   //判断引发事件的按钮
            {
                case "callOff":
                case "lookUp2":         //应到人员     
                    switch (label4.Text)        //根据部门选择查询
                    {
                        case "采购部":

                            linksql.SQLSelect(@"select a.employee_ID,a.employee_Name,a.shc,a.sign_in,b.post from sign as a,employee as b where a.employee_ID=b.ID and b.department_ID = 'PU0001' and (shc=1 or shc=2)");
                            break;
                        case "仓储部":
                            linksql.SQLSelect(@"select a.employee_ID,a.employee_Name,a.shc,a.sign_in,b.post from sign as a,employee as b where a.employee_ID=b.ID and b.department_ID = 'ST0001' and (shc=1 or shc=2)");
                            break;
                    }
                    break;
                case "lookUp3":             //实到人员
                    switch (label4.Text)        //根据部门选择查询
                    {
                        case "采购部":

                            linksql.SQLSelect(@"select a.employee_ID,a.employee_Name,a.shc,a.sign_in,b.post from sign as a,employee as b where a.employee_ID=b.ID and b.department_ID = 'PU0001' and (sign_in=1 or sign_in=2)");
                            break;
                        case "仓储部":
                            linksql.SQLSelect(@"select a.employee_ID,a.employee_Name,a.shc,a.sign_in,b.post from sign as a,employee as b where a.employee_ID=b.ID and b.department_ID = 'ST0001' and (sign_in=1 or sign_in=2)");
                            break;
                    }
                    break;
            }
            RD = linksql.Comm.ExecuteReader();
            while (RD.Read())
            {
                count++;
                if (count <= 8)
                {
                    for (int i = 0; i < RD.FieldCount; i++)
                    {
                        tableLabel1[i + z].Visible = true;
                        switch (i)
                        {
                            case 0:
                            case 1:
                                //tableLabel1[i + z].Visible = true;
                                tableLabel1[i + z].Text = Convert.ToString(RD[i]);
                                break;
                            case 2:
                            case 3:
                                switch (Convert.ToInt16(RD[i]))       //判断上班的值：0为不用上班，1为正常上班，2为特殊情况  签到：0为未签到，1为已签到，2为请假
                                {
                                    
                                    //tableLabel1[i + z].Visible = true;
                                    case 0:
                                    tableLabel1[i + z].Text = "×";
                                        break;
                                    case 1:
                                        tableLabel1[i + z].Text = "√";
                                        break;
                                    case 2:
                                        tableLabel1[i + z].Text = "○";
                                        break;
                                }
                                break;
                            case 4:
                                tableLabel1[i + z].Text = Convert.ToString(RD[i]);
                                break;
                        }
                    }
                }
                if (count % 8  == 0)   //新的一页重置格式控制
                {
                    z = -5;   
                }

                if (count > 8 && count <= 16)
                {
                    for (int i = 0; i < RD.FieldCount; i++)
                    {
                        tableLabel2[i + z].Visible = false;
                        //tableLabel2[i + z].Text = Convert.ToString(RD[i]);
                        switch (i)
                        {
                            case 0:
                            case 1:
                                //tableLabel1[i + z].Visible = true;
                                tableLabel2[i + z].Text = Convert.ToString(RD[i]);
                                break;
                            case 2:
                            case 3:
                                switch (Convert.ToInt16(RD[i]))       //判断上班的值：0为不用上班，1为正常上班，2为特殊情况  签到：0为未签到，1为已签到，2为请假
                                {

                                    //tableLabel1[i + z].Visible = true;
                                    case 0:
                                        tableLabel2[i + z].Text = "×";
                                        break;
                                    case 1:
                                        tableLabel2[i + z].Text = "√";
                                        break;
                                    case 2:
                                        tableLabel2[i + z].Text = "○";
                                        break;
                                }
                                break;
                            case 4:
                                tableLabel2[i + z].Text = Convert.ToString(RD[i]);
                                break;
                        }
                    }
                }
                z += 5;
            }
            linksql.CloseSQL();     //闭关数据库
            pageNow.Text = "1";     //当前页码
            pageAll.Text = ((count / 9) + 1).ToString();    //总页面数量  
            if (int.Parse(pageAll.Text) > 1)
            {
                pageUp.Visible = true;
                pageDown.Visible = true;
                MessageBox.Show("共" + pageAll.Text + "页");
            }
            if (((Button)sender).Name == "alter2")
            {
                putIn.Visible = true;
                callOff.Visible = true;
            }
        }

        private System.Data.SqlClient.SqlDataReader AlterSelect()//根据部门选择查询
        {
            LinkSQL linksql = new LinkSQL();
            //System.Data.SqlClient.SqlDataReader dr;

            switch (label4.Text)        //根据部门选择查询
            {
                case "采购部":
                    linksql.SQLSelect(@"select a.employee_ID,a.employee_Name,a.shc,a.sign_in,b.post from sign as a,employee as b where a.employee_ID=b.ID and b.department_ID = 'PU0001'");
                    break;
                case "仓储部":
                    linksql.SQLSelect(@"select a.employee_ID,a.employee_Name,a.shc,a.sign_in,b.post from sign as a,employee as b where a.employee_ID=b.ID and b.department_ID = 'ST0001'");
                    break;
            }
           linksql.OpenSQL();
           return linksql.Comm.ExecuteReader();

        }
        private void Alter2_Click(object sender, EventArgs e)   //应到签到修改按钮事件
        {
            Initial_Data();
            foreach (Label a in tableHead)
            {
                a.Visible = true;
            }
            putIn.Visible = true;
            callOff.Visible = true;
            LinkSQL linksql = new LinkSQL();
            System.Data.SqlClient.SqlDataReader RD;
            int z = 0;      //行控制
            count = 0;      //清空记录
            //AlterSelect(); //根据部门选择查询
            if (((Button)sender).Name == "alter2")
            {
                //linksql.OpenSQL();
                label12.Text = ((Button)sender).Name.ToString();
                RD = AlterSelect();
                while (RD.Read())
                {
                    count++;
                    if (count <= 8)
                    {
                        for (int i = 0; i < RD.FieldCount; i++)
                        {
                            tableLabel1[i + z].Visible = true;
                            switch (i)
                            {
                                case 0:
                                case 1:
                                    tableLabel1[i + z].Visible = true;
                                    tableLabel1[i + z].Text = Convert.ToString(RD[i]);
                                    break;
                                case 2:
                                    tableTextBox1[(count-1)*2].Visible = true;
                                    tableTextBox1[(count - 1) * 2].Text = Convert.ToString(RD[i]);
                                    tableLabel1[i + z].Visible = false;
                                    break;
                                case 3:
                                    switch (Convert.ToInt16(RD[i]))       //判断上班的值：0为不用上班，1为正常上班，2为特殊情况  签到：0为未签到，1为已签到，2为请假
                                    {

                                        //tableLabel1[i + z].Visible = true;
                                        case 0:
                                            tableLabel1[i + z].Text = "×";
                                            break;
                                        case 1:
                                            tableLabel1[i + z].Text = "√";
                                            break;
                                        case 2:
                                            tableLabel1[i + z].Text = "○";
                                            break;
                                    }
                                    break;
                                case 4:
                                    tableLabel1[i + z].Text = Convert.ToString(RD[i]);
                                    break;
                            }
                        }
                    }
                    if (count % 8 == 0)   //新的一页重置格式控制
                    {
                        z = -5;
                    }

                    if (count > 8 && count <= 16)
                    {
                        for (int i = 0; i < RD.FieldCount; i++)
                        {
                            //tableLabel2[i + z].Visible = true;
                            switch (i)
                            {
                                case 0:
                                case 1:
                                    //tableLabel1[i + z].Visible = true;
                                    tableLabel2[i + z].Text = Convert.ToString(RD[i]);
                                    break;
                                case 2:
                                case 3:
                                    switch (Convert.ToInt16(RD[i]))       //判断上班的值：0为不用上班，1为正常上班，2为特殊情况  签到：0为未签到，1为已签到，2为请假
                                    {

                                        //tableLabel1[i + z].Visible = true;
                                        case 0:
                                            tableLabel2[i + z].Text = "×";
                                            break;
                                        case 1:
                                            tableLabel2[i + z].Text = "√";
                                            break;
                                        case 2:
                                            tableLabel2[i + z].Text = "○";
                                            break;
                                    }
                                    break;
                                case 4:
                                    tableLabel2[i + z].Text = Convert.ToString(RD[i]);
                                    break;
                            }
                        }
                    }
                    z += 5;
                }
                linksql.CloseSQL();
            }
            if (((Button)sender).Name == "alter3")
            {
                label12.Text = ((Button)sender).Name.ToString();
                count = 0;
                linksql.OpenSQL();
                RD = AlterSelect();
                //int j = 0;
                while (RD.Read())
                {
                    count++;
                    if (count <= 8)
                    {
                        for (int i = 0; i < RD.FieldCount; i++)
                        {
                            tableLabel1[i + z].Visible = true;
                            switch (i)
                            {
                                case 0:
                                case 1:
                                    tableLabel1[i + z].Visible = true;
                                    tableLabel1[i + z].Text = Convert.ToString(RD[i]);
                                    break;
                                case 2:
                                    switch (Convert.ToInt16(RD[i]))       //判断上班的值：0为不用上班，1为正常上班，2为特殊情况  签到：0为未签到，1为已签到，2为请假
                                    {

                                        //tableLabel1[i + z].Visible = true;
                                        case 0:
                                            tableLabel1[i + z].Text = "×";
                                            break;
                                        case 1:
                                            tableLabel1[i + z].Text = "√";
                                            break;
                                        case 2:
                                            tableLabel1[i + z].Text = "○";
                                            break;
                                    }
                                    tableLabel1[i + z].Visible = true;
                                    break;
                                case 3:
                                    tableLabel1[i + z].Visible = false;
                                    tableTextBox1[count*2-1].Visible = true;
                                    tableTextBox1[count*2-1].Text = Convert.ToString(RD[i]);
                                    //j++;
                                   
                                    break;
                                case 4:
                                    tableLabel1[i + z].Text = Convert.ToString(RD[i]);
                                    break;
                            }
                        }
                    }
                    if (count % 8 == 0)   //新的一页重置格式控制
                    {
                        z = -5;
                    }

                    if (count > 8 && count <= 16)
                    {
                        //j = 0;
                        for (int i = 0; i < RD.FieldCount; i++)
                        {
                            //tableLabel2[i + z].Visible = true;
                            switch (i)
                            {
                                case 0:
                                case 1:
                                    //tableLabel1[i + z].Visible = true;
                                    tableLabel2[i + z].Text = Convert.ToString(RD[i]);
                                    break;
                                case 2:
                                    switch (Convert.ToInt16(RD[i]))       //判断上班的值：0为不用上班，1为正常上班，2为特殊情况  签到：0为未签到，1为已签到，2为请假
                                    {

                                        //tableLabel1[i + z].Visible = true;
                                        case 0:
                                            tableLabel2[i + z].Text = "×";
                                            break;
                                        case 1:
                                            tableLabel2[i + z].Text = "√";
                                            break;
                                        case 2:
                                            tableLabel2[i + z].Text = "○";
                                            break;
                                    }
                                    break;
                                case 3:
                                case 4:
                                    tableLabel2[i + z].Text = Convert.ToString(RD[i]);
                                    break;
                            }
                        }
                    }
                    z += 5;
                }
                linksql.CloseSQL();
            }
            pageNow.Text = "1";     //当前页码
            pageAll.Text = ((count / 9) + 1).ToString();    //总页面数量 
            if (int.Parse(pageAll.Text) > 1)
            {
                pageUp.Visible = true;
                pageDown.Visible = true;
                //MessageBox.Show("共" + pageAll.Text + "页");
            }
            foreach (TextBox a in tableTextBox1)
            {
                a.TextChanged += TextBoxChange_Click;
            }
        }

        private void TextBoxChange_Click(object sender, EventArgs e)
        {
            //int time = 0;       //time   记录触发的次数
            if (ss == 0)   //用此判断使其一个数据只存一次
            {
                ((TextBox)sender).Leave += TextBoxLevel_Click;
            }
            ss++;
        }

        private void TextBoxLevel_Click(object sender, EventArgs e) //记录下被修改的员工的员工号
        {
            ss=0;
            textBoxName[s] = ((TextBox)sender).Name;   
            s++;
        }

        private void PutIn_Click(Label[] tableLabel)//确认提交
        {
            int index = 0;
            string[] tablelabelName = new string[16];
            int[] tableboxValue = new int[16];

            while (textBoxName[index] != null)
            {

                switch (textBoxName[index])
                {
                    case "tableTextBox1_0":
                        tableboxValue[index] = int.Parse(tableTextBox1[0].Text);
                        tablelabelName[index] = tableLabel[0].Text;
                        break;
                    case "tableTextBox1_1":
                        tableboxValue[index] = int.Parse(tableTextBox1[1].Text);
                        tablelabelName[index] = tableLabel[0].Text;
                        break;
                    case "tableTextBox1_2":
                        tableboxValue[index] = int.Parse(tableTextBox1[2].Text);
                        tablelabelName[index] = tableLabel[5].Text;
                        break;
                    case "tableTextBox1_3":
                        tableboxValue[index] = int.Parse(tableTextBox1[3].Text);
                        tablelabelName[index] = tableLabel[5].Text;
                        break;
                    case "tableTextBox1_4":
                        tableboxValue[index] = int.Parse(tableTextBox1[4].Text);
                        tablelabelName[index] = tableLabel[10].Text;
                        break;
                    case "tableTextBox1_5":
                        tableboxValue[index] = int.Parse(tableTextBox1[5].Text);
                        tablelabelName[index] = tableLabel[10].Text;
                        break;
                    case "tableTextBox1_6":
                        tableboxValue[index] = int.Parse(tableTextBox1[6].Text);
                        tablelabelName[index] = tableLabel[15].Text;
                        break;
                    case "tableTextBox1_7":
                        tableboxValue[index] = int.Parse(tableTextBox1[7].Text);
                        tablelabelName[index] = tableLabel[15].Text;
                        break;
                    case "tableTextBox1_8":
                        tableboxValue[index] = int.Parse(tableTextBox1[8].Text);
                        tablelabelName[index] = tableLabel1[20].Text;
                        break;
                    case "tableTextBox1_9":
                        tableboxValue[index] = int.Parse(tableTextBox1[9].Text);
                        tablelabelName[index] = tableLabel1[20].Text;
                        break;
                    case "tableTextBox1_10":
                        tableboxValue[index] = int.Parse(tableTextBox1[10].Text);
                        tablelabelName[index] = tableLabel1[25].Text;
                        break;
                    case "tableTextBox1_11":
                        tableboxValue[index] = int.Parse(tableTextBox1[11].Text);
                        tablelabelName[index] = tableLabel1[25].Text;
                        break;
                    case "tableTextBox1_12":
                        tableboxValue[index] = int.Parse(tableTextBox1[12].Text);
                        tablelabelName[index] = tableLabel1[30].Text;
                        break;
                    case "tableTextBox1_13":
                        tableboxValue[index] = int.Parse(tableTextBox1[13].Text);
                        tablelabelName[index] = tableLabel1[30].Text;
                        break;
                    case "tableTextBox1_14":
                        tableboxValue[index] = int.Parse(tableTextBox1[14].Text);
                        tablelabelName[index] = tableLabel1[35].Text;
                        break;
                    case "tableTextBox1_15":
                        tableboxValue[index] = int.Parse(tableTextBox1[15].Text);
                        tablelabelName[index] = tableLabel1[35].Text;
                        break;
                }
                index++;
            }
            DialogResult dr = MessageBox.Show("确认提交信息？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.OK)
            {
                int x = 0, sum = 0;
                LinkSQL linksql = new LinkSQL();
                linksql.OpenSQL();
                for (int i = 0; tablelabelName[i] != null/*tableTextBox1[i * 2].Visible == true*/; i++)
                {
                    foreach (Label a in tableLabel1)
                    {
                        if (a.Text == tablelabelName[i])
                        {
                            if (label12.Text == "alter2")    //判断当前触修改的列
                            {
                                x += linksql.SQLInsert(@"update sign set SHC = " + tableboxValue[i] + " where employee_ID = '" + a.Text + "'");
                            }
                            if (label12.Text == "alter3")    //判断当前触修改的列
                            {
                                x += linksql.SQLInsert(@"update sign set sign_in = " + tableboxValue[i] + " where employee_ID = '" + a.Text + "'");
                            }
                        }
                    }
                    foreach (Label a in tableLabel2)
                    {
                        if (a.Text == tablelabelName[i])
                        {
                            if (label12.Text == "alter2")    //判断当前触修改的列
                            {
                                x += linksql.SQLInsert(@"update sign set SHC = " + tableboxValue[i] + " where employee_ID = '" + a.Text + "'");
                            }
                            if (label12.Text == "alter3")    //判断当前触修改的列
                            {
                                x += linksql.SQLInsert(@"update sign set sign_in = " + tableboxValue[i] + " where employee_ID = '" + a.Text + "'");
                            }
                        }
                    }
                    sum += 1;
                }
                linksql.CloseSQL();
                if (sum == x && sum != 0)
                {
                    MessageBox.Show("修改成功", "修改结果");
                }
                else if (sum != 0 && (sum - x) == 0)
                {
                    MessageBox.Show("修改失败", "修改结果");
                }
                else if (sum == 0)
                {
                    MessageBox.Show("未发生改变", "提示");
                }
                else
                {
                    MessageBox.Show("出现故障,请自行检查！\n修改成功" + x.ToString() + "条，" + (sum - x).ToString() + "条", "修改结果", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                return;
            }
            s = 0;
            foreach (TextBox a in tableTextBox1)
            {
                a.Leave -= TextBoxLevel_Click;
                a.TextChanged -= TextBoxChange_Click;
            }

            Initial_Data();
            Initial_BaseData();     //刷新显示
            textBoxName = new string[16];
        }


        private void PutIn_Click(object sender,EventArgs e)//提交按钮事件
        {
            try
            {
                switch (pageNow.Text)
                {
                    case "1": PutIn_Click(tableLabel1); break;
                    case "2": PutIn_Click(tableLabel2); break;
                }
            }
            catch
            {
                MessageBox.Show("修改失败！","警告",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void pageDown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)       //下一页
        {
            foreach (TextBox a in tableTextBox1)
            {
                a.Visible = false;
            }
            if (int.Parse(pageNow.Text) < int.Parse(pageAll.Text))
            {
                pageNow.Text = (int.Parse(pageNow.Text) + 1).ToString();
                foreach (Label a in tableLabel1)
                {
                    a.Visible = false;
                }
                for (int z = 0; z < count - 8; z++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        tableLabel2[i + z].Visible = true;
                    }
                }


                if (putIn.Visible == true)
                {
                    //---------------------------------------------------------重新给tableTextBox1赋值
                    int coun = 0;       //记录行数
                    int j = 0;
                    System.Data.SqlClient.SqlDataReader DR;
                    DR = AlterSelect();
                    while (DR.Read())
                    {
                        if (coun>=8)
                        {
                            tableTextBox1[(coun - 8)*2].Text = DR[2].ToString();
                            tableTextBox1[(coun - 7)*2-1].Text = DR[3].ToString();
                        }
                        coun++;
                        j++;
                    }
                    //---------------------------------------------------------重新给tableTextBox1赋值（结束）
                    int x = count - 8;
                    for (int i = 0, z = 0; i < tableLabel2.Length; i++)
                    {
                        if (label12.Text == "alter2")
                        {
                            if (i % 5 == 2 && x > 0)
                            {
                                tableLabel2[i].Visible = false;
                                tableTextBox1[z * 2].Visible = true;
                                z += 1;
                                x -= 1;
                            }
                        }
                        if (label12.Text == "alter3")
                        {
                            if (i % 5 == 3 && x > 0)
                            {
                                tableLabel2[i].Visible = false;
                                tableTextBox1[z * 2].Visible = false;
                                tableTextBox1[2 * z + 1].Visible = true;
                                z += 1;
                                x -= 1;
                            }
                        }
                        
                    }
                    try
                    {
                        switch (int.Parse(pageNow.Text)-1)
                        {
                            case 1: PutIn_Click(tableLabel1); break;
                            case 2: PutIn_Click(tableLabel2); break;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("修改失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void pageUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)   //上一页
        {
            foreach (TextBox a in tableTextBox1)
            {
                a.Visible = false;
            }
            if (int.Parse(pageNow.Text) > 1)
            {
                pageNow.Text = (int.Parse(pageNow.Text) - 1).ToString();
                foreach (Label a in tableLabel2)
                {
                    a.Visible = false;
                }
                foreach (Label a in tableLabel1)
                {
                    a.Visible = true;
                }

            }
            if (putIn.Visible == true)
            {
                //---------------------------------------------------------重新给tableTextBox1赋值
                int coun = 0;       //记录行数
                System.Data.SqlClient.SqlDataReader DR;
                DR = AlterSelect();
                while (DR.Read())
                {
                    if (coun < 8)
                    {
                        tableTextBox1[coun].Text = DR[2].ToString();
                    }
                    coun++;
                }
                //---------------------------------------------------------重新给tableTextBox1赋值（结束）
                int x = count - 8;
                for (int i = 0, z = 0; i < tableLabel1.Length; i++)
                {
                    if (i % 5 == 2)
                    {
                        tableLabel1[i].Visible = false;
                        tableTextBox1[z * 2].Visible = true;
                        z += 1;
                    }
                }
            }
        }



        private void TableHead()   //表头属性
        {
            int locationX = -120, locationY = 10;
            //tableLbabl表头
            for (int i = 0; i < tableHead.Length; i++)
            {
                tableHead[i] = new Label();
                tableHead[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                tableHead[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                tableHead[i].Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold);
                tableHead[i].Location = new System.Drawing.Point(locationX += 130, locationY);
                tableHead[i].Name = "tableLable";
                tableHead[i].Size = new System.Drawing.Size(130, 50);
                tableHead[i].TabIndex = 0;
                //tableHead[i].Text = i.ToString();
                tableHead[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tableHead[i].Visible = false;
                tablePanel.Controls.Add(tableHead[i]);
            }
            tableHead[4].Size = new Size(150,50);

        } 

        private void TableLabel(Label[] tableLabel)        //表格属性     
        {
            int z = 0;
            int X = -120, Y = 25;
            for (int i = 0; i < 8; i++)
            {
                Y += 35;
                for (int t = 0; t < 5; t++)
                {
                    tableLabel[t + z] = new Label();
                    tableLabel[t + z].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                    tableLabel[t + z].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    tableLabel[t + z].Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold);
                    if (t == 4)
                    {
                        tableLabel[t + z].Location = new System.Drawing.Point(X += tableHead[t - 1].Width, Y);
                    }
                    else
                    {
                        tableLabel[t + z].Location = new System.Drawing.Point(X += tableHead[t].Width, Y);
                    }
                    tableLabel[t + z].Name = "tableLable";
                    tableLabel[t + z].Size = new System.Drawing.Size(tableHead[t].Width, 35);
                    tableLabel[t + z].TabIndex = 0;
                    tableLabel[t + z].Visible = false; 
                    tableLabel[t+z].Text = (t + z).ToString();
                    tableLabel[t + z].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    tablePanel.Controls.Add(tableLabel[t + z]);
                    
                }
                z += 5;
                X = -120;
                
            }
            
        }

        private void TableTextBox(TextBox[] tableTextBox)//设计表格TEXTBOX属性
        {
            int z = 2;
            int p = 0;
            for (int t = 0; t < 8; t++)
            {
                for (int i = 0; i < 2; i++)
                {
                    tableTextBox[i + t+p] = new TextBox();
                    tableTextBox[i + t+p].Multiline = true;
                    tableTextBox[i + t+p].Size = tableLabel1[i + t+z].Size;
                    tableTextBox[i + t+p].Location = tableLabel1[i +t+ z].Location;
                    tableTextBox[i + t+p].BorderStyle = BorderStyle.FixedSingle;
                    tableTextBox[i + t+p].BackColor = Color.White;
                    tableTextBox[i + t+p].Text = (i +t+ p).ToString();
                    tableTextBox[i + t+p].Font = tableLabel1[i + z].Font;
                    tableTextBox[i + t+p].TextAlign = HorizontalAlignment.Center;
                    tableTextBox[i + t+p].Visible = false;
                    //tableLabel1[i + t + z].Visible = false;
                    //tableTextBox[i + t + p].Leave += TextBoxLevel_Click;
                    tablePanel.Controls.Add(tableTextBox[i + t+p]);
                }
                z += 4;
                p += 1;
            }
            for (int i = 0; i < tableTextBox1.Length; i++)
            {
                tableTextBox1[i].Name = "tableTextBox1_" + i.ToString();
            }
        }

        private void Department1_Clicked(object sender, EventArgs e)//采购部linklabel事件
        {
            Initial_Data();
            

            //LinkSQL linksql = new LinkSQL();        //连接数据库
            panel1.Visible = true;
            label1.Text = "采购部管理";
            label4.Text = "采购部";
            Initial_BaseData();
        }

        private void Department2_Clicked(object sender, EventArgs e)//仓储部button事件
        {
            
            
            Initial_Data();
            
            //LinkSQL linksql = new LinkSQL();        //创建数据库连接
            
            panel1.Visible = true;
            label1.Text = "仓储部管理";
            label4.Text = "仓储部";
            Initial_BaseData();
        }

        private void Initial_BaseData()
        {
            LinkSQL linksql = new LinkSQL();        //创建数据库连接
            switch(label4.Text)
            {
                case "仓储部":
                linksql.OpenSQL();
                linksql.SQLSelect(@"select content from notice where department_id = 'ST0001' order by date desc");
                BulletinBoardCentent.Text = linksql.Comm.ExecuteScalar().ToString();
                linksql.SQLSelect(@"select COUNT(*) from employee where department_ID = 'ST0001'");
                label6.Text = linksql.Comm.ExecuteScalar().ToString();
                linksql.SQLSelect(@"select COUNT(*) from sign,employee where SHC = 1 and employee_ID = employee.ID  and employee.department_ID = 'ST0001'");
                label8.Text = linksql.Comm.ExecuteScalar().ToString();
                linksql.SQLSelect(@"select COUNT(*)from sign,employee where sign_in = 1 and employee_ID = employee.ID  and employee.department_ID = 'ST0001'");
                label10.Text = linksql.Comm.ExecuteScalar().ToString();
                linksql.CloseSQL();
                    break;
                case "采购部":
                    linksql.OpenSQL();
                    linksql.SQLSelect(@"select content from notice where department_id = 'PU0001' order by date desc");
                    BulletinBoardCentent.Text = linksql.Comm.ExecuteScalar().ToString();  //公告
                    linksql.SQLSelect(@"select COUNT(*) from employee where department_ID = 'PU0001'");
                    label6.Text = linksql.Comm.ExecuteScalar().ToString();     //
                    linksql.SQLSelect(@"select COUNT(*) from sign,employee where SHC = 1 and employee_ID = employee.ID  and employee.department_ID = 'PU0001'");
                    label8.Text = linksql.Comm.ExecuteScalar().ToString();
                    linksql.SQLSelect(@"select COUNT(*)from sign,employee where sign_in = 1 and employee_ID = employee.ID  and employee.department_ID = 'PU0001'");
                    label10.Text = linksql.Comm.ExecuteScalar().ToString();
                    linksql.CloseSQL();
                    break;
            }
        }
        private void callOff_Click(object sender, EventArgs e)
        {
            if (putIn.Visible == true)
            {
                callOff.Click += LookUp2_Click;
            }
            add.Visible = false;
            callOff.Visible = false;
        }
    }
}
