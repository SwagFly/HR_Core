using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Bll;
using IBll;
using IOC;
using Newtonsoft.Json;

namespace HR_Core.Controllers
{
    /// <summary>
    /// 职位发布管理控制器：（职位发布登记、变更、查询）
    /// </summary>
    public class Job_postingController : Controller
    {
        private config_file_first_kindIBLL bll = IocType.GetIocType<config_file_first_kindBLL>("config_file_first_kindBLL", "config_file_first_kindBLL");
        private config_file_second_kindBLL second_bll = IocType.GetIocType<config_file_second_kindBLL>("config_file_second_kindBLL", "config_file_second_kindBLL");
        private config_file_third_kindIBLL third_bll = IocType.GetIocType<config_file_third_kindBLL>("config_file_third_kindBLL", "config_file_third_kindBLL");
        private config_major_kindIBLL major_kind_bll = IocType.GetIocType<config_major_kindBLL>("config_major_kindBLL", "config_major_kindBLL");
        private config_majorIBLL major_bll = IocType.GetIocType<config_majorBLL>("config_majorBLL", "config_majorBLL");
        /// <summary>
        /// 职位发布登记页面入口
        /// </summary>
        /// <returns></returns>
        // GET: Recruitment/Job_posting
        public ActionResult Registration_entrance()
        {
            users user = Session["userClass"] as users;
            ViewData["admin"] = user.u_true_name;
            return View();
        }
        /// <summary>
        /// 查询一级机构
        /// </summary>
        /// <returns>异步一级机构</returns>
        public ActionResult firstKindIdVue()
        {
            List<config_file_first_kind> list = bll.SelectFirst_kind();
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 查询二级机构
        /// </summary>
        /// <returns>异步二级机构</returns>
        public ActionResult secondKindIdVue()
        {
            config_file_second_kind second = new config_file_second_kind() {
                second_kind_id=Request["fatherId"]
            };
            List<config_file_second_kind> list = second_bll.SelectSecond_kind(second);
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 查询三级机构
        /// </summary>
        /// <returns>异步二级机构</returns>
        public ActionResult thirdKindIdVue()
        {
            config_file_third_kind third = new config_file_third_kind() {
                third_kind_id = Request["fatherId"]
            };
            List<config_file_third_kind> list = third_bll.GetThird(third);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 查询职位分类
        /// </summary>
        /// <returns>异步二级机构</returns>
        public ActionResult engageTypeVue()
        {
            List<config_major_kind> list = major_kind_bll.GetMajorKind();
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 查询职位名称
        /// </summary>
        /// <returns>异步二级机构</returns>
        public ActionResult majorIdVue()
        {
            config_major major = new config_major()
            {
                major_kind_id = Request["fatherId"]
            };
            List<config_major> list = major_bll.GetMajor(major);
            return Content(JsonConvert.SerializeObject(list));
        }



    }
}