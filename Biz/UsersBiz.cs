using Dao;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz
{
    public class UsersBiz
    {
        public static int AddUser(Users user)
        {
            return UsersDao.AddUser(user);
        }
    }
}
