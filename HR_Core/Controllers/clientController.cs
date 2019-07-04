using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bll;
using IBll;
using IOC;
using Models;
using Newtonsoft.Json;
namespace HR_Core.Controllers
{
    public class clientController : Controller
    {
        //一级机构
        config_file_first_kind first = new config_file_first_kind();
        config_file_first_kindIBLL firstbll = IocType.GetIocType<config_file_first_kindBLL>("config_file_first_kindBLL", "config_file_first_kindBLL");
        //二级机构
        config_file_second_kind second = new config_file_second_kind();
        config_file_second_kindIBLL secondbll = IocType.GetIocType<config_file_second_kindBLL>("config_file_second_kindBLL", "config_file_second_kindBLL");
        //三级机构
        config_file_third_kind third = new config_file_third_kind();
        config_file_third_kindIBLL thirdbll = IocType.GetIocType<config_file_third_kindBLL>("config_file_third_kindBLL", "config_file_third_kindBLL");
        //职称设置
        config_major_professional cmp = new config_major_professional();
        config_major_professionalIBLL cmpbll = IocType.GetIocType<config_major_professionalBLL>("config_major_professionalBLL", "config_major_professionalBLL");
        //职位分类设置 
        config_major_kind cmk = new config_major_kind();
        config_major_kindIBLL cmkbll = IocType.GetIocType<config_major_kindBLL>("config_major_kindBLL", "config_major_kindBLL");
        //职位设置 
        config_major ma = new config_major();
        config_majorIBLL mabll = IocType.GetIocType<config_majorBLL>("config_majorBLL", "config_majorBLL");
        //公共属性设置 
        config_public_char pc=new config_public_char();
        config_public_charIBLL pcbll = IocType.GetIocType<config_public_charBLL>("config_public_charBLL", "config_public_charBLL");
        //薪酬项目设置
        salary_project sp = new salary_project();
        salary_projectIBLL spbll = IocType.GetIocType<salary_projectBLL>("salary_projectBLL", "salary_projectBLL");
        // GET: client
        #region   一级机构
        [HttpGet]
        public ActionResult first_kind()
        {
            return View();
        }
        [HttpPost]
        public ActionResult first_kindSelect()
        {
            List<config_file_first_kind> list = firstbll.SelectFirst_kind();
            return Content(JsonConvert.SerializeObject(list));
        }
        //新增
        [HttpGet]
        public ActionResult first_kind_register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult first_kind_register(config_file_first_kind first)
        {
            int num = firstbll.config_file_first_kindInsert(first);
            if (num>0)
            {
                return RedirectToAction("first_kind_register_success");
            }
            else
            {
                return View("first_kind_register", num);
            }
        }
        public ActionResult first_kind_register_success()
        {
            return View();
        }
        //删除
        public ActionResult first_delete(short id)
        {
            first.ffk_id = id;
            int num = firstbll.config_file_first_kindDel(first, first.ffk_id);
            if (num>0)
            {
                return RedirectToAction("first_delete_success");
            }
            else
            {
                return View(num);
            }
        }
        public ActionResult first_delete_success()
        {
            return View();
        }
        //按id查询
        [HttpGet]
        public ActionResult first_kind_change(short id)
        {
            List<config_file_first_kind> list = firstbll.selectWhere(e=>e.ffk_id==id);
            //config_file_first_kind first = list.FirstOrDefault();
            return View(list);
        }
        public ActionResult first_kind_changeUpdate(config_file_first_kind first)
        {
            int num = firstbll.config_file_first_kindUpdate(first, first.ffk_id);
            if (num>0)
            {
                return RedirectToAction("first_kind_change_success");
            } else{
                return View(num);
            }
        }
        public ActionResult first_kind_change_success()
        {
            return View();
        }
        #endregion
        #region 二级机构
        [HttpGet]
        public ActionResult second_kind()
        {
            return View();
        }
        [HttpPost]
        public ActionResult second_kindSelect()
        {
            List<config_file_second_kind> list = secondbll.Second_kind();
            return Json(list);
        }
        //一级下拉列表框
        private void GetList()
        {
            List<config_file_first_kind> list = firstbll.SelectFirst_kind();
            ViewData["dt"] = list;
        }
        //新增
        [HttpGet]
        public ActionResult second_kind_register()
        {
            GetList();
            return View();
        }
        [HttpPost]
        public ActionResult second_kind_register(config_file_second_kind second)
        {
            int num = secondbll.config_file_second_kindInsert(second);
            if (num > 0)
            {
                return RedirectToAction("second_kind_register_success");
            }
            else
            {
                GetList();
                return View(num);
            }
        }
        public ActionResult second_kind_register_success()
        {
            return View();
        }
        //删除
        public ActionResult second_delete(short id)
        {
            second.fsk_id = id;
            int num = secondbll.config_file_second_kindDel(second,second.fsk_id);
            if (num>0)
            {
                return RedirectToAction("second_delete_success");
            }
            else
            {
                return View(num);
            }
        }
        public ActionResult second_delete_success()
        {
            return View();
        }
        //按id查询
        [HttpGet]
        public ActionResult second_kind_change(short id)
        {
            List<config_file_second_kind> list = secondbll.config_file_second_kindselectWhere(e=>e.fsk_id==id);
            return View(list);
        }
        [HttpPost]
        public ActionResult second_kind_change(config_file_second_kind second)
        {
            int num = secondbll.config_file_second_kindUpdate(second,second.fsk_id);
            if (num>0)
            {
                return RedirectToAction("second_kind_change_success");
            }
            else
            {
                return View(num);
            }
        }
        public ActionResult second_kind_change_success()
        {
            return View();
        }
        #endregion
        #region 三级机构
        [HttpGet]
        public ActionResult third_kind()
        {
            return View();
        }
        [HttpPost]
        public ActionResult third_kindSelect()
        {
            List<config_file_third_kind> list = thirdbll.third_kind();
            return Json(list);
        }
        //二级机构下拉
        public ActionResult SecondGetList()
        {
            List<config_file_second_kind> list = secondbll.Second_kind();
            return Content(JsonConvert.SerializeObject(list));
        }
        //新增
        [HttpGet]
        public ActionResult third_kind_register()
        {
            GetList();//调用一级下拉方法
            return View();
        }
        [HttpPost]
        public ActionResult third_kind_register(config_file_third_kind third)
        {
            int num = thirdbll.config_file_third_kindInsert(third);
            if (num>0)
            {
                return RedirectToAction("third_kind_register_success");
            }
            else
            {
                return View();
            }
        }
        public ActionResult third_kind_register_success()
        {
            return View();
        }
        //删除
        public ActionResult third_delete(short id)
        {
            third.ftk_id = id;
            int num = thirdbll.config_file_third_kindDel(third,third.ftk_id);
            if (num>0)
            {
                return RedirectToAction("third_delete_success");
            }
            else
            {
                return View(num);
            }
        }
        public ActionResult third_delete_success()
        {
            return View();
        }
        //按id查询
        [HttpGet]
        public ActionResult third_kind_change(short id)
        {
            List<config_file_third_kind> list = thirdbll.config_file_third_kindselectWhere(e=>e.ftk_id==id);
            config_file_third_kind th = list.FirstOrDefault();//转成对象返回一个元素
            return View(th);
        }
        [HttpPost]
        public ActionResult third_kind_change(config_file_third_kind third)
        {
            int num = thirdbll.config_file_third_kindUpdate(third,third.ftk_id);
            if (num>0)
            {
                return RedirectToAction("third_kind_change_success");
            }
            else
            {
                return View(num);
            }
        }
        public ActionResult third_kind_change_success()
        {
            return View();
        }
        #endregion
        #region 职称设置
        public ActionResult profession_design()
        {
            List<config_major_professional> list = cmpbll.config_major_professionalSelect();
            return View(list);
        }
        public ActionResult profession_designDelete(short id)
        {
            cmp.pr_id = id;
            int num = cmpbll.config_major_professionalDelete(cmp,cmp.pr_id);
            if (num>0)
            {
                return Content("<script>alert('删除成功！！！');location.href='/client/profession_design'</script>");
            }
            else
            {
                return View(num);
            }
        }
        #endregion
        #region 职位分类设置
        //查询
        public ActionResult major_kind()
        {
            return View();
        }
        public ActionResult major_kindselect()
        {
            List<config_major_kind> list = cmkbll.GetMajorKind();
            return Content(JsonConvert.SerializeObject(list));
        }
        //删除
        public ActionResult major_kindDelete(short id)
        {
            cmk.mfk_id = id;
            int num = cmkbll.config_major_kindDel(cmk,cmk.mfk_id);
            if (num>0)
            {
                return Content("<script>alert('删除成功！！！');location.href='/client/major_kind'</script>");
            }
            else
            {
                return View(num);
            }
        }
        //新增
        [HttpGet]
        public ActionResult major_kind_add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult major_kind_add(config_major_kind  cmk)
        {
            int num = cmkbll.config_major_kindInsert(cmk);
            if (num>0)
            {
                return Content("<script>alert('新增成功！！！');location.href='/client/major_kind'</script>");
            }
            else
            {
                return View();
            }
        }
        #endregion
        #region 职位设置
        public ActionResult major()
        {
            List<config_major> list = mabll.config_majorSelect();
            return View(list);
        }
        //删除
        public ActionResult majorDel(short id)
        {
            ma.mak_id = id;
            int num = mabll.config_majorDel(ma,ma.mak_id);
            if (num>0)
            {
                return Content("<script>alert('删除成功！！！');location.href='/client/major'</script>");
            }
            else
            {
                return View(num);
            }
        }
        //新增
        [HttpGet]
        public ActionResult major_add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult major_add(config_major ma)
        {
            int num = mabll.config_majorInsert(ma);
            if (num>0)
            {
                return Content("<script>alert('新增成功！！！');location.href='/client/major'</script>");
            }
            else
            {
                return View(num);
            }
        }
        #endregion
        #region 公共属性设置 
        public ActionResult public_char()
        {
            List<config_public_char> list = pcbll.config_public_charSelect();
            return View(list);
        }
        public ActionResult public_charDelete(short id)
        {
            pc.pbc_id = id;
            int num = pcbll.config_public_charDel(pc,pc.pbc_id);
            if (num>0)
            {
                return Content("<script>alert('删除成功！！！');location.href='/client/public_char'</script>");
            }
            else
            {
                return View(num);
            }
        }
        //新增
        [HttpGet]
        public ActionResult public_char_add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult public_char_add(config_public_char pc)
        {
            int num = pcbll.config_public_charInsert(pc);
            if (num>0)
            {
                return Content("<script>alert('新增成功！！！');location.href='/client/public_char'</script>");
            }
            else
            {
                return View(num);
            }
        }
        #endregion
        #region 薪酬项目设置
        public ActionResult salary_item()
        {
            List<salary_project> list = spbll.selectsalary_project();
            return View(list);
        }
        public ActionResult salary_itemDel(short id)
        {
            sp.item_id = id;
            int num = spbll.salary_projectDel(sp,sp.item_id);
            if (num>0)
            {
                return Content("<script>alert('删除成功！！！');location.href='/client/salary_item'</script>");
            }
            else
            {
                return View(num);
            }
        }
        [HttpGet]
        public ActionResult salary_item_register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult salary_item_register(salary_project sp)
        {
            int num = spbll.salary_projectInsert(sp);
            if (num > 0)
            {
                return Content("<script>alert('新增成功！！！');location.href='/client/salary_item';</script>");
            }
            else
            {
                return View(num);
            }
        }
        #endregion
    }
}