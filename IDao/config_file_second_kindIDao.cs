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
    /// 二级机构设置IDao
    /// </summary>
    public interface config_file_second_kindIDao
    {
        /// <summary>
        /// 查询二级机构
        /// </summary>
        /// <returns></returns>
        List<config_file_second_kind> SelectSecond_kind(config_file_second_kind second);
        /// <summary>
        /// 调动模块
        /// 查询全部二级机构
        /// </summary>
        /// <returns></returns>
        List<config_file_second_kind> SelectAllSecond_kind();
        /// <summary>
        /// 根据条件查询二级机构
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<config_file_second_kind> SelectWhere(Expression<Func<config_file_second_kind, bool>> where);
        /// <summary>
        /// 查询全部的二级机构
        /// </summary>
        /// <returns></returns>
        List<config_file_second_kind> SelectAllSecond();
    }
}
