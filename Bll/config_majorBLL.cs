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
    /// 职位设置
    /// </summary>
    public class config_majorBLL: config_majorIBLL
    {
        private static config_majorIDao dao = IocType.GetIocType<config_majorDao>("config_majorDao", "config_majorDao");

        public int config_majorDel(config_major ma, object keyValue)
        {
            return dao.config_majorDel(ma,keyValue);
        }

        public int config_majorInsert(config_major ma)
        {
            return dao.config_majorInsert(ma);
        }

        public List<config_major> config_majorSelect()
        {
            return dao.config_majorSelect();
        }

        public int config_majorUpdate(config_major ma, object keyValue)
        {
            return dao.config_majorUpdate(ma,keyValue);
        }

        /// <summary>
        /// 查询所有职位名称
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public List<config_major> GetMajor(config_major major)
        {
            return dao.GetMajor(major);
        }

        public List<config_major> SelectWhere(Expression<Func<config_major, bool>> where)
        {
            return dao.SelectWhere(where);
        }
    }
}
