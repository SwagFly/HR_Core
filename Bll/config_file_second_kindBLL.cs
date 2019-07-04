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
    /// 二级机构设置
    /// </summary>
    public class config_file_second_kindBLL: config_file_second_kindIBLL
    {
        private static config_file_second_kindIDao dao = IocType.GetIocType<config_file_second_kindDao>("config_file_second_kindDao", "config_file_second_kindDao");
        /// <summary>
        ///调动模块
        /// 查询全部二级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> SelectAllSecond_kind()
        {
            return dao.SelectAllSecond_kind();
        }

        /// <summary>
        /// 查询二级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> SelectSecond_kind(config_file_second_kind second) {
            return dao.SelectSecond_kind(second);
        }
        //薪酬调用二级机构
        public List<config_file_second_kind> Second_kind()
        {
            return dao.Second_kind();
        }
        /// <summary>
        /// 查询全部的二级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> SelectAllSecond()
        {
            return dao.SelectAllSecond();
        }
        /// <summary>
        /// 根据条件查询二级机构
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<config_file_second_kind> SelectWhere(Expression<Func<config_file_second_kind, bool>> where)
        {
            return dao.SelectWhere(where);
        }

        public int config_file_second_kindInsert(config_file_second_kind second)
        {
            return dao.config_file_second_kindInsert(second);
        }

        public int config_file_second_kindDel(config_file_second_kind second, object keyValue)
        {
            return dao.config_file_second_kindDel(second,keyValue);
        }

        public List<config_file_second_kind> config_file_second_kindselectWhere(Expression<Func<config_file_second_kind, bool>> where)
        {
            return dao.config_file_second_kindselectWhere(where);
        }

        public int config_file_second_kindUpdate(config_file_second_kind second, object keyValue)
        {
            return dao.config_file_second_kindUpdate(second,keyValue);
        }
    }
}
