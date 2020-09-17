using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using hospital1;
using hospitalDTO;

namespace MVCtest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Doctor doctor = new Doctor();
            doctor.doctor_ID = "002";
            return View("registe");
        }

        [HttpGet]
        public ActionResult registe()
        {
            return View("registe");
        }
        //管理员账号注册
        public ActionResult ManAdd(string ID,string pass,string name)
        {

            AccountService accountService = new AccountService();
            accountService.AddNew(ID, pass, name, "Manager");
            //返回值待定
            return Json("成");

        }
        public ActionResult Manager(string ID,string pass)
        {
            AccountService accountService = new AccountService();
            accountService.AddNew(ID, pass, "shghuwq", "manager");
            //返回值待定
            return Json("成");

        }
        //医生账号注册
        public ActionResult ManAdd2(string userID, string name,string pass,string dept,
            string position,string age,string sex)
        {
            AccountService accountService = new AccountService();
            DoctorService doctorService = new DoctorService();
            Account account = new Account();
            accountService.AddNew(userID, pass, name, "Doctor");
            account.user_ID = userID;
            account.name = name;
            int iu = int.Parse(age);
            doctorService.AddNew(account, dept, position, 0, iu, sex);
           //返回值待定
            return RedirectToAction("Index");
        }
        //医生账号注册
        public ActionResult ManAdd123(string nurseID, string nurseName)
        {
            AccountService accountService = new AccountService();
            DoctorService doctorService = new DoctorService();
            Account account = new Account();
            accountService.AddNew(nurseID, "000000", nurseName, "D");
            account.user_ID = nurseID;
            account.name = nurseName;
            doctorService.AddNew(account, "妇产科", "主任", 30000, 20, "女");
            //返回值待定
            return RedirectToAction("Index");
        }
        //护士账号注册
        public ActionResult ManAdd1(string nurseID, string nurseName, string nursePassword, string nursePosition, string nurseDept_name,
             string nurseGender)
        {
            AccountService accountService = new AccountService();
            NurseService nurseService = new NurseService();
            Account account = new Account();
            accountService.AddNew(nurseID, nursePassword, nurseName, "Nurse");
            account.user_ID = nurseID;
            account.name = nurseName;
            nurseService.AddNew(account, nurseDept_name, nursePosition, 0, nurseGender);
            //返回值待定
            return RedirectToAction("Index");
        }
        //修改密码袖珍版
        public ActionResult ChangeAccount(string ID,string pass)
        {
            AccountService accountService = new AccountService();
            if (accountService.Update(ID, pass) == true)
                return Json("ture");
            else
                return Json("false");
        }
        //修改密码
        public ActionResult ChangeAc(string username, string name ,string pass,string checkPass)
        {
            AccountService accountService = new AccountService();
            if (pass==checkPass&&accountService.Update(username,name, pass) == true)
                return Json("ture");
            else
                return Json("false");
        }
        //账号登录验证
        public ActionResult Login(string ID,string pass)
        {
            AccountService accountService = new AccountService();
            RegisterService registerService = new RegisterService();
            AccountDTO accountDTO = accountService.Login(ID, pass);
            if (accountDTO != null)
            {
                registerService.Update(ID);
                return Json(accountDTO);
            }
            else
                return Json(null);
        }
        //签到记录
        public ActionResult Acttendance(string ID,string pass)
        {
            AttendanceService attendanceService = new AttendanceService();
            if (attendanceService.AddNew(ID) == true)

                return Content("true");
            else
                return Content("false");
        }
        //验证签到记录
        public ActionResult IsActtendanced(string ID,string time)
        {
            AttendanceService attendanceService = new AttendanceService();
            if (attendanceService.IsAttendanced(ID,time) == true)
                return Content("trued");
            else
                return Content("falsed");
        }
        //返回签到次数与签到率
        public ActionResult AttendanceTimes(string ID, string pass)
        {
            AttendanceService attendanceService = new AttendanceService();
            return Json(attendanceService.GetTimes(ID));
            /*    return Content("trued");
            else
                return Content("falsed");*/
        }
        [HttpPost]
        public ActionResult RegisterAdd(string ID)
        {

            RegisterService registerService = new RegisterService();
            registerService.AddNew(ID);
            return RedirectToAction("Index");

        }
        public ActionResult Delete(string ID,string pass)
        {

            AccountService accountService = new AccountService();
            accountService.Delete(ID);
            return Json("shou");

        }
        /*public ActionResult RegisterAccount()
        {

        }*/

        public ActionResult test1(int id,string str)
        {
            return Content("返回一个字符串"+id+str);
            //return Json("返回一个字符串" + id + str);
        }
    }
}