using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject.Main
{
    public partial class Main : property
    {
        public Main()
        {
            
            InitializeComponent();
            
            this.CenterToScreen();
            
        }
        private void ShowLanding(object sender, EventArgs e)
        {
            Land landing = new Land();
            landing.ShowDialog();
        }
    }
}
