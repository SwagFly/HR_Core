using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDao
{
    /// <summary>
    /// 薪酬标准单详细信息表IDao
    /// </summary>
    public interface salary_standard_detailsIDao
    {
        //薪酬标准单详细信息表
        int salary_standard_detailsInsert(salary_standard_details sd);
        //薪酬标准登记复核详细表按id查询
        List<salary_standard_details> salary_standard_detailsselectWhere(Expression<Func<salary_standard_details, bool>> where);
        int salary_standard_detailsUpdate(salary_standard_details sd);
    }
}
