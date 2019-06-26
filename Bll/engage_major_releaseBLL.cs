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
    /// 职位发表登记
    /// </summary>
    public class engage_major_releaseBLL: engage_major_releaseIBLL
    {
        private static engage_major_releaseIDao dao = IocType.GetIocType<engage_major_releaseDao>("engage_major_releaseDao", "engage_major_releaseDao");
        /// <summary>
        /// 添加职位发表登记
        /// </summary>
        /// <param name="relase">实体类</param>
        /// <returns></returns>
        public int InsertClass(engage_major_release relase)
        {
            return dao.InsertClass(relase);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<engage_major_release> PageRelease<K>(Expression<Func<engage_major_release, K>> order, Expression<Func<engage_major_release, bool>> where, PageModel page)
        {
            return dao.PageRelease<K>(order, where, page);
        }

        /// <summary>
        /// 修改前的查询单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public engage_major_release GetMajorId(int id)
        {
            return dao.GetMajorId(id);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="release"></param>
        /// <returns></returns>
        public int UpdateMajor(engage_major_release release)
        {
            return dao.UpdateMajor(release);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="release"></param>
        /// <returns></returns>
        public int DeleteMajor(engage_major_release release)
        {
            return dao.DeleteMajor(release);
        }

    }
}
