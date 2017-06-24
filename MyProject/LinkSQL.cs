using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MyProject
{
    class LinkSQL
    {
        SqlConnection conn = new SqlConnection();
        private SqlCommand comm = new SqlCommand();

        public SqlCommand Comm { get => comm; set => comm = value; }
        public SqlConnection Conn { get => conn; set => conn = value; }

        /// <summary>
        /// 打开数据库连接
        /// </summary>
        public void OpenSQL()      //连接数据库
        {
            try
            {
                Conn.ConnectionString = "Data Source=(local);Initial Catalog=ERP; Integrated Security=SSPI";
                Conn.Open();
                Comm.Connection = Conn;
                Comm.CommandType = CommandType.Text;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("无法连接到服务器！","服务器无响应",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
        }
        /// <summary>
        /// 查询语句，未执行
        /// </summary>
        /// <param name="T_sql"></param>
        public void SQLSelect(string T_sql)    //执行查询语句
        {
            Comm.CommandText = T_sql;
        }
        /// <summary>
        /// 执行插入、删除或更新语句，返回影响的行数
        /// </summary>
        /// <param name="T_SQL"></param>
        /// <returns></returns>
        public int SQLInsert(string T_SQL)    //执行插入、删除或更新语句
        {
            int i;
            Comm.CommandText = T_SQL;
            i = Comm.ExecuteNonQuery();
            return i;
        }
        /// <summary>
        /// 关闭数据库
        /// </summary>
        public void CloseSQL()     //关闭数据库
        {
            Conn.Close();
        }
    }
}
