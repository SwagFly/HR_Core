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
    /// 薪酬报销分类IDao
    /// </summary>
    public class salary_projectDao : DaoBase<salary_project>, salary_projectIDao
    {
        HR_DBEntities hr = new HR_DBEntities();
        //薪酬报销分类查询
        public List<salary_project> selectsalary_project()
        {
            return hr.Set<salary_project>().Select(e => e).ToList();
        }
    }
}
