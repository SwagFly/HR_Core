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
    /// 薪酬发放详细
    /// </summary>
    public class salary_grant_detailsBLL: salary_grant_detailsIBLL
    {
        private static salary_grant_detailsIDao dao = IocType.GetIocType<salary_grant_detailsDao>("salary_grant_detailsDao", "salary_grant_detailsDao");

        public int salary_grant_detailsInsert(salary_grant_details sd)
        {
            return dao.salary_grant_detailsInsert(sd);
        }

        public List<salary_grant_details> salary_grant_detailsSelectWhere(Expression<Func<salary_grant_details, bool>> where)
        {
            return dao.salary_grant_detailsSelectWhere(where);
        }
        //薪酬发放修改
        public int salary_grant_detailsUpdate(salary_grant_details sgd, object keyValue)
        {
            return dao.salary_grant_detailsUpdate(sgd,keyValue);
        }
    }
}
