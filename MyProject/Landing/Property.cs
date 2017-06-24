using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MyProject.Landing;


/// <summary>
/// Landing窗口的所用控件和窗口属性存放在此文件中
/// </summary>

namespace MyProject.Landing
{
    public class Property : Form
    {
        public String ID;
        public String PASSWORD;
        public void LandProperty()       //Land窗口的基本属性
        {
            this.Size = new Size(480 + 15, 300 + 35);
            this.Text = "用户登陆";
            this.ShowIcon = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.MaximizedBounds = new Rectangle((1920-1600)/2,(1080-900)/2, 1600, 900);
            //this.SizeChanged +=
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackgroundImage = Image.FromFile(@"..\..\img\backgroup\landing.png");
            this.CenterToScreen();
            this.FormClosed += CloseApp;
        }
      
        public void LabelProperty()   //Land窗口中的文字
        {
            //LinkLabel backRoot = new LinkLabel();

            Label[] laber = new Label[4];
            for (int i = 0; i < 4; i++)
            {
                laber[i] = new Label();
            }

            laber[0].Text = "欢迎使用XX管理系统";
            laber[1].Text = "用户登陆";
            laber[2].Text = "用户名：";
            laber[3].Text = "密    码：";
            //
            //
            laber[0].Location = new Point(207+15, 51+18);
            laber[0].Font = new Font("Adobe 黑体 Std", 18);
            laber[0].Size = new Size(300, 30);
            laber[0].BackColor = Color.Transparent;
            laber[0].ForeColor = Color.White;

            laber[1].Location = new Point(265 + 15, 84 + 18);
            laber[1].Font = new Font("Adobe 黑体 Std", 18);
            laber[1].Size = new Size(150, 30);
            laber[1].BackColor = Color.Transparent;
            laber[1].ForeColor = Color.White;

            laber[2].Location = new Point(213 + 15, 137 + 18);
            laber[2].Font = new Font("Adobe 黑体 Std", 12);
            laber[2].Size = new Size(75, 20);
            laber[2].BackColor = Color.Transparent;
            laber[2].ForeColor = Color.Black;


            laber[3].Location = new Point(213 + 15, 163 + 18);
            laber[3].Font = new Font("Adobe 黑体 Std", 12);
            laber[3].Size = new Size(75, 20);
            laber[3].BackColor = Color.Transparent;
            laber[3].ForeColor = Color.Black;

            this.Controls.Add(laber[0]);
            this.Controls.Add(laber[1]);
            this.Controls.Add(laber[2]);
            this.Controls.Add(laber[3]);
        }
        public  TextBox id = new TextBox();
        public TextBox root = new TextBox();
        public void TextBoxProperty()
        {


            id.Size = new Size(130, 30);
            id.Location = new Point(273 + 15, 139 + 18);
            this.Controls.Add(id);

            root.Size = new Size(130, 30);
            root.Location = new Point(273 + 15, 165 + 18);
            root.PasswordChar = '*';
            this.Controls.Add(root);
        }      //Land窗口中的textBox


        public void Buttonproperty()
        {

            Button landBtn = new Button();
            Button adminLandBtn = new Button();
            landBtn.Size = new Size(80,25);
            adminLandBtn.Size = new Size(80, 25);
            landBtn.Font = new Font("黑体",8);
            adminLandBtn.Font = new Font("黑体",8);
            landBtn.Text = "普通登陆";
            adminLandBtn.Text = "管理员登陆";
            landBtn.Location = new Point(230+15,215+18);
            adminLandBtn.Location = new Point(340+12,215+18);
            landBtn.Click += CheckLand;
            adminLandBtn.Click += CheckAdminLand;
            this.Controls.Add(landBtn);
            this.Controls.Add(adminLandBtn);
        }     //Land窗口中的按钮

        private void CheckLand(object sender,EventArgs e)        //普通用户登陆按钮
        {
            ID = id.Text;
            PASSWORD = root.Text;
            MyProject.Landing.Click c = new Landing.Click();
            if (c.Check(ID, PASSWORD)==1)
            {
                
                this.FormClosed += OpenMain;
                this.Close();
            }
            else
            {
                id.SelectAll() ;
                return;           
            }
        }

        private void CheckAdminLand(object sender, EventArgs e)
        {
            ID = id.Text;
            PASSWORD = root.Text;
            MyProject.Landing.Click c = new Landing.Click();
            if (c.CheckAdmin(ID, PASSWORD) == 1)
            {
                this.FormClosed += OpenAdmin;
                this.Close();
            }
            else
            {
                id.SelectAll();
                return;
            }
        }

        private void OpenMain(object sender, EventArgs e)     //普通用户身份验证成功
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void OpenAdmin(object sender, EventArgs e)     //管理员身份验证成功
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CloseApp(object sender,EventArgs e)    //结束进程
        {
            this.DialogResult = DialogResult.No;
        }

       
        


    }
}
