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
    /// 公共字段设置
    /// </summary>
    public class config_public_charBLL: config_public_charIBLL
    {
        private static config_public_charIDao dao = IocType.GetIocType<config_public_charDao>("config_public_charDao", "config_public_charDao");

        public int config_public_charDel(config_public_char pc, object keyValue)
        {
            return dao.config_public_charDel(pc,keyValue);
        }

        public int config_public_charInsert(config_public_char pc)
        {
            return dao.config_public_charInsert(pc);
        }

        public List<config_public_char> config_public_charSelect()
        {
            return dao.config_public_charSelect();
        }
    }
}
