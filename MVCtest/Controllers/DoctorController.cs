using hospital1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class DoctorController : Controller
    {
        [HttpGet]
        public ActionResult Display()
        {
            DoctorService docserve = new DoctorService();
            var QResult = docserve.DisplayDoctorSalary();
            return Json(QResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Query(string doctor_ID)
        {
            DoctorService docserve = new DoctorService();
            var QResult = docserve.QueryByID(doctor_ID);
            return Json(QResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RtSalary()
        {
            List<float> salalist = new List<float>();
            DoctorService docserve = new DoctorService();
            NurseService nurserve = new NurseService();
            float total1 = docserve.RetrunDoctorTotalSalary();
            float total2 = nurserve.ReturnNurseTotalSalary();
            salalist.Add(total1+total2);
            return Json(salalist);
        }

    }
}