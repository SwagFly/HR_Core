using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;
using System.Linq.Expressions;

namespace Dao
{
    public class UserDao : DaoBase<users>, UsersIDao
    {
        public int Deletes(users us)
        {
            return Delete(us, us.u_id);
        }

        /// <summary>
        /// 登录者信息查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public users Login(Expression<Func<users, bool>> where)
        {
            //出现第一次错误，Web配置文件中没有链接字符串
            return SelectWhere(where).FirstOrDefault();
        }
        public int Updates(users us)
        {
            return Update(us, us.u_id);
        }
    }
}