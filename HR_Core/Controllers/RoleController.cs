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

namespace HR_Core.Controllers
{
    public class RoleController : Controller
    {
        RoleIBLL role = IocType.GetIocType<RoleBLL>("RoleBLL", "RoleBLL");//角色
        // GET: Permission/Role
        public ActionResult Index()
        {
            return View();
        }
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

        // GET: Permission/Role/Edit/5
        public ActionResult Edit(int id)
        {
            Role ro = role.SelectWhere(e => e.rid == id).FirstOrDefault();
            return View(ro);
        }

        // POST: Permission/Role/Edit/5
        [HttpPost]
        public ActionResult Edit(Role ro)
        {
            if (role.Updates(ro) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
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
    }
}
