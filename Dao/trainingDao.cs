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
    /// 培训登记IDao
    /// </summary>
    public class trainingDao:DaoBase<training>, trainingIDao
    {
    }
}
