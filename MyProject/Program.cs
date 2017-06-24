using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyProject.Main;
using MyProject.Landing;
using MyProject.Admin;
namespace MyProject
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Admin.CententForm.Employee.Information());
            //Application.Run(new Admin.CententForm.Employee.Applicants());
            Land landing = new Land();
            landing.ShowDialog();
            if (landing.DialogResult == DialogResult.Yes)
            {
                Application.Run(new Main.Main());
            }
            if (landing.DialogResult == DialogResult.OK)
            {
                Application.Run(new Admin.Main());
            }
            if (landing.DialogResult == DialogResult.No)
            {
                Application.Exit();
            }

        }
    }
}
