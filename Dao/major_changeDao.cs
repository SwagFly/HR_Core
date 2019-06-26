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
    /// 职位调动IDao
    /// </summary>
    public class major_changeDao : DaoBase<major_change>, major_changeIDao
    {
        /// <summary>
        /// 调动模块
        /// 根据一级机构、二级结构、三级结构、登记时间和复核时间根据条件做分页查询
        /// </summary>
        /// <param name="sql">根据sql筛选</param>
        /// <param name="rows">总行数</param>
        /// <param name="IndexPage">当前页</param>
        /// <param name="PageSize">总页数</param>
        /// <returns></returns>
        public List<major_change> SelectFenYeBySelect(string sql, out int rows, int IndexPage, int PageSize)
        {
            HR_DBEntities entity = new HR_DBEntities();
            var select = entity.major_change.SqlQuery(sql).ToList();//根据条件查询
            rows = select.Count();//获取总记录数
            return select.Skip((IndexPage - 1) * PageSize).Take(PageSize).ToList();
        }
    }
}
