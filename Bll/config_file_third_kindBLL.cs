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
    /// 三级机构设置
    /// </summary>
    public class config_file_third_kindBLL: config_file_third_kindIBLL
    {
        private static config_file_third_kindIDao dao = IocType.GetIocType<config_file_third_kindDao>("config_file_third_kindDao", "config_file_third_kindDao");

        /// <summary>
        /// 查询三级机构
        /// </summary>
        /// <param name="third"></param>
        /// <returns></returns>
        public List<config_file_third_kind> GetThird(config_file_third_kind third)
        {
            return dao.GetThird(third);
        }
        //薪酬调用三级机构
        public List<config_file_third_kind> third_kind()
        {
            return dao.third_kind();
        }
        /// <summary>
        /// 查询三级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_third_kind> SelectAllThird()
        {
            return dao.SelectAllThird();
        }
        /// <summary>
        /// 根据条件查询三级机构
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<config_file_third_kind> SelectWhere(Expression<Func<config_file_third_kind, bool>> where)
        {
            return dao.SelectWhere(where);
        }

        public int config_file_third_kindInsert(config_file_third_kind third)
        {
            return dao.config_file_third_kindInsert(third);
        }

        public List<config_file_third_kind> config_file_third_kindselectWhere(Expression<Func<config_file_third_kind, bool>> where)
        {
            return dao.config_file_third_kindselectWhere(where);
        }

        public int config_file_third_kindUpdate(config_file_third_kind third, object keyValue)
        {
            return dao.config_file_third_kindUpdate(third,keyValue);
        }

        public int config_file_third_kindDel(config_file_third_kind third, object keyValue)
        {
            return dao.config_file_third_kindDel(third,keyValue);
        }
    }
}
