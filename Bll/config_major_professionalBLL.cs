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
    /// 职位
    /// </summary>
    public class config_major_professionalBLL: config_major_professionalIBLL
    {
        private static config_major_professionalIDao dao = IocType.GetIocType<config_major_professionalDao>("config_major_professionalDao", "config_major_professionalDao");
        //职称设置删除
        public int config_major_professionalDelete(config_major_professional cmp, object keyValue)
        {
            return dao.config_major_professionalDelete(cmp,keyValue);
        }

        //职称设置查询
        public List<config_major_professional> config_major_professionalSelect()
        {
            return dao.config_major_professionalSelect();
        }
    }
}
