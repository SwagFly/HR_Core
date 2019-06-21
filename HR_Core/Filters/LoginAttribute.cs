using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Core.Filters
{
    /// <summary>
    /// 测试过滤器
    /// </summary>
    public class LoginAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 在行为方法返回后执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// 在进入方法前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //拦截非法侵入进入Main进行操作--》登录验证
            if (filterContext.HttpContext.Session["LoginOrMain"]==null) {
                filterContext.HttpContext.Response.Redirect("/HR_DomeLogin/Login");
            }
        }

        /// <summary>
        /// 在进入视图之后进行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        /// <summary>
        /// 在进入视图之前进行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

    }
}