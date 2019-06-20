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
    }
}
