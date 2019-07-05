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
using System.Transactions;
using System.IO;

namespace HR_Core.Controllers
{
    public class HumanResourcesController : Controller
    {
        private engage_resumeIBLL resume_bll = IocType.GetIocType<engage_resumeBLL>("engage_resumeBLL", "engage_resumeBLL");
        private engage_interviewIBLL inter_bll = IocType.GetIocType<engage_interviewBLL>("engage_interviewBLL", "engage_interviewBLL");
        private config_file_first_kindIBLL fir_bll = IocType.GetIocType<config_file_first_kindBLL>("config_file_first_kindBLL", "config_file_first_kindBLL");
        private config_file_second_kindIBLL sec_bll = IocType.GetIocType<config_file_second_kindBLL>("config_file_second_kindBLL", "config_file_second_kindBLL");
        private config_file_third_kindIBLL thi_bll = IocType.GetIocType<config_file_third_kindBLL>("config_file_third_kindBLL", "config_file_third_kindBLL");
        private salary_standardIBLL standard_bll = IocType.GetIocType<salary_standardBLL>("salary_standardBLL", "salary_standardBLL");
        private human_fileIBLL file_bll = IocType.GetIocType<human_fileBLL>("human_fileBLL", "human_fileBLL");
        /// <summary>
        /// 人力资源待录用查询
        /// </summary>
        /// <returns></returns>
        // GET: HumanResources
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList()
        {
            PageModel page = new PageModel()
            {
                CurrentPage = Convert.ToInt32(Request["currNum"]),
                PageSize = 3
            };
            List<engage_resume> list = resume_bll.GetLuYong(page);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("data", list);
            dic.Add("page", page);
            return Content(JsonConvert.SerializeObject(dic));
        }
        /// <summary>
        /// 人力资源登记
        /// </summary>
        /// <returns></returns>
        public ActionResult Register(string id) {
            engage_interview inter = inter_bll.GetResumeIdClass(Convert.ToInt32(id));//面试对象
            return View(inter);
        }
        /// <summary>
        /// 人力资源档案登记页面
        /// </summary>
        /// <returns></returns>
        public ActionResult InsertHuman_file(string id) {
            engage_resume resume = new engage_resume() {
                res_id = Convert.ToInt16(id)
            };
            resume = resume_bll.GetWhereResume(resume);
            return View(resume);
        }
        /// <summary>
        /// 查询一级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult GetOne() {
            List<config_file_first_kind> list = fir_bll.SelectFirst_kind();
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 查询二级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTow()
        {
            config_file_second_kind sec = new config_file_second_kind() {
                first_kind_id=Request["fatherId"]
            };
            List<config_file_second_kind> list = sec_bll.SelectSecond_kind(sec);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 查询三级机构
        /// </summary>
        /// <returns></returns>
        public ActionResult GetThree()
        {
            config_file_third_kind thi = new config_file_third_kind()
            {
                second_kind_id = Request["fatherId"]
            };
            List<config_file_third_kind> list = thi_bll.GetThird(thi);
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 查询所有薪酬标准
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMoeny() {
            List<salary_standard> list = standard_bll.SelectAll();
            return Content(JsonConvert.SerializeObject(list));
        }
        /// <summary>
        /// 提交数据及文件上传
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult InsertFile(human_file file) {
            human_file fileInsert = file;
            salary_standard standard = standard_bll.salary_standardselectWhere(e => e.standard_id == file.salary_standard_id);
            fileInsert.salary_sum = standard.salary_sum;//薪酬基本总额
            fileInsert.demand_salaray_sum = standard.salary_sum;//应发金额
            fileInsert.paid_salary_sum = standard.salary_sum;//应发金额
            fileInsert.major_change_amount = 0;
            fileInsert.bonus_amount = 0;
            fileInsert.training_amount = 0;
            fileInsert.file_chang_amount = 0;
            //修改简历信息
            engage_resume resume = new engage_resume() {
                res_id=Convert.ToInt16(fileInsert.human_id)
            };
            resume = resume_bll.GetWhereResume(resume);
            resume.pass_passComment = "已入档案";
            int ok = 0;
            using (TransactionScope ts = new TransactionScope())
            {
                ok += resume_bll.UpdateResumeState(resume);
                ok += file_bll.InsertFile(fileInsert);
                if (ok == 2)
                {
                    ts.Complete();//提交事务
                    ViewBag.fileHumanId = fileInsert.human_id;
                    return View();
                }
                else {
                    return RedirectToAction("InsertHuman_file", "HumanResources", fileInsert.human_id);
                }
            }
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadX(HttpPostedFileBase file)
        {
            int ok = 0;
            if (file != null)
            {
                string id = Request["fileId"];
                human_file fileUpdate = new human_file();
                fileUpdate = file_bll.SelectHuanm(e => e.human_id == id);
                //
                string fileName = Path.GetFileName(file.FileName);//获取文件名
                int i = fileName.IndexOf('.');
                fileUpdate.attachment_name = fileName.Substring(0, i);//获取相片名称
                string path = Server.MapPath(string.Format("~/{0}", "Files"));//保存路径
                if (!Directory.Exists(path))//判断是否有保存路径
                {
                    Directory.CreateDirectory(path);//没有就再创一个需要的
                }
                file.SaveAs(Path.Combine(path, fileName));//保存图片
                fileUpdate.human_picture = fileName;//路径=存储路径+文件名+文件后缀
                ok += file_bll.UpdateFile(fileUpdate);
            }
            if (ok == 1)
            {
                return View("Index");
            }
            else {
                return RedirectToAction("InsertHuman_file", "HumanResources", Request["fileId"]);
            }
        }
    }
}