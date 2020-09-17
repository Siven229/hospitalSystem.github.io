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
        [HttpPost]
        public ActionResult ManagerAdd(string adminID,string adminName,string adminPassword,string type)
        {

            AccountService accountService = new AccountService();
            accountService.AddNew(adminID, adminPassword, adminName, type);
            //返回值待定
            return RedirectToAction("Index");

        }
        //医生账号注册
        [HttpPost]
        public ActionResult DoctorAdd(string username, string name,string password,string type,string dept_name,
            string position,float salary,int age,string gender)
        {
            AccountService accountService = new AccountService();
            DoctorService doctorService = new DoctorService();
            Account account = new Account();
            accountService.AddNew(username, password, name, type);
            account.user_ID = username;
            account.name = name;
            doctorService.AddNew(account, dept_name, position, salary, age, gender);
           //返回值待定
            return RedirectToAction("Index");
        }
        //护士账号注册
        [HttpPost]
        public ActionResult NurseAdd(string nurseID, string nurseName, string nursePassword, string type, string nurseDept_name,
            string nursePosition, float salary,string nurseGender)
        {
            AccountService accountService = new AccountService();
            NurseService nurseService = new NurseService();
            Account account = new Account();
            accountService.AddNew(nurseID, nursePassword, nurseName, type);
            account.user_ID = nurseID;
            account.name = nurseName;
            nurseService.AddNew(account, nurseDept_name, nursePosition, salary, nurseGender);
            //返回值待定
            return RedirectToAction("Index");
        }
        //忘记密码
        public ActionResult changeAccount(string ID,string pass)
        {
            AccountService accountService = new AccountService();
            if (accountService.Update(ID, pass) == true)
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
        public ActionResult Acttendance(string ID)
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

        [HttpPost]
        public ActionResult RegisterAdd(string ID)
        {

            RegisterService registerService = new RegisterService();
            registerService.AddNew(ID);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Delete(string ID)
        {

            AccountService accountService = new AccountService();
            accountService.Delete(ID);
            return RedirectToAction("Index");

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