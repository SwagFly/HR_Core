using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Linq.Expressions;

namespace IBll
{
    /// <summary>
    /// 职位调动
    /// </summary>
    public interface major_changeIBLL
    {
        /// <summary>
        /// 调动模块
        /// 根据一级机构、二级结构、三级结构、登记时间和复核时间
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<major_change> SelectWhere(Expression<Func<major_change, bool>> where);
        /// <summary>
        /// 调动模块
        /// 根据一级机构、二级结构、三级结构、登记时间和复核时间根据条件做分页查询
        /// </summary>
        /// <param name="sql">根据sql筛选</param>
        /// <param name="rows">总行数</param>
        /// <param name="IndexPage">当前页</param>
        /// <param name="PageSize">总页数</param>
        /// <returns></returns>
        List<major_change> SelectFenYeBySelect(string sql, out int rows, int IndexPage, int PageSize);
        /// <summary>
        /// 调动模块
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        int Updates(major_change change);
        /// <summary>
        /// 调动模块
        /// 调动登记添加
        /// </summary>
        /// <param name="change"></param>
        /// <returns></returns>
        int Insert(major_change change);
    }
}
