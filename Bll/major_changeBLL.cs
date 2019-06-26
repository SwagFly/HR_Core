using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll;
using Models;
using Dao;
using IDao;
using IOC;
using System.Linq.Expressions;

namespace Bll
{
    /// <summary>
    /// 职位调动
    /// </summary>
    public class major_changeBLL: major_changeIBLL
    {
        private static major_changeIDao dao = IocType.GetIocType<major_changeDao>("major_changeDao", "major_changeDao");
        public List<major_change> SelectFenYeBySelect(string sql, out int rows, int IndexPage, int PageSize)
        {
            return dao.SelectFenYeBySelect(sql,out rows, IndexPage, PageSize);
        }

        public List<major_change> SelectWhere(Expression<Func<major_change, bool>> where)
        {
            return dao.SelectWhere(where);
        }
    }
}
