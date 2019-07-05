using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IOC;
using Bll;
using IBll;
using System.Linq.Expressions;
using System.Transactions;

namespace HR_Core.Controllers
{
    public class DeletHumanController : Controller
    {
        private human_fileIBLL file_bll = IocType.GetIocType<human_fileBLL>("human_fileBLL", "human_fileBLL");
        private human_file_digIBLL dig_bll = IocType.GetIocType<human_file_digBLL>("human_file_digBLL", "human_file_digBLL");
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        // GET: DeletHuman
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult ListFile(human_file file)
        {
            int i = 0;
            List<human_file> list = new List<human_file>();
            Expression<Func<human_file, bool>> where = (e => e.huf_id > 0);
            if (file.first_kind_id != "" && file.first_kind_id != null)
            {
                where = (e => e.first_kind_id == file.first_kind_id);
                i++;
                if (file.second_kind_id != "" && file.second_kind_id != null)
                {
                    i++;
                    where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id);
                    if (file.third_kind_id != "" && file.third_kind_id != null)
                    {
                        i++;
                        where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id);
                    }
                }
            }

            if (i == 1)
            {
                where = (e => e.first_kind_id == file.first_kind_id);
                if (file.human_major_kind_id != "" && file.human_major_kind_id != null)
                {//职位分类
                    where = (e => e.first_kind_id == file.first_kind_id && e.human_major_kind_id == file.human_major_kind_id);
                    if (file.human_major_id != "" && file.human_major_id != null)
                    {
                        where = (e => e.first_kind_id == file.first_kind_id && e.human_major_kind_id == file.human_major_kind_id && e.human_major_id == file.human_major_id);
                    }
                }
            }
            else if (i == 2)
            {
                where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id);
                if (file.human_major_kind_id != "" && file.human_major_kind_id != null)
                {//职位分类
                    where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.human_major_kind_id == file.human_major_kind_id);
                    if (file.human_major_id != "" && file.human_major_id != null)
                    {
                        where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.human_major_kind_id == file.human_major_kind_id && e.human_major_id == file.human_major_id);
                    }
                }
            }
            else if (i == 3)
            {
                where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id);
                if (file.human_major_kind_id != "" && file.human_major_kind_id != null)
                {//职位分类
                    where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id && e.human_major_kind_id == file.human_major_kind_id);
                    if (file.human_major_id != "" && file.human_major_id != null)
                    {
                        where = (e => e.first_kind_id == file.first_kind_id && e.second_kind_id == file.second_kind_id && e.third_kind_id == file.third_kind_id && e.human_major_kind_id == file.human_major_kind_id && e.human_major_id == file.human_major_id);
                    }
                }
            }
            list = file_bll.ListWhere(where);
            return View(list);
        }
        /// <summary>
        /// 删除的展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteShow(string id) {
            human_file file = new human_file() {
                huf_id = Convert.ToInt16(id)
            };
            file = file_bll.SelectHuanm(e => e.huf_id == file.huf_id);
            return View(file);
        }
        /// <summary>
        /// 一个主表的删除，附表的添加
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(string id) {
            human_file fileDelete = new human_file()
            {
                huf_id = Convert.ToInt16(id)
            };
            fileDelete = file_bll.SelectHuanm(e => e.huf_id == fileDelete.huf_id);
            human_file_dig dig = new human_file_dig {
                human_id=fileDelete.human_id,
                first_kind_id = fileDelete.first_kind_id,
                first_kind_name = fileDelete.first_kind_name,
                second_kind_name = fileDelete.second_kind_name,
                second_kind_id = fileDelete.second_kind_id,
                third_kind_id = fileDelete.third_kind_id,
                third_kind_name = fileDelete.third_kind_name,
                human_name = fileDelete.human_name,
                human_address = fileDelete.human_address,
                human_postcode = fileDelete.human_postcode,
                human_pro_designation = fileDelete.human_pro_designation,
                human_major_kind_id = fileDelete.human_major_kind_id,
                human_major_kind_name = fileDelete.human_major_kind_name,
                human_major_id = fileDelete.human_major_id,
                hunma_major_name = fileDelete.hunma_major_name,
                human_telephone = fileDelete.human_telephone,
                human_mobilephone = fileDelete.human_mobilephone,
                human_bank = fileDelete.human_bank,
                human_account = fileDelete.human_account,
                human_qq = fileDelete.human_qq,
                human_email = fileDelete.human_email,
                human_hobby = fileDelete.human_hobby,
                human_speciality = fileDelete.human_speciality,
                human_sex = fileDelete.human_sex,
                human_religion = fileDelete.human_religion,
                human_party = fileDelete.human_party,
                human_nationality = fileDelete.human_nationality,
                human_race = fileDelete.human_race,
                human_birthday = fileDelete.human_birthday,
                human_birthplace = fileDelete.human_birthplace,
                human_age = fileDelete.human_age,
                human_educated_degree = fileDelete.human_educated_degree,
                human_educated_years = fileDelete.human_educated_years,
                human_educated_major = fileDelete.human_educated_major,
                human_society_security_id = fileDelete.human_society_security_id,
                human_id_card = fileDelete.human_id_card,
                remark = fileDelete.remark,
                salary_standard_id = fileDelete.salary_standard_id,
                salary_standard_name = fileDelete.salary_standard_name,
                salary_sum = fileDelete.salary_sum,
                demand_salaray_sum = fileDelete.demand_salaray_sum,
                paid_salary_sum = fileDelete.paid_salary_sum,
                major_change_amount = fileDelete.major_change_amount,
                bonus_amount = fileDelete.bonus_amount,
                training_amount = fileDelete.training_amount,
                file_chang_amount = fileDelete.file_chang_amount,
                human_histroy_records = fileDelete.human_histroy_records,
                human_family_membership = fileDelete.human_family_membership,
                human_picture = fileDelete.human_picture,
                attachment_name = fileDelete.attachment_name,
                check_status = fileDelete.check_status,
                register = fileDelete.register,
                checker = fileDelete.checker,
                changer = fileDelete.changer,
                regist_time = fileDelete.regist_time,
                check_time = fileDelete.check_time,
                change_time = fileDelete.change_time,
                lastly_change_time = fileDelete.lastly_change_time,
                recovery_time = fileDelete.recovery_time,
                human_file_status = fileDelete.human_file_status
            };
            dig.delete_time = DateTime.Now;
            int ok = 0;
            using (TransactionScope ts = new TransactionScope())
            {
                ok += file_bll.DeleteClass(fileDelete);
                ok += dig_bll.InsertClass(dig);
                if (ok == 2)
                {
                    ts.Complete();//提交事务
                    return RedirectToAction("Index", "DeletHuman");
                }
                else {
                    return RedirectToAction("DeleteShow", "DeletHuman", fileDelete.huf_id);
                }
            }
        }
        /// <summary>
        /// 恢复
        /// </summary>
        /// <returns></returns>
        public ActionResult HuiFu() {
            List<human_file_dig> digList = dig_bll.ListDig();
            return View(digList);
        }
        /// <summary>
        /// 恢复详细
        /// </summary>
        /// <returns></returns>
        public ActionResult HufuShow(string id) {
            human_file_dig dig = new human_file_dig() {
                hfd_id = Convert.ToInt16(id)
            };
            dig = dig_bll.digClass(e => e.hfd_id == dig.hfd_id);
            return View(dig);
        }

        public ActionResult GoHuifu(string id) {
            human_file_dig fileDelete = new human_file_dig()
            {
                hfd_id = Convert.ToInt16(id)
            };
            fileDelete = dig_bll.digClass(e => e.hfd_id == fileDelete.hfd_id);
            human_file dig = new human_file
            {
                human_id = fileDelete.human_id,
                first_kind_id = fileDelete.first_kind_id,
                first_kind_name = fileDelete.first_kind_name,
                second_kind_name = fileDelete.second_kind_name,
                second_kind_id = fileDelete.second_kind_id,
                third_kind_id = fileDelete.third_kind_id,
                third_kind_name = fileDelete.third_kind_name,
                human_name = fileDelete.human_name,
                human_address = fileDelete.human_address,
                human_postcode = fileDelete.human_postcode,
                human_pro_designation = fileDelete.human_pro_designation,
                human_major_kind_id = fileDelete.human_major_kind_id,
                human_major_kind_name = fileDelete.human_major_kind_name,
                human_major_id = fileDelete.human_major_id,
                hunma_major_name = fileDelete.hunma_major_name,
                human_telephone = fileDelete.human_telephone,
                human_mobilephone = fileDelete.human_mobilephone,
                human_bank = fileDelete.human_bank,
                human_account = fileDelete.human_account,
                human_qq = fileDelete.human_qq,
                human_email = fileDelete.human_email,
                human_hobby = fileDelete.human_hobby,
                human_speciality = fileDelete.human_speciality,
                human_sex = fileDelete.human_sex,
                human_religion = fileDelete.human_religion,
                human_party = fileDelete.human_party,
                human_nationality = fileDelete.human_nationality,
                human_race = fileDelete.human_race,
                human_birthday = fileDelete.human_birthday,
                human_birthplace = fileDelete.human_birthplace,
                human_age = fileDelete.human_age,
                human_educated_degree = fileDelete.human_educated_degree,
                human_educated_years = fileDelete.human_educated_years,
                human_educated_major = fileDelete.human_educated_major,
                human_society_security_id = fileDelete.human_society_security_id,
                human_id_card = fileDelete.human_id_card,
                remark = fileDelete.remark,
                salary_standard_id = fileDelete.salary_standard_id,
                salary_standard_name = fileDelete.salary_standard_name,
                salary_sum = fileDelete.salary_sum,
                demand_salaray_sum = fileDelete.demand_salaray_sum,
                paid_salary_sum = fileDelete.paid_salary_sum,
                major_change_amount = fileDelete.major_change_amount,
                bonus_amount = fileDelete.bonus_amount,
                training_amount = fileDelete.training_amount,
                file_chang_amount = fileDelete.file_chang_amount,
                human_histroy_records = fileDelete.human_histroy_records,
                human_family_membership = fileDelete.human_family_membership,
                human_picture = fileDelete.human_picture,
                attachment_name = fileDelete.attachment_name,
                check_status = fileDelete.check_status,
                register = fileDelete.register,
                checker = fileDelete.checker,
                changer = fileDelete.changer,
                regist_time = fileDelete.regist_time,
                check_time = fileDelete.check_time,
                change_time = fileDelete.change_time,
                lastly_change_time = fileDelete.lastly_change_time,
                recovery_time = fileDelete.recovery_time,
                human_file_status = fileDelete.human_file_status,
                delete_time=fileDelete.delete_time
            };
            int ok = 0;
            using (TransactionScope ts = new TransactionScope())
            {
                ok += file_bll.InsertFile(dig);
                ok += dig_bll.Delete(fileDelete);
                if (ok == 2)
                {
                    ts.Complete();//提交事务
                    return RedirectToAction("HuiFu", "DeletHuman");
                }
                else {
                    return RedirectToAction("HufuShow", "DeletHuman", fileDelete.hfd_id);
                }
            }
        }
        /// <summary>
        /// 删除的列表
        /// </summary>
        /// <returns></returns>
        public ActionResult EndDelete() {
            List<human_file_dig> digList = dig_bll.ListDig();
            return View(digList);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EndDeleteGo(string id) {
            human_file_dig dig = new human_file_dig() {
                hfd_id=Convert.ToInt16(id)
            };
            int ok = dig_bll.Delete(dig);
            return RedirectToAction("EndDelete", "DeletHuman");
        }

    }
}