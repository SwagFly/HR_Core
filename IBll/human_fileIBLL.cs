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
    /// 人力资源档案
    /// </summary>
    public interface human_fileIBLL
    {
        //薪酬调用人力资源显示
        List<human_file> Selecthuman_file(human_file hf);
        //薪酬按id查询
        List<human_file> human_fileSelectWhere(Expression<Func<human_file, bool>> where);
        /// <summary>
        /// 调动模块
        /// 根据一级机构、二级结构、三级结构、登记时间和复核时间根据条件做分页查询
        /// </summary>
        /// <param name="sql">根据sql筛选</param>
        /// <param name="rows">总行数</param>
        /// <param name="IndexPage">当前页</param>
        /// <param name="PageSize">总页数</param>
        /// <returns></returns>
        List<human_file> SelectFenYeBySelect(string sql, out int rows, int IndexPage, int PageSize);
        /// <summary>
        /// 调动模块
        /// 根据条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        List<human_file> SelectWhere(Expression<Func<human_file, bool>> where);
        /// <summary>
        /// 添加人力资源信息
        /// </summary>
        /// <param name="hf"></param>
        /// <returns></returns>
        int InsertFile(human_file hf);
        /// <summary>
        /// 根据条件查询单个对象
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        human_file SelectHuanm(Expression<Func<human_file, bool>> where);
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        int UpdateFile(human_file file);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        List<human_file> ListFile();
        /// <summary>
        /// 高级查询
        /// </summary>
        /// <returns></returns>
        List<human_file> ListWhere(Expression<Func<human_file, bool>> where);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        int DeleteClass(human_file file);
    }
}
