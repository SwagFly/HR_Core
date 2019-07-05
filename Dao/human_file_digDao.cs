using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;
using System.Linq.Expressions;

namespace Dao
{
    /// <summary>
    /// 记录人力资源档案所作的任何改变
    /// </summary>
    public class human_file_digDao:DaoBase<human_file_dig>, human_file_digIDao
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dig"></param>
        /// <returns></returns>
        public int InsertClass(human_file_dig dig)
        {
            return Insert(dig);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<human_file_dig> ListDig() {
            return SelectAll();
        }
        /// <summary>
        /// 查询单个值
        /// </summary>
        /// <returns></returns>
        public human_file_dig digClass(Expression<Func<human_file_dig, bool>> where) {
            return SelectWhere(where).FirstOrDefault();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dig"></param>
        /// <returns></returns>
        public int Delete(human_file_dig dig) {
            return Delete(dig, dig.hfd_id);
        }


    }
}
