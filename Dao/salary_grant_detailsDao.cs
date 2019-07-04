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
    /// <summary>
    /// 薪酬发放详细IDao
    /// </summary>
    public class salary_grant_detailsDao : DaoBase<salary_grant_details>, salary_grant_detailsIDao
    {
        HR_DBEntities hr = new HR_DBEntities();
        public int salary_grant_detailsInsert(salary_grant_details sd)
        {
            hr.Entry<salary_grant_details>(sd).State = System.Data.Entity.EntityState.Added;
            return hr.SaveChanges();
        }

        public List<salary_grant_details> salary_grant_detailsSelectWhere(Expression<Func<salary_grant_details, bool>> where)
        {
            return SelectWhere(where);
        }
        //薪酬发放修改
      
        public int salary_grant_detailsUpdate(salary_grant_details sgd,object keyValue)
        {
            return Update(sgd,keyValue);
        }
    }
}
