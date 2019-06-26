using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IOC;
using Bll;
using IBll;
using Models;
using Newtonsoft.Json;
using System.Transactions;
using System.Web.Script.Serialization;

namespace HR_Core.Controllers
{
    public class RoleController : Controller
    {
        private static RightsObjectIBLL rob = IocType.GetIocType<RightsObjectBLL>("RightsObjectBLL", "RightsObjectBLL");
        private static RoleIBLL role = IocType.GetIocType<RoleBLL>("RoleBLL", "RoleBLL");//角色
        private static checkedsIBll chen = IocType.GetIocType<checkedsBll>("checkedsBll", "checkedsBll");
        private static PermissionIBLL per = IocType.GetIocType<PermissionBLL>("PermissionBLL", "PermissionBLL");
        // GET: Permission/Role
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 角色的分页查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Roles()
        {
            PageModel page = new PageModel()
            {
                CurrentPage = Convert.ToInt32(Request["currentPage"]),
                PageSize = 3//每页显示记录数
            };
            List<Role> datas = role.PageData(e => e.rid, e => e.rid > 0, page);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("data", datas);
            dic.Add("page", page);
            return Content(JsonConvert.SerializeObject(dic));
        }
        // GET: Permission/Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Permission/Role/Create
        public ActionResult Create()
        {
            return View();
        }
       /// <summary>
       /// 角色的添加
       /// </summary>
       /// <param name="ro"></param>
       /// <returns></returns>
        // POST: Permission/Role/Create
        [HttpPost]
        public ActionResult Create(Role ro)
        {
            if (role.Insert(ro) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }
        /// <summary>
        /// 修改角色及修改角色的权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Permission/Role/Edit/5
        private static int classIdRole = 0;//rid
        public ActionResult Edit(int id)
        {
            Role ro = role.SelectWhere(e => e.rid == id).FirstOrDefault();
            string sf = ro.ravailable;
            classIdRole = id;
            ViewData["id"] = id;
            ViewData["sf"] = sf;//是否
            return View(ro);
        }

        // POST: Permission/Role/Edit/5
        [HttpPost]
        public ActionResult Edit()
        {
            Role ro = new JavaScriptSerializer().Deserialize<Role>(Request["classNew"]);
            string[] pid = Request["pid"].Split(',');
            int rid = classIdRole;
            using (TransactionScope ts = new TransactionScope())
            {
                int update = role.Updates(ro);//修改角色表
                int del = per.Deletes(rid);//根据rid删除权限表
                int add = 0;
                for (int i = 0; i < pid.Length; i++)
                {
                    Permission pp = new Permission()
                    {
                        rid = rid,
                        roid =Convert.ToInt32(pid[i])
                    };
                     add+= per.Insert(pp);//添加权限表
                }
                if (update > 0 && del >= 0 && add > 0)
                {
                    ts.Complete();
                    return Content("ok");
                }
                else
                {
                    return Content("no");
                }
            }
        }
        public ActionResult Delete(int id)
        {
            Role ro = new Role()
            {
                rid = id
            };
            if (role.Deletes(ro) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// 查询权限
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectFistFather()
        {
            int fatherId =Convert.ToInt32(Request["id"]);
            List<vw_checked> list = chen.SelectRolesByrid(classIdRole, fatherId);
            return Content(JsonConvert.SerializeObject(list));
        }
    }
}
