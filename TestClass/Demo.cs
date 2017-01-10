using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestClass
{
    public class Demo
    {
        public void djg()
        {            
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));

            List<Users> userlist = new List<Users> {
                    (new Users() { Id = 1, Name = "张三" }),
                    (new Users() { Id = 2, Name = "李四" })
            };
            DataTable dts = ToDataTable(userlist);

            foreach(DataRow row in dts.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = row["Id"];
                dr["Name"] = row["Name"].ToString();
                dt.Rows.Add(dr);
            }
            foreach(DataRow item in dt.Rows)
            {
                int Id = Convert.ToInt32(item["Id"]);
                string Name = item["Name"].ToString();
            }
        }

        #region List<T> 转 DataTable
        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        #endregion

    }
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
