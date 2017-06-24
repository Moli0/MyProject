using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject.Admin.CententForm.Employee.WinForm.My
{
    public class MyException : Exception
    {
        public MyException(){}
        public MyException(string msg) : base(msg){ }
        public MyException(string msg, Exception e) : base(msg, e) { }
    }

    public partial class MyMessageBox :Form          //这是一个失败的消息框
    {
        /// <summary>
        /// 消息框图标路径
        /// </summary>
        private string[] path = new string[20];
        /// <summary>
        /// 消息框显示的按钮
        /// </summary>
        public enum MyMessageBoxButton
        {
            /// <summary>
            /// 只显示确定按钮（默认）
            /// </summary>
            OK,
            /// <summary>
            /// 只显示取消按钮
            /// </summary>
            Cancel,
            /// <summary>
            /// 显示确定和取消按钮，能返回不同的值
            /// </summary>
            OKCancel
        }
        /// <summary>
        /// 弹出提示的图标，默认None
        /// </summary>
        public enum MyMessageBoxIcon
        {
            /// <summary>
            /// 默认无图标
            /// </summary>
            None,
            /// <summary>
            /// 错误提示，由一个红色的圆和一个白色的X组成
            /// </summary>
            Error,
            /// <summary>
            /// 警告图标,由一个黄三角和一个感叹号组成
            /// </summary>
            Warning,
            /// <summary>
            /// 消息图标，由一个蓝色的圆和一具i组成
            /// </summary>
            Asterisk,
            /// <summary>
            /// 询问图标,由一个蓝色的圆和一个白色的问号组成 
            /// </summary>
            Question
        }
        /// <summary>
        /// 初始化类
        /// </summary>
        public MyMessageBox()
        {
            InitializeComponent();
            path[0] = @"..\..\img\icon\Error.png";
            path[1] = @"..\..\img\icon\Warning.png";
            path[2] = @"..\..\img\icon\Asterisk.png";
            path[3] = @"..\..\img\icon\Question.png";
            this.Load += MyMessageBox_Load;
        }
        /// <summary>
        /// 打开窗口前发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyMessageBox_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (pictureBox1.Visible == false)
            {
                label1.Location = new Point(15, 60);
            }
        }
        private new void Show()
        {
            throw new Exception("引发异常，不允许调用无参构造函数");
        }
        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="text">消息内容</param>
        public void Show(string text)
        {
            this.label1.Text = text;
            this.ShowDialog();
        }
        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="text">消息内容</param>
        /// <param name="title">标题</param>
        public void Show(string text, string title)
        {
            this.Text = title;
            this.label1.Text = text;
            this.ShowDialog();
        }
        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="text">消息内容</param>
        /// <param name="title">标题</param>
        /// <param name="MessageBoxButton">按钮类型（默认OK）</param>
        public void Show(string text, string title, MyMessageBoxButton MessageBoxButton)
        {
            this.Text = title;
            this.label1.Text = text;
            switch (MessageBoxButton)
            {
                case MyMessageBoxButton.OK:
                    button1.Visible = true;
                    button1.Location = button2.Location;
                    button2.Visible = false;
                    break;
                case MyMessageBoxButton.Cancel:
                    button1.Visible = false;
                    button2.Visible = true;
                    break;
                case MyMessageBoxButton.OKCancel:
                    button1.Visible = true;
                    button2.Visible = true;
                    break;
            }
            this.ShowDialog();
        }
        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="text">消息内容</param>
        /// <param name="title">标题</param>
        /// <param name="MessageBoxButton">按钮类型（默认OK）</param>
        /// <param name="MessageBoxIcon">消息图标（默认不显示）</param>
        public void Show(string text,string title,MyMessageBoxButton MessageBoxButton,MyMessageBoxIcon MessageBoxIcon)
        {
            this.Text = title;
            this.label1.Text = text;
            switch (MessageBoxButton)
            {
                case MyMessageBoxButton.OK:
                    button1.Visible = true;
                    button1.Location = button2.Location;
                    button2.Visible = false;
                    break;
                case MyMessageBoxButton.Cancel:
                    button1.Visible = false;
                    button2.Visible = true;
                    break;
                case MyMessageBoxButton.OKCancel:
                    button1.Visible = true;
                    button2.Visible = true;
                    break;
            }
            switch (MessageBoxIcon)
            {
                case MyMessageBoxIcon.None:
                    pictureBox1.Visible = false;
                    break;
                case MyMessageBoxIcon.Error:
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(path[0]);
                    break;
                case MyMessageBoxIcon.Warning:
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(path[1]);
                    break;
                case MyMessageBoxIcon.Asterisk:
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(path[2]);
                    break;
                case MyMessageBoxIcon.Question:
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(path[3]);
                    break;
            }
            this.ShowDialog();
        }
        /// <summary>
        /// 确定按钮，使窗口的DialogResult值为OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 取消按钮，确定按钮，使窗口的DialogResult值为Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
