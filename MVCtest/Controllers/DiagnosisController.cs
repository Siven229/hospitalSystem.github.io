using hospital1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtest.Controllers
{
    public class DiagnosisController : Controller
    {
        // GET: Diagnosis
        public ActionResult Index()
        {
            DiagnosisService diagserve = new DiagnosisService();
            var diaglist = diagserve.QueryAll();
            return View(diaglist);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string doc_ID, string dia_patient, string visit_ID, string med_ID, int med_Num, string result)
        {
            DiagnosisService diagserve = new DiagnosisService();
            diagserve.AddNew(doc_ID, dia_patient, visit_ID, med_ID, med_Num, result);
            return Json("true");
        }

    }
}