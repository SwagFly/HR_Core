using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDao;
using Models;

namespace Dao
{
    /// <summary>
    /// 公共字段设置IDao
    /// </summary>
    public class config_public_charDao : DaoBase<config_public_char>, config_public_charIDao
    {
        public int config_public_charDel(config_public_char pc, object keyValue)
        {
            return Delete(pc,keyValue);
        }

        public int config_public_charInsert(config_public_char pc)
        {
            return Insert(pc);
        }

        public List<config_public_char> config_public_charSelect()
        {
            return SelectAll();
        }
    }
}
