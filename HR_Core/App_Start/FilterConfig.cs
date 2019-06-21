using System.Web;
using System.Web.Mvc;
using HR_Core;
using HR_Core.Filters;

namespace HR_Core
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new ExceptionsAttribute());//错误的友好界面
            //filters.Add(new LoginAttribute());//登录过滤器
        }
    }
}
