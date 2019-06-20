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
    /// 记录人力资源档案所作的任何改变
    /// </summary>
    public class human_file_digDao:DaoBase<human_file_dig>, human_file_digIDao
    {
    }
}
