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
using System.Transactions;

namespace HR_Core.Controllers
{
    /// <summary>
    /// 面试管理
    /// </summary>
    public class InterviewController : Controller
    {
        private engage_resumeIBLL resume_bll = IocType.GetIocType<engage_resumeBLL>("engage_resumeBLL", "engage_resumeBLL");
        private engage_interviewIBLL inter_bll = IocType.GetIocType<engage_interviewBLL>("engage_interviewBLL", "engage_interviewBLL");
        /// <summary>
        /// 面试结果登记
        /// </summary>
        /// <returns></returns>
        // GET: Interview
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList()
        {
            PageModel page = new PageModel()
            {
                CurrentPage = Convert.ToInt32(Request["currNum"]),
                PageSize = 3
            };
            List<engage_resume> list = resume_bll.ResumeData<object>(page);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("data", list);
            dic.Add("page", page);
            return Content(JsonConvert.SerializeObject(dic));
        }
        /// <summary>
        /// 进入面试成绩登记
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetShow(string id) {
            engage_resume resume = new engage_resume() {
                res_id = Convert.ToInt16(id)
            };
            resume = resume_bll.GetWhereResume(resume);
            int count = 0;
            List<engage_interview> listInter = inter_bll.GetInterview(resume);
            if (listInter.Count > 0)
            {
                count = Convert.ToInt32(listInter.FirstOrDefault().interview_amount);
                ViewData["thisId"] = listInter.FirstOrDefault().ein_id;
            }
            ViewData["interNum"] = count + 1;
            users user = Session["userClass"] as users;
            ViewData["userName"] = user.u_true_name;
            return View(resume);
        }
        /// <summary>
        /// 面试结果登记
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public ActionResult InsertView(engage_interview interview) {
            engage_resume resume = new engage_resume()
            {
                human_name = interview.human_name
            };
            if (inter_bll.GetInterview(resume).Count > 0)//修改
            {
                if (inter_bll.UpdateInter(interview) > 0)
                {
                    return RedirectToAction("Index", "Interview");
                }
                else {
                    return RedirectToAction("GetShow", "Interview", interview.resume_id);
                }
            }
            else {//添加
                if (inter_bll.InsertInter(interview) > 0)
                {
                    return RedirectToAction("Index", "Interview");
                }
                else {
                    return RedirectToAction("GetShow", "Interview", interview.resume_id);
                }
            }

        }
        /// <summary>
        /// 面试筛选
        /// </summary>
        /// <returns></returns>
        public ActionResult ResultInterview() {
            return View();
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        public ActionResult GetInterview() {
            PageModel page = new PageModel()
            {
                CurrentPage = Convert.ToInt32(Request["currNum"]),
                PageSize = 3
            };
            List<engage_interview> list = inter_bll.GetPage(page);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("data", list);
            dic.Add("page", page);
            return Content(JsonConvert.SerializeObject(dic));
        }
        /// <summary>
        /// 面试筛选详细
        /// </summary>
        /// <param name="interId"></param>
        /// <returns></returns>
        public ActionResult ResultInterviewShow(int id)
        {
            engage_interview inter = inter_bll.GetInterId(Convert.ToInt32(id));
            return View(inter);
        }
        /// <summary>
        /// 查询Resume
        /// </summary>
        /// <returns></returns>
        public ActionResult GetResume() {
            engage_resume resume = new engage_resume() {
                res_id=Convert.ToInt16(Request["thisId"])
            };
            resume = resume_bll.GetWhereResume(resume);
            return Content(JsonConvert.SerializeObject(resume));
        }
        /// <summary>
        /// 面试筛选--建议面试  建议笔试  建议录用  删除简历
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public ActionResult UpdateRuselt(engage_interview interview) {
            using (TransactionScope ts=new TransactionScope())
            {
                int ok = 0;
                ok += inter_bll.UpdateInter(interview);
                engage_resume resume = new engage_resume() {
                    res_id = Convert.ToInt16(interview.resume_id)
                };
                resume = resume_bll.GetWhereResume(resume);//先查询一遍
                resume.pass_checkComment = Request["shenHeYiJian"];
                if (interview.result.Equals("建议录用")) {
                    resume.pass_checkComment = Request["shenHeYiJian"];
                    resume.pass_check_time = DateTime.Now;
                    users user = Session["userClass"] as users;
                    resume.pass_checker = user.u_true_name;
                }
                if (interview.result.Equals("删除简历")) {
                    resume.pass_check_status = 0;
                }
                else if (interview.result.Equals("建议面试")) {
                    resume.pass_check_status = 1;
                }
                else if (interview.result.Equals("建议笔试"))
                {
                    resume.pass_check_status = 2;
                }
                else if (interview.result.Equals("建议录用"))
                {
                    resume.pass_check_status = 3;
                }
                ok += resume_bll.UpdateResumeState(resume);
                if (ok == 2)
                {
                    ts.Complete();//提交事务
                    return RedirectToAction("ResultInterview", "Interview");
                }
                else {
                    return RedirectToAction("ResultInterviewShow", "Interview", interview.ein_id);
                }
            } 
        }
    }
}