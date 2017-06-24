using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyProject.Landing;

namespace MyProject
{
    public partial class Land : Property
    {

        public Land()
        {
            InitializeComponent();
            LandProperty();     //基本属性
            TextBoxProperty();   //文本框
            LabelProperty();    //文字
            Buttonproperty();   //按钮

            
        }
    }
}
