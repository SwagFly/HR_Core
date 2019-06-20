using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using IDao;

namespace Dao
{
    /// <summary>
    /// 关键字设置IDao
    /// </summary>
    public class config_primary_keyDao:DaoBase<config_primary_key>, config_primary_keyIDao
    {
    }
}
