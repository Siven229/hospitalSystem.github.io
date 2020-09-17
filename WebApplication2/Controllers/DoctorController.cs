using hospitalServiceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            using (MyContext ctx = new MyContext())
            {
                DoctorService d = new DoctorService();
                var res = d.GetAllDoctor();
                return View(res);
            }
        }

        public ActionResult GetAll()
        {
            DoctorService d = new DoctorService();
            var res = d.GetAllDoctor();
            return Json(res);
        }

        public ActionResult SearchID(string doctor_ID)
        {
            DoctorService d = new DoctorService();
            var res = d.GetDoctorByID(doctor_ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchIDe(string doctor_ID)
        {
            DoctorService d = new DoctorService();
            var res = d.GetDoctorByIDe(doctor_ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchName(string doctor_ID)
        {
            var a = doctor_ID;
            DoctorService d = new DoctorService();
            var res = d.GetDoctorByName(doctor_ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddNew(string doctor_ID, string doctor_name, string doctor_dept,
            string doctor_position, float salary, int age, string sex, int is_arranged)
        {
            DoctorService d = new DoctorService();
            var res = d.AddNewDoctor(doctor_ID, doctor_name, doctor_dept, doctor_position, salary, age, sex, is_arranged);
            return Json(res);
        }

        public ActionResult Delete(string doctor_ID)
        {
            DoctorService d = new DoctorService();
            d.DeleteDoctorByID(doctor_ID);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Change(string predoctor_ID,string doctor_ID, string doctor_name, string doctor_dept,
            string doctor_position, float salary, int age, string sex, int is_arranged)
        {
            DoctorService d = new DoctorService();
            var res = d.ChangeDoctorByID(predoctor_ID, doctor_ID, doctor_name,doctor_dept, doctor_position, salary, age, sex, is_arranged);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}