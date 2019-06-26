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
using System.Web.Script.Serialization;

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
        private engage_major_releaseIBLL release_bll = IocType.GetIocType<engage_major_releaseBLL>("engage_major_releaseBLL", "engage_major_releaseBLL");
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
                first_kind_id=Request["fatherId"]
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
                second_kind_id = Request["fatherId"]
            };
            List<config_file_third_kind> list = third_bll.GetThird(third);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 查询职位分类
        /// </summary>
        /// <returns></returns>
        public ActionResult engageTypeVue()
        {
            List<config_major_kind> list = major_kind_bll.GetMajorKind();
            return Content(JsonConvert.SerializeObject(list));
        }

        /// <summary>
        /// 查询职位名称
        /// </summary>
        /// <returns></returns>
        public ActionResult majorIdVue()
        {
            config_major major = new config_major()
            {
                major_kind_id = Request["fatherId"]
            };
            List<config_major> list = major_bll.GetMajor(major);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult classInsert() {
            //将字符串转换成类
            engage_major_release major = new JavaScriptSerializer().Deserialize<engage_major_release>(Request["insert"]);
            int result = release_bll.InsertClass(major);
            return Content(result.ToString());
        }
        /// <summary>
        /// 查询所有信息
        /// </summary>
        /// <returns></returns>
        public ActionResult classUpdate() {
            return View();
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public ActionResult classPage() {
            PageModel page = new PageModel()
            {
                CurrentPage = Convert.ToInt32(Request["currentPage"]),
                PageSize = 3//每页显示记录数
            };
            List<engage_major_release> datas = release_bll.PageRelease(e => e.mre_id, e => e.mre_id > 0, page);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("data", datas);
            dic.Add("page", page);
            return Content(JsonConvert.SerializeObject(dic));
        }
        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult updateShow(int id)
        {
            engage_major_release major = release_bll.GetMajorId(id);
            users user = Session["userClass"] as users;
            ViewData["genGai"] = user.u_true_name;
            return View(major);
        }
        /// <summary>
        /// 修改页面提交
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult updateShow(engage_major_release major)
        {
            int ok = release_bll.UpdateMajor(major);
            if (ok > 0)
            {
                return RedirectToAction("classUpdate");
            }
            else {
                return RedirectToAction("updateShow", new { id = major.mre_id });
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult deleteShow(int id) {
            engage_major_release rele = new engage_major_release() {
                mre_id =Convert.ToInt16(id)

            };
            release_bll.DeleteMajor(rele);
            return RedirectToAction("classUpdate");
        }
        /// <summary>
        /// 职位发布查询
        /// </summary>
        /// <returns></returns>
        public ActionResult Position() {
            return View();
        }
        /// <summary>
        /// 申请职位
        /// </summary>
        /// <returns></returns>
        public ActionResult PositionOut(int id) {
            engage_major_release major = release_bll.GetMajorId(id);
            return View(major);
        }
    }
}