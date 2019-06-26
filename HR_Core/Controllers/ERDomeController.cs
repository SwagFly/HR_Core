using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll;
using IBll;
using IOC;
using Newtonsoft.Json;

namespace HR_Core.Controllers
{
    /// <summary>
    /// 简历管理
    /// </summary>
    public class ERDomeController : Controller
    {
        private static engage_major_releaseIBLL release_bll = IocType.GetIocType<engage_major_releaseBLL>("engage_major_releaseBLL", "engage_major_releaseBLL");
        private static config_file_second_kindIBLL second_bll = IocType.GetIocType<config_file_second_kindBLL>("config_file_second_kindBLL", "config_file_second_kindBLL");
        private static config_file_third_kindIBLL third_bll = IocType.GetIocType<config_file_third_kindBLL>("config_file_third_kindBLL", "config_file_third_kindBLL");
        private static engage_resumeIBLL resume_bll = IocType.GetIocType<engage_resumeBLL>("engage_resumeBLL", "engage_resumeBLL");
        /// <summary>
        /// 直接进入简历登记
        /// </summary>
        /// <returns></returns>
        // GET: EngageResume
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 提交申请进入简历登记
        /// </summary>
        /// <returns></returns>
        // GET: EngageResume
        public ActionResult IndexById(int id)
        {
            engage_major_release major = release_bll.GetMajorId(id);
            ViewData["releaseClass"] = major;
            return View("Index");
        }
        /// <summary>
        /// 查询全部二级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult SecondKind() {
            List<config_file_second_kind> secondList = second_bll.SelectAllSecond();
            return Content(JsonConvert.SerializeObject(secondList));
        }
        /// <summary>
        /// 按条件查询三级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult MajorSelect() {
            config_file_third_kind third = new config_file_third_kind() {
                second_kind_id= Request["fatherId"]
            };
            List<config_file_third_kind> thirdList = third_bll.GetThird(third);
            return Content(JsonConvert.SerializeObject(thirdList));
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public ActionResult Insert(engage_resume resume) {
            int i = resume_bll.InsertResume(resume);
            if (i > 0)
            {
                if (ViewData["releaseClass"] != null)
                {
                    return RedirectToAction("classUpdate", "Job_posting");
                }
                else {
                    return View("Index");
                }
            }
            else {
                if (ViewData["releaseClass"] != null)
                {
                    engage_major_release major = ViewData["releaseClass"] as engage_major_release;
                    return RedirectToAction("IndexById", "ERDome", major.mre_id);
                }
                else {
                    return View("Index");
                }
            }
        }

    }
}