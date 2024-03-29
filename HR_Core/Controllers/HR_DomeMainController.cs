﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Bll;
using IOC;
using IBll;
using Newtonsoft.Json;

namespace HR_Core.Controllers
{
    public class HR_DomeMainController : Controller
    {
        private RightsObjectIBLL rigBll = IocType.GetIocType<RightsObjectBLL>("RightsObjectBLL", "RightsObjectBLL");
        private UsersAndRoleIBll roleBll = IocType.GetIocType<UsersAndRoleBll>("UsersAndRoleBll", "UsersAndRoleBll");
        /// <summary>
        /// 总页面
        /// </summary>
        /// <returns></returns>
        // GET: HR_DomeMain
        public ActionResult MainIsUI()
        {
            return View();
        }
        /// <summary>
        /// 头部
        /// </summary>
        /// <returns></returns>
        // GET: HR_DomeMain
        public ActionResult MainIsUITop()
        {
            users admin = Session["userClass"] as users;
            vw_usersAndRole roleAnd = roleBll.SelectWhere(e => e.rid == admin.rid).FirstOrDefault();
            return View(roleAnd);
        }
        /// <summary>
        /// 权限的动态显示
        /// </summary>
        /// <returns></returns>
        public ActionResult MainTreeShow() {
            users admin = Session["userClass"] as users;//获取登录者信息
            int adminRole = admin.rid;//获取登录者权限
            int treeId = 0;
            if (Request["id"] != null) {
                treeId = Convert.ToInt32(Request["id"]);
            }
            List<RightsObject> rigList = rigBll.GetRoleResult(adminRole,treeId);
            return Content(JsonConvert.SerializeObject(rigList));
        }

        /// <summary>
        /// 权限的动态显示
        /// </summary>
        /// <returns></returns>
        public ActionResult MainTreeShows()
        {
            return View();
        }
        /// <summary>
        /// 退出当前登录的
        /// </summary>
        /// <returns></returns>
        public ActionResult End() {
            Session.RemoveAll();//清除本次登录的信息
            return RedirectToAction("Login", "HR_DomeLogin");
        }

    }
}