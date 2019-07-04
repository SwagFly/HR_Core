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
    /// 薪酬发放登记表
    /// </summary>
    public class salary_grantBLL: salary_grantIBLL
    {
        private static salary_grantIDao dao = IocType.GetIocType<salary_grantDao>("salary_grantDao", "salary_grantDao");

        public List<salary_grant> PageData<K>(Expression<Func<salary_grant, K>> order, Expression<Func<salary_grant, bool>> where, PageModel page)
        {
            return dao.PageData(order, where, page);
        }

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
            return dao.SelectFenYeBySelect(sql, out rows, IndexPage, PageSize);
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<salary_grant> SelectWhere(Expression<Func<salary_grant, bool>> where)
        {
            return dao.SelectWhere(where);
        }
        //薪酬发放新增
        public int salary_grantInsert(salary_grant sg)
        {
            return dao.salary_grantInsert(sg);
        }

        public List<salary_grant> PageData<K>(Expression<Func<salary_grant, K>> order, Expression<Func<salary_grant, bool>> where, PageModel page)
        {
            return dao.PageData(order, where, page);
        }
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
            return dao.SelectFenYeBySelect(sql, out rows, IndexPage, PageSize);
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<salary_grant> SelectWhere(Expression<Func<salary_grant, bool>> where)
        {
            return dao.SelectWhere(where);
        }

        //薪酬发放复核（修改）
        public int salary_grantUpdate(salary_grant sg, object keyValue)
        {
            return dao.salary_grantUpdate(sg,keyValue);
        }
        //生成薪酬发放编号存储过程
        public string GetIdFF()
        {
            return dao.GetIdFF();
        }
    }
}
