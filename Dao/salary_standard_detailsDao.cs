using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Models;

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
    }
}
