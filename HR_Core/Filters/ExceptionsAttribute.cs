using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Core.Filters
{
    /// <summary>
    /// 出现异常执行的过滤器
    /// </summary>
    public class ExceptionsAttribute: HandleErrorAttribute
    {
        //在程序中任何地方出现异常都会执行  
        public override void OnException(ExceptionContext filterContext)
        {
            //获取异常对象  
            Exception ex = filterContext.Exception;
            //记录错误日志  
            //--------------
            //导向友好错误界面  
            filterContext.Result = new RedirectResult("/HR_DomeLogin/Login");
            //重要！！告诉系统异常已处理！！如果没有这个步骤，系统还是会按照正常的异常处理流程走  
            filterContext.ExceptionHandled = true;
            //base.OnException(filterContext);  
        }
    }
}