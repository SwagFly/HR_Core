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
    /// 一级结构设置
    /// </summary>
    public interface config_file_first_kindIBLL
    {
        /// <summary>
        /// 查询所有一级机构
        /// </summary>
        /// <returns></returns>
        List<config_file_first_kind> SelectFirst_kind();
        //一级机构新增
        int config_file_first_kindInsert(config_file_first_kind first);
        //一级机构删除
        int config_file_first_kindDel(config_file_first_kind first, object keyValue);
        //一级机构按id查询
        List<config_file_first_kind> selectWhere(Expression<Func<config_file_first_kind, bool>> where);
        //一级机构修改
        int config_file_first_kindUpdate(config_file_first_kind first, object keyValue);
    }
}
