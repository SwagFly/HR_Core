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
    /// 二级机构设置
    /// </summary>
    public class config_file_second_kindBLL: config_file_second_kindIBLL
    {
        private static config_file_second_kindIDao dao = IocType.GetIocType<config_file_second_kindDao>("config_file_second_kindDao", "config_file_second_kindDao");
        /// <summary>
        /// 查询二级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_second_kind> SelectSecond_kind(config_file_second_kind second) {
            return dao.SelectSecond_kind(second);
        }
    }
}
