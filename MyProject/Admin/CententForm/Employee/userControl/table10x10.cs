using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/// <summary>
/// 这是一个10*10的表格，在外部可以通过索引器来访问或修改每个单元格的属性
/// 访问head的索引用字符串型索引，table用整形索引
/// </summary>
namespace TABLE_10X10_
{
    public partial class table10x10: UserControl
    {
        Label[] head = new Label[10];
        Label[] table = new Label [100];
        public table10x10()
        {

            InitializeComponent();
            HeadPro();
            TablePro();
            
        }
        int hi = 0;
        public Label this[string i]
        {
            set
            {
                hi = int.Parse(i);
                head[hi] = value;
            }
            get
            {
                hi = int.Parse(i);
                return head[hi];
            }
        }     //表头的索引器

        public Label this[int i]
        {
            set { table[i] = value; }
            get { return table[i]; }
        }         //表格的索引器

        private void HeadPro()
        {
            int locationX = -96, locationY = 0;
            //tableLbabl表头
            for (int i = 0; i < head.Length; i++)
            {
                head[i] = new Label();
                head[i].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                head[i].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                head[i].Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold);
                head[i].Location = new System.Drawing.Point(locationX += 100, locationY);
                head[i].Name = "tableLable";
                head[i].Size = new System.Drawing.Size(100, 30);
                head[i].TabIndex = 0;
                head[i].Text = i.ToString();
                head[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                this.Controls.Add(head[i]);
            }
        }

        private void TablePro()        //表格属性     
        {
            int z = 0;
            int X = -96, Y = 30;
            for (int i = 0; i < 10; i++)
            {
                Y += 30;
                for (int t = 0; t < 10; t++)
                {
                    table[t + z] = new Label();
                    table[t + z].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                    table[t + z].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    table[t + z].Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold);
                    table[t + z].Location = new System.Drawing.Point(X += 100, Y);
                    table[t + z].Name = "tableLable";
                    table[t + z].Size = new System.Drawing.Size(100, 30);
                    table[t + z].TabIndex = 0;
                    table[t + z].Visible = true;
                    //table[t+z].Text = (t + z).ToString();
                    table[t + z].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    this.Controls.Add(table[t + z]);
                }
                z += 10;
                X = -96;
            }
        }
    }
}
