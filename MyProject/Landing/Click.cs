using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Landing;
using MyProject.Main;
using System.Windows.Forms;

namespace MyProject.Landing
{
    class Click
    {
     //   Property pro = new Property();
        
        public int Check(string id,string root)
        {
           return CheckUserLand(id,root);
        }

        public int CheckAdmin(string id,string root)
        {
            return CheckAdminLand(id,root);
        }
        /// <summary>
        /// 普通用户登陆
        /// </summary>
        /// <param name="id">用户名</param>
        /// <param name="root">密码</param>
        /// <returns></returns>
        private int CheckUserLand(string id, string root)     //普通用户登陆验证
        {
            LinkSQL LandLinkSql = new LinkSQL();
            try
            {
                LandLinkSql.OpenSQL();
            }
            catch
            {
                MessageBox.Show("打开连接服务器失败!");    //打开数据库失败
                Application.Exit();
            }

            string Sql;
            Sql = "select count(*) from theUser where ID = '" + id + "' and Password = '" + root + "'" + " and theidentity = '普通用户'";
            int Value;
            LandLinkSql.SQLSelect(Sql);
            Value = (int)LandLinkSql.Comm.ExecuteScalar();
            if (Value == 0)
            {
                MessageBox.Show("您输入的用户名或密码错误，请重新输入");
                return 0;
            }
            else
                if (Value == 1)
                {
                    
                    LandLinkSql.CloseSQL();
                return 1;
                }

                else
                {
                    MessageBox.Show("异常错误");
                    return 0;
                }

        }
        /// <summary>
        /// 管理员登陆验证
        /// </summary>
        /// <param name="id">用户名</param>
        /// <param name="root">密码</param>
        /// <returns></returns>
        private int CheckAdminLand(string id,string root)     
        {
            LinkSQL landLinkSQL = new LinkSQL();
            try
            {
                landLinkSQL.OpenSQL();
            }
            catch
            {
                MessageBox.Show("连接服务器失败");    //打开数据库失败
                Application.Exit();
            }
            string T_SQL;
            int value = 0;
            T_SQL = "select count(*) from theUser where ID = '" + id + "' and Password = '" + root + "'" + " and theidentity = '管理员'";
            landLinkSQL.SQLSelect(T_SQL);
            value = (int)landLinkSQL.Comm.ExecuteScalar();
            if (value == 0)
            {
                landLinkSQL.CloseSQL();
                MessageBox.Show("您输入的用户名或密码错误，请重新输入");
                return 0;
            }
            else
                if (value == 1)
            {

                landLinkSQL.CloseSQL();
                return 1;
            }

            else
            {
                landLinkSQL.CloseSQL();
                MessageBox.Show("异常错误");
                return 0;
            }
        }
    }
}
