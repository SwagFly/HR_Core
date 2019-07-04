using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;


namespace Dao
{
    /// <summary>
    /// 薪酬发放登记表
    /// </summary>
    public class salary_grantDao : DaoBase<salary_grant>, salary_grantIDao
    {
        /// <summary>
        /// 薪酬模块
        /// 薪酬发放查询的分页
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="rows"></param>
        /// <param name="IndexPage"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public List<salary_grant> SelectFenYeBySelect(string sql, out int rows, int IndexPage, int PageSize)
        {
            HR_DBEntities entity = new HR_DBEntities();
            var select = entity.salary_grant.SqlQuery(sql).ToList();
            rows = select.Count();
            return select.Skip((IndexPage - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
