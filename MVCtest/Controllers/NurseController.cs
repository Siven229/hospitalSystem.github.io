using hospital1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class NurseController : Controller
    {
        [HttpGet]
        public ActionResult Display()
        {
            NurseService nurserve = new NurseService();
            var QResult = nurserve.DisplayNurseSalary();
            return Json(QResult, JsonRequestBehavior.AllowGet);
        }

        /*[HttpGet]
        public ActionResult AllSalary()
        {
            NurseService nurserve = new NurseService();
            var salary = new
            {
                totalsalary = nurserve.NurseAllSalary();
            }
            return Json(salary, JsonRequestBehavior.AllowGet);
        }*/
    }
}