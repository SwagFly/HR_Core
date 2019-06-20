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
    /// 记录人力资源档案所作的任何改变
    /// </summary>
    public class human_file_digBLL: human_file_digIBLL
    {
        private static human_file_digIDao dao = IocType.GetIocType<human_file_digDao>("human_file_digDao", "human_file_digDao");
    }
}
