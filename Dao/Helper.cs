using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Dao
{
    public class Helper
    {
        private string ConnStr = ConfigurationManager.AppSettings["ConnectionStr"].ToString();
        public Helper()
        {
            string conStr = ConfigurationManager.AppSettings["ConnectionStr"].ToString();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = conStr;
                conn.Open();
                SqlCommand commd = new SqlCommand();
                commd.Connection = conn;
                commd.CommandType = CommandType.Text;
                commd.CommandText = "select * from Users where id=@id and name=@name";

                #region MyRegion
                //object value=string.Empty;
                ////获取或设置一个值，该值指示参数是只可输入、只可输出、双向还是存储过程返回值参数。
                //ParameterDirection param_direction = ParameterDirection.Input;
                ////参数是输入参数却没有赋值的情况,将其分配以DBNull.Value           
                //if (ParameterDirection.Input==param_direction && value == null)
                //{
                //    value=DBNull.Value;
                //}
                //SqlParameter param1 = new SqlParameter("@name", SqlDbType.NVarChar, 50, value.ToString());
                //param1.Direction = param_direction;
                //commd.Parameters.Add(param1); 
                #endregion

                SqlParameter[] parames = new SqlParameter[]
                {
                    new SqlParameter("@id",SqlDbType.Int,4,1.ToString()), 
                    new SqlParameter("@name",SqlDbType.NVarChar,50,"张三")
                };
                foreach(SqlParameter p in parames)
                {
                    if (p.Direction == ParameterDirection.Input && p.Value == null)
                    {
                        p.Value = DBNull.Value;
                    }
                    commd.Parameters.Add(p);
                }
                //commd.Parameters.AddRange(parames);
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        commd.Transaction = tran;
                        SqlDataReader dr = commd.ExecuteReader();           
                        dr.Close();
                        tran.Commit();                                             
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                    finally
                    {
                        tran.Dispose();
                    }
                }                    
            }
        }

        public void ExecuteScalar()
        {
            using(SqlConnection conn=new SqlConnection())
            {
                conn.ConnectionString = ConnStr;
                conn.Open();
            }
        }

        public static SqlParameter MakeInParam(string paramName,DbType type,int size,object value)
        {
            return MakeParams(paramName, type, size, value, ParameterDirection.Input);
        }

        public static SqlParameter MakeParams(string paramName, DbType type, int size, object value,ParameterDirection direction)
        {
            SqlParameter parameter = new SqlParameter(paramName, (SqlDbType)type, size);
            if (!(ParameterDirection.Output==direction && value==null))
            {
                parameter.Value = value;
            }
            return parameter;
        }



    }
}
