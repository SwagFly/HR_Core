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
    /// 职位设置
    /// </summary>
    public class config_majorBLL: config_majorIBLL
    {
        private static config_majorIDao dao = IocType.GetIocType<config_majorDao>("config_majorDao", "config_majorDao");
        /// <summary>
        /// 查询所有职位名称
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public List<config_major> GetMajor(config_major major)
        {
            return dao.GetMajor(major);
        }


    }
}
