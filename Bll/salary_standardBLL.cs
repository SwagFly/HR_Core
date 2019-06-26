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
    /// 薪酬基本信息
    /// </summary>
    public class salary_standardBLL : salary_standardIBLL
    {
        private static salary_standardIDao dao = IocType.GetIocType<salary_standardDao>("salary_standardDao", "salary_standardDao");
        /// <summary>
        /// 生成单号
        /// </summary>
        /// <returns></returns>
        public string GetId()
        {
            return dao.GetId();
        }



        /// <summary>
        /// 薪酬新增
        /// </summary>
        /// <param name="sl">薪酬实体类</param>
        /// <returns></returns>
        public int salary_standardInsert(salary_standard sl)
        {
            return dao.salary_standardInsert(sl);
        }
        //总例数
        public List<salary_standard> FindAll<T>(Expression<Func<salary_standard, bool>> where) where T : class
        {
            return dao.FindAll<salary_standard>(where);
        }
        //薪酬标准登记复核分页
        public List<salary_standard> PageData<K>(Expression<Func<salary_standard, K>> order, Expression<Func<salary_standard, bool>> where, PageModel page)
        {
            return dao.PageData(order, where, page);
        }

        public List<salary_standard> SelectAll()
        {
            return dao.SelectAll();
        }
    }
}
