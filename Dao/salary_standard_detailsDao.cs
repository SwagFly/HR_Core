using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Models;
using System.Linq.Expressions;

namespace Dao
{
    /// <summary>
    /// 薪酬标准单详细信息表IDao
    /// </summary>
    public class salary_standard_detailsDao : DaoBase<salary_standard_details>, salary_standard_detailsIDao
    {
        HR_DBEntities hr = new HR_DBEntities();
        //薪酬标准单详细信息表
        public int salary_standard_detailsInsert(salary_standard_details sd)
        {
            hr.Entry<salary_standard_details>(sd).State = System.Data.Entity.EntityState.Added;
            return hr.SaveChanges();
        }
        //薪酬标准登记复核详细表按id查询
        public List<salary_standard_details> salary_standard_detailsselectWhere(Expression<Func<salary_standard_details, bool>> where)
        {
            return hr.Set<salary_standard_details>().Where(where).Select(e => e).ToList();
        }
        //修改
        public int salary_standard_detailsUpdate(salary_standard_details sd)
        {
            hr.Entry(sd).State = System.Data.Entity.EntityState.Modified;
            return hr.SaveChanges();
        }
    }
}
