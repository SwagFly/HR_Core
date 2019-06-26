using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using IBll;
using Bll;
using IOC;
namespace HR_Core.Controllers
{
    public class salaryGrantController : Controller
    {
        //一级机构
        config_file_first_kindIBLL firstbll = IocType.GetIocType<config_file_first_kindBLL>("config_file_first_kindBLL", "config_file_first_kindBLL");
        //二级机构
        config_file_second_kindIBLL secondbll = IocType.GetIocType<config_file_second_kindBLL>("config_file_second_kindBLL", "config_file_second_kindBLL");
        //三级机构
        config_file_third_kindIBLL thirdbll = IocType.GetIocType<config_file_third_kindBLL>("config_file_third_kindBLL", "config_file_third_kindBLL");
        //人力资源
        human_file hf = new human_file();
        human_fileIBLL hfbll = IocType.GetIocType<human_fileBLL>("human_fileBLL", "human_fileBLL");

        // GET: salaryGrant
        //薪酬发放登记
        [HttpGet]
        public ActionResult register_locate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register_locate(int submitType)
        {
            if (submitType == 1)//如果是一级机构就查询一级全部
            {
                ViewBag.first = firstbll.SelectFirst_kind();
            }
            else if (submitType == 2)//如果是二级机构就查询二级全部
            {
                ViewBag.second = secondbll.Second_kind();
            }
            else if (submitType == 3)//如果是三级机构就查询三级全部
            {
                ViewBag.third = thirdbll.third_kind();
            }
            ViewBag.human_file = hfbll.Selecthuman_file(hf);
            return RedirectToAction("register_list");
        }
        //薪酬发放登记(负责人控制) 
        public ActionResult register_list()
        {
            return View();
        }
        public ActionResult register_commit()
        {
            return View();
        }
        public ActionResult register_success()
        {
            return View();
        }




        //薪酬发放登记审核	
        public ActionResult check_list()
        {
            return View();
        }
        //薪酬发放登记复核
        public ActionResult check()
        {
            return View();
        }
        public ActionResult check_success()
        {
            return View();
        }



        //薪酬发放查询 
        public ActionResult query_locate()
        {
            return View();
        }
        public ActionResult query_list()
        {
            return View();
        }
        public ActionResult query()
        {
            return View();
        }
    }
}