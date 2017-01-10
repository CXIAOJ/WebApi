using BRC.Common.Library.Sql;
using BRC.Common.Library.Sql.DBCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class Users
    {
        public Base db = null;
        public Users()
        {
            if (db == null)
            {
                db = new SQLHelper(SQLHelper.SQLServerConnection);
            }
        }

        public void GetListByPaged(string tableName, int total, int pageindex, int pagesize)
        {
            int low = (pageindex - 1) * pagesize > total ? total : (pageindex - 1) * pagesize;
            int high = (pageindex - 1) * pagesize > total ? total : (pageindex - 1) * pagesize;
            string sqlstr = $@"select * from {tableName}
                              where id in 
                              (
                                select id from
                                (
                                    select id, row_number() over(order by id)  scn from                     {tableName}
			                    ) t
                               where scn > {low} and scn<= {high};
                             ) 
                            order by id ";
        }
    }
}
