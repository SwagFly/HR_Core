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
    /// 培训登记
    /// </summary>
    public class trainingBLL: trainingIBLL
    {
        private static trainingIDao dao = IocType.GetIocType<trainingDao>("trainingDao", "trainingDao");
    }
}
