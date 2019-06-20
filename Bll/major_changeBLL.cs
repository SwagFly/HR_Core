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
    /// 职位调动
    /// </summary>
    public class major_changeBLL: major_changeIBLL
    {
        private static major_changeIDao dao = IocType.GetIocType<major_changeDao>("major_changeDao", "major_changeDao");
    }
}
