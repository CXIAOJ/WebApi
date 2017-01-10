using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao
{
    public class Helper
    {
        public Helper()
        {
            string connStr = ConfigurationManager.AppSettings["ConnectionStr"];
            SqlConnection conn = new SqlConnection(connStr);
            var state = conn.State.ToString();
        }
    }
}
