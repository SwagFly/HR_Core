using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBll;
using Dao;
using IDao;
using Models;
using IOC;
namespace Bll
{
    /// <summary>
    /// 激励登记
    /// </summary>
    public class bonusBLL:bonusIBLL
    {
        //实现接口
       private static bonusIDao dao = IocType.GetIocType<bonusDao>("bonusDao", "bonusDao");
    }
}
