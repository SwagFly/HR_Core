﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Linq.Expressions;

namespace IBll
{
    /// <summary>
    /// 薪酬发放登记表
    /// </summary>
    public interface salary_grantIBLL
    {
        //生成薪酬发放编号存储过程
        string GetIdFF();
        //薪酬发放新增
        int salary_grantInsert(salary_grant sg);
        //薪酬发放复核（修改）
        int salary_grantUpdate(salary_grant sg, object keyValue);
        /// <summary>
        /// 薪酬模块
        /// 分页条件查询
        ///根据薪酬单号、关键字：复核人及登记人、登记时间查询
        /// </summary>
        /// <param name="sql">根据sql筛选</param>
        /// <param name="rows">总行数</param>
        /// <param name="IndexPage">当前页</param>
        /// <param name="PageSize">总页数</param>
        /// <returns></returns>
        List<salary_grant> SelectFenYeBySelect(string sql, out int rows, int IndexPage, int PageSize);
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        List<salary_grant> SelectWhere(Expression<Func<salary_grant, bool>> where);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="K"><peparam>
        /// <param name="order"></param>
        /// <param name="where"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        List<salary_grant> PageData<K>(Expression<Func<salary_grant, K>> order, Expression<Func<salary_grant, bool>> where, PageModel page);
    }
}
