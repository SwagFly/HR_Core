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
        //薪酬调用二级机构
        List<config_file_second_kind> Second_kind();
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
        //二级机构新增
        int config_file_second_kindInsert(config_file_second_kind second);
        //二级机构删除
        int config_file_second_kindDel(config_file_second_kind second, object keyValue);
        //二级机构按id查询
        List<config_file_second_kind> config_file_second_kindselectWhere(Expression<Func<config_file_second_kind, bool>> where);
        //二级机构修改
        int config_file_second_kindUpdate(config_file_second_kind second, object keyValue);
    }
}
