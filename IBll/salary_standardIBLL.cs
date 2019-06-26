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
    /// 薪酬基本信息
    /// </summary>
    public interface salary_standardIBLL
    {
        //生成单号存储过程
        string GetId();
        //薪酬标准新增
        int salary_standardInsert(salary_standard sl);
        //总例数
        List<salary_standard> FindAll<T>(Expression<Func<salary_standard, bool>> where) where T : class;
        //薪酬标准登记复核分页
        List<salary_standard> PageData<K>(Expression<Func<salary_standard, K>> order, Expression<Func<salary_standard, bool>> where, PageModel page);
        /// <summary>
        /// 调动管理
        /// 查询全部新薪酬管理
        /// </summary>
        /// <returns></returns>
        List<salary_standard> SelectAll();
        //薪酬标准登记复核按id查询
        salary_standard salary_standardselectWhere(Expression<Func<salary_standard, bool>> where);
        //薪酬标准登记复核修改
        int salary_standardUpdate(salary_standard sl);
        //模糊查询分页
        List<salary_standard> SelectBy(string sql, out int rows, int IndexPage, int PageSize);
    }
}
