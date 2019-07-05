using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Linq.Expressions;

namespace IBll
{
    /// <summary>
    /// 薪酬发放详细
    /// </summary>
    public interface salary_grant_detailsIBLL
    {
        //薪酬发放单详细信息表
        int salary_grant_detailsInsert(salary_grant_details sd);
        //薪酬发放单详细信息表条件查询
        List<salary_grant_details> salary_grant_detailsSelectWhere(Expression<Func<salary_grant_details, bool>> where);
        //薪酬发放修改
        int salary_grant_detailsUpdate(salary_grant_details sgd, object keyValue);
    }
}
