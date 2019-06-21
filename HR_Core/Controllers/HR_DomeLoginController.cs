using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using IOC;
using Bll;
using IBll;
using System.Web.Script.Serialization;

namespace HR_Core.Controllers
{
    
    public class HR_DomeLoginController : Controller
    {
        private static UsersIBll userBll = IocType.GetIocType<UsersBLL>("UsersBLL", "UsersBLL");
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <returns></returns>
        // GET: HR_DomeMain
        public ActionResult Login()
        {

            //return RedirectToAction("index", "User_controlController");

            return View();
        }
        /// <summary>
        /// 验证登录/存储登录者信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Show() {
            string userStr = Request["userClass"];//获取前端传过来的登录信息
            users user = new JavaScriptSerializer().Deserialize<users>(userStr);//转化成用户类
            user = userBll.Login(user);
            if (user.u_id > 0)
            {
                Session["userClass"] = user;//使用session存储登录者信息
                return Content("1");
            }
            else {
                return Content("2");
            }
            
        }
    }
}