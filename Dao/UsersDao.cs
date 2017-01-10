using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dao
{
    public class UsersDao
    {
        public static int AddUser(Users user)
        {
            string cols = @"name, age, address";
            string sql = $@"insert into users({cols}) values(@name, @age,@address')";
            SqlParameter[] param =
            {
                Helper.MakeInParam("@name",(DbType)SqlDbType.NVarChar,50,user.Name),
                Helper.MakeInParam("@age",(DbType)SqlDbType.Int,4,user.Age),
                Helper.MakeInParam("@address",(DbType)SqlDbType.NVarChar,500,user.Address)
            };
            return Helper.ExecuteScalar(sql, param);
        }
    }
}
