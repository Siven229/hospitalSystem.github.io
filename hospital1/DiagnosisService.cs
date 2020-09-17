using hospital1DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital1
{
    public class DiagnosisService
    {
        public void AddNew(string doc_ID, string dia_patient, string visit_ID, string med_ID, int med_Num, string result)
        {
            using(MyContext ctx = new MyContext())
            {
                Diagnosis diag = new Diagnosis();
                diag.doc_ID = doc_ID;
                diag.dia_patient = dia_patient;
                diag.visit_ID = visit_ID;
                diag.med_ID = med_ID;
                diag.med_Num = med_Num;
                diag.date = DateTime.Now;
                diag.result = result;
                ctx.Diagnoses.Add(diag);
                ctx.SaveChanges();
            }
        }

        private DiagnosisDTO ToDTO(Diagnosis diag)
        {
            DiagnosisDTO dto = new DiagnosisDTO();
            dto.doc_ID = diag.doc_ID;
            dto.dia_patient = diag.dia_patient;
            dto.visit_ID = diag.visit_ID;
            dto.med_ID = diag.med_ID;
            dto.med_Num = diag.med_Num;
            dto.date = diag.date;
            dto.result = diag.result;

            /*dto.doc_name = diag.Doctor.doctor_name;
            dto.pat_name = diag.Patient.patient_name;
            dto.med_name = diag.Medicine.med_ID;*/
            return dto;
        }

        public IEnumerable<DiagnosisDTO> QueryAll()
        {
            using (MyContext ctx = new MyContext())
            {
                List<DiagnosisDTO> diaglist = new List<DiagnosisDTO>();
                foreach (var diag in ctx.Diagnoses)
                {
                    diaglist.Add(ToDTO(diag));
                }
                return diaglist;
            }
        }

        public IEnumerable<DiagnosisDTO> QueryByPatientID(string PatientID)
        {
            using (MyContext ctx = new MyContext())
            {
                var diagset = ctx.Diagnoses.AsNoTracking().Where(e => e.dia_patient == PatientID);
                List<DiagnosisDTO> diaglist = new List<DiagnosisDTO>();
                foreach (var diag in diagset)
                {
                    diaglist.Add(ToDTO(diag));
                }
                return diaglist;
            }
        }

        public void DeleteOld(string doc_ID, string dia_patient, string visit_ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var diag = ctx.Diagnoses.SingleOrDefault(s => s.doc_ID == doc_ID && s.dia_patient == dia_patient && s.visit_ID == visit_ID);
                if (diag == null)
                {
                    throw new ArgumentException("未找到该诊断");
                }
                else
                {
                    ctx.Diagnoses.Remove(diag);
                }
                ctx.SaveChanges();
            }
        }

    }
}
