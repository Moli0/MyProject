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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
            this.Size = new Size(1600 - 203, 900 - 60);
            this.Text = "人员管理";
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public LinkLabel Information
        {
            set { information = value; }
            get { return information; }
        }

        public LinkLabel Department
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
