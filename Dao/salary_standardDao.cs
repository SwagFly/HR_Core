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
    /// 薪酬基本信息IDao
    /// </summary>
    public class salary_standardDao:DaoBase<salary_standard_details>, salary_standardIDao
    {
    }
}
