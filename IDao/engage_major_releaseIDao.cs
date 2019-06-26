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
    /// 职位发表登记IDao
    /// </summary>
    public interface engage_major_releaseIDao
    {
        /// <summary>
        /// 添加职位发表登记
        /// </summary>
        /// <param name="relase">实体类</param>
        /// <returns></returns>
        int InsertClass(engage_major_release relase);
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        List<engage_major_release> PageRelease<K>(Expression<Func<engage_major_release, K>> order, Expression<Func<engage_major_release, bool>> where, PageModel page);
        /// <summary>
        /// 修改前的查询单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        engage_major_release GetMajorId(int id);
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="release"></param>
        /// <returns></returns>
        int UpdateMajor(engage_major_release release);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="release"></param>
        /// <returns></returns>
        int DeleteMajor(engage_major_release release);

    }
}
