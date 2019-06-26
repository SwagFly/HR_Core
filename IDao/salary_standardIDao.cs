using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    /// <summary>
    /// 薪酬基本信息IDao
    /// </summary>
    public interface salary_standardIDao
    {
        //生成单号存储过程
        string GetId();
        //薪酬标准新增
        int salary_standardInsert(salary_standard sl);
        //总例数
        List<T> FindAll<T>(Expression<Func<T, bool>> where) where T : class;
        //薪酬标准登记复核分页
        List<salary_standard> PageData<K>(Expression<Func<salary_standard, K>> order, Expression<Func<salary_standard, bool>> where, PageModel page);
        /// <summary>
        /// 调动管理
        /// 查询全部新薪酬管理
        /// </summary>
        /// <returns></returns>
        List<salary_standard> SelectAll();
    }
}
