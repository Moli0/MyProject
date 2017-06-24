using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject.Admin.CententForm
{
    public partial class BaseInformation : Form
    {
        
        public BaseInformation()
        {
            
            InitializeComponent();
            this.Size = new Size(1600-173,900-60);
            this.Text = "基本信息管理";
            this.FormBorderStyle = FormBorderStyle.None;
           
            this.SizeChanged += FrmSizeChange_Click;
            /*MessageBox.Show(panel1.Location.ToString());
            MessageBox.Show(panel2.Location.ToString());
            MessageBox.Show(panel1.Size.ToString());
            MessageBox.Show(panel5.Location.ToString());*/
            //OneFont(linkLabel1);
            //linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            //this.pictureBox1.Image = Image.FromFile(@"..\..\img\person.png");

        }

        

        private void FrmSizeChange_Click(object sender,EventArgs e)
        {
            /* foreach (Control a in this.Controls)
             {
                 int w = a.Size.Width / this.Size.Width;
                 int h = a.Size.Height/this.Size.Height;
             }*/
            if (this.Width / (panel1.Width + 82) > 3)
            {
                panel4.Location = new Point(((panel1.Width + 82) * 3) + 42, 24);
                panel5.Location = new Point(42,285);
            }
            else
            {
                panel4.Location = new Point(42, 285);
                panel5.Location = new Point(426, 285);
            }
        }

        private void OneFont(Control c)
        {
            c.Font = new Font("楷体",30);
            c.ForeColor = Color.Green;
        }
        //bug
        private void person_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        public LinkLabel Person
        {
            set { person = value; }
            get { return person; }
        }
        public LinkLabel PersonInformation
        {
            set { personInformation = value; }
            get { return personInformation; }
        }

        public LinkLabel PersonDepartment
        {
            set { department = value; }
            get { return department; }
        }

        public LinkLabel AddEmployee
        {
            set { addEmployee = value; }
            get { return addEmployee; }
        }

        public LinkLabel PersonDemand
        {
            set { personDemand = value; }
            get { return personDemand; }
        }


    }
}
