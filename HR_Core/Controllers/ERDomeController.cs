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
using System.Linq.Expressions;

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
        private static config_major_kindIBLL major_bll = IocType.GetIocType<config_major_kindBLL>("config_major_kindBLL", "config_major_kindBLL");
        private static config_majorIBLL major_FatherBll = IocType.GetIocType<config_majorBLL>("config_majorBLL", "config_majorBLL");
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
            ViewBag.classNew = major;
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
            resume.check_status = 0;//添加状态
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
        /// <summary>
        /// 简历筛选进入页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ResumeIndex() {
            return View();
        }
        /// <summary>
        /// 查询职业部门
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMajor() {
            List<config_major_kind> majorList = major_bll.GetMajorKind();
            return Content(JsonConvert.SerializeObject(majorList));
        }
        /// <summary>
        /// 查询职业
        /// </summary>
        /// <returns></returns>
        public ActionResult GetFatherId() {
            config_major major = new config_major() {
                major_kind_id=Request["fatherId"]
            };
            List<config_major> list = major_FatherBll.GetMajor(major);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 有效简历筛选进入页面
        /// </summary>
        /// <returns></returns>
        public ActionResult EffectiveIndex()
        {
            return View();
        }
        /// <summary>
        /// 简历筛选
        /// </summary>
        /// <returns></returns>
        public ActionResult RecommendIndex() {
            string buMen = Request["buMen"];
            string zhiWei = Request["zhiWei"];
            string guanJian = Request["guanJian"];
            string openDate = Request["openDate"];
            string endDate = Request["endDate"];
            PageModel page = new PageModel() {
                CurrentPage=1,
                PageSize=100
            };
            Expression<Func<engage_resume, bool>> where = (e=>e.check_status==0&&e.human_name.Contains(guanJian)||e.human_telephone.Contains(guanJian));
            List<engage_resume> list = resume_bll.GetResume(e => e.res_id > 0, where, page);
            return View(list);
        }
        /// <summary>
        /// 有效简历筛选
        /// </summary>
        /// <returns></returns>
        public ActionResult EffectiveRecommendIndex()
        {
            string buMen = Request["buMen"];
            string zhiWei = Request["zhiWei"];
            string guanJian = Request["guanJian"];
            string openDate = Request["openDate"];
            string endDate = Request["endDate"];
            PageModel page = new PageModel()
            {
                CurrentPage = 1,
                PageSize = 100
            };
            Expression<Func<engage_resume, bool>> where = (e => e.check_status == 1 && e.human_name.Contains(guanJian) || e.human_telephone.Contains(guanJian));
            List<engage_resume> list = resume_bll.GetResume(e => e.res_id > 0, where, page);
            return View(list);
        }
        /// <summary>
        /// 简历筛选推荐
        /// </summary>
        /// <returns></returns>
        public ActionResult RecommendIndexShow(string id) {
            users user = Session["userClass"] as users;
            engage_resume resume = new engage_resume() {
                res_id=Convert.ToInt16(id)
            };
            resume = resume_bll.GetWhereResume(resume);
            resume.pass_checker = user.u_true_name;
            return View(resume);
        }
        /// <summary>
        /// 复核-》是否推荐
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public ActionResult RecommendUpdateState(engage_resume resume) {
            resume.check_status = 1;
            resume.check_time = DateTime.Now;
            users user = Session["userClass"] as users;
            resume.checker = user.u_true_name;
            if (resume_bll.UpdateState(resume) > 0)//修改成功
            {
                return RedirectToAction("ResumeIndex");
            }
            else {//修改失败
                return RedirectToAction("RecommendIndexShow", new { id = resume.res_id });
            }
        }
        /// <summary>
        /// 有效简历筛选
        /// </summary>
        /// <returns></returns>
        public ActionResult EffectiveRecommendIndexShow(string id)
        {
            engage_resume resume = new engage_resume()
            {
                res_id = Convert.ToInt16(id)
            };
            resume = resume_bll.GetWhereResume(resume);
            return View(resume);
        }
    }
}