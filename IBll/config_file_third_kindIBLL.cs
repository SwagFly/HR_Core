using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IBll
{
    /// <summary>
    /// 三级机构设置
    /// </summary>
    public interface config_file_third_kindIBLL
    {
        /// <summary>
        /// 查询三级机构
        /// </summary>
        /// <param name="third"></param>
        /// <returns></returns>
        List<config_file_third_kind> GetThird(config_file_third_kind third);
        /// <summary>
        /// 查询三级机构全部
        /// </summary>
        /// <returns></returns>
        List<config_file_third_kind> SelectAllThird();
        /// <summary>
        /// 根据条件查询三级机构
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<config_file_third_kind> SelectWhere(Expression<Func<config_file_third_kind, bool>> where);
        //薪酬调用三级机构
        List<config_file_third_kind> third_kind();
    }
}
