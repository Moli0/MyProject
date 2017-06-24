using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyProject.Admin.NavPanel
{
    public partial class NavMenu : Form
    {
        public NavMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }



        public ToolStripMenuItem BaseTool
        {
            set { baseInfo = value; }
            get { return baseInfo; }
        }
        public ToolStripMenuItem PersonTool
        {
            set { person = value; }
            get { return person; }
        }

        public ToolStripMenuItem PersonInformation
        {
            set { employee = value; }
            get { return employee; }
        }
        public ToolStripMenuItem PersonDepartment
        {
            set { department = value; }
            get { return department; }
        }

        public ToolStripMenuItem PersonAddEmployee
        {
            set { addEmployee = value; }
            get { return addEmployee; }
        }

        public ToolStripMenuItem PersonDemand
        {
            set { demand = value; }
            get { return demand; }
        }
        public ToolStripMenuItem PersonApplicants
        {
            set { seeApplicants = value; }
            get { return seeApplicants; }
        }

    }
}
