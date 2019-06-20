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
    /// 关键字设置
    /// </summary>
    public class config_primary_keyBLL: config_primary_keyIBLL
    {
        private static config_primary_keyIDao dao = IocType.GetIocType<config_primary_keyDao>("config_primary_keyDao", "config_primary_keyDao");
    }
}
