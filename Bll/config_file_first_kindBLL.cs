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
    /// 一级结构设置
    /// </summary>
    public class config_file_first_kindBLL:config_file_first_kindIBLL
    {
        private static config_file_first_kindIDao dao = IocType.GetIocType<config_file_first_kindDao>("config_file_first_kindDao", "config_file_first_kindDao");
        /// <summary>
        /// 查询所有一级机构
        /// </summary>
        /// <returns></returns>
        public List<config_file_first_kind> SelectFirst_kind()
        {
            return dao.SelectFirst_kind();
        }
    }
}
