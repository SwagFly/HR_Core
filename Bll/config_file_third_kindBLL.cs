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

    }
}
