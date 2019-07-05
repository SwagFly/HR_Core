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
    /// 记录人力资源档案所作的任何改变
    /// </summary>
    public interface human_file_digIDao
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dig"></param>
        /// <returns></returns>
        int InsertClass(human_file_dig dig);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        List<human_file_dig> ListDig();
        /// <summary>
        /// 查询单个值
        /// </summary>
        /// <returns></returns>
        human_file_dig digClass(Expression<Func<human_file_dig, bool>> where);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dig"></param>
        /// <returns></returns>
        int Delete(human_file_dig dig);
    }
}
