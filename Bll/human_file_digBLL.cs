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
    /// 记录人力资源档案所作的任何改变
    /// </summary>
    public class human_file_digBLL: human_file_digIBLL
    {
        private static human_file_digIDao dao = IocType.GetIocType<human_file_digDao>("human_file_digDao", "human_file_digDao");
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dig"></param>
        /// <returns></returns>
        public int InsertClass(human_file_dig dig)
        {
            return dao.InsertClass(dig);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<human_file_dig> ListDig()
        {
            return dao.ListDig();
        }
        /// <summary>
        /// 查询单个值
        /// </summary>
        /// <returns></returns>
        public human_file_dig digClass(Expression<Func<human_file_dig, bool>> where)
        {
            return dao.digClass(where);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dig"></param>
        /// <returns></returns>
        public int Delete(human_file_dig dig)
        {
            return dao.Delete(dig);
        }
    }
}
