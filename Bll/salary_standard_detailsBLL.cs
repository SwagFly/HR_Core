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
using System.Linq.Expressions;

namespace Bll
{
    /// <summary>
    /// 薪酬标准单详细信息表
    /// </summary>
    public class salary_standard_detailsBLL : salary_standard_detailsIBLL
    {
        private static salary_standard_detailsIDao dao = IocType.GetIocType<salary_standard_detailsDao>("salary_standard_detailsDao", "salary_standard_detailsDao");

        //薪酬标准单详细信息表
        public int salary_standard_detailsInsert(salary_standard_details sd)
        {
            return dao.salary_standard_detailsInsert(sd);
        }
        //薪酬标准登记复核详细表按id查询
        public List<salary_standard_details> salary_standard_detailsselectWhere(string id)
        {
            return dao.salary_standard_detailsselectWhere(e=>e.standard_id==id);
        }

        public int salary_standard_detailsUpdate(salary_standard_details sd)
        {
            return dao.salary_standard_detailsUpdate(sd);
        }
        //薪酬发放查询
        public List<salary_standard_details> Selectsalary_standard_details()
        {
            return dao.Selectsalary_standard_details();
        }
    }
}
