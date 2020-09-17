using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalDTO;

namespace hospital1
{
    public class DoctorService
    {
        public void AddNew(Doctor doctor)
        {
            using (MyContext ctx = new MyContext())
            {
                Doctor doctor1 = new Doctor();
                doctor1 = doctor;
                ctx.Doctors.Add(doctor1);
                ctx.SaveChanges() ;
            }
        }
        public void AddNew(Account doctorAcc,string dept,string pos,float salary,int age,string sex)
        {
            using (MyContext ctx = new MyContext())
            {
                Doctor doctor1 = new Doctor();
                doctor1.doctor_ID = doctorAcc.user_ID;
                doctor1.doctor_name = doctorAcc.name;
                doctor1.doctor_dept = dept;
                doctor1.doctor_position = pos;
                doctor1.salary = salary;
                doctor1.age = age;
                doctor1.sex = sex;
                doctor1.is_arranged = 0;
                ctx.Doctors.Add(doctor1);
                ctx.SaveChanges();
            }
        }
        public void Delete(string userID)
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == userID);
                if (s == null)
                {
                    throw new ArgumentException("所需要删除账号不存在");
                }
                ctx.Doctors.Remove(s);
                ctx.SaveChanges();
            }
        }

        private DoctorDTO ToDTO(Doctor doc)
        {
            DoctorDTO dto = new DoctorDTO();
            dto.doctor_ID = doc.doctor_ID;
            dto.doctor_name = doc.doctor_name;
            dto.doctor_dept = doc.doctor_dept;
            dto.doctor_position = doc.doctor_position;
            dto.salary = doc.salary;
            dto.age = doc.age;
            dto.sex = doc.sex;
            dto.is_arranged = doc.is_arranged;
            return dto;
        }

        public IEnumerable<DoctorDTO> DisplayDoctorSalary()
        {
            using(MyContext ctx = new MyContext())
            {
                List<DoctorDTO> doclist = new List<DoctorDTO>();
                foreach (var doc in ctx.Doctors)
                {
                    doclist.Add(ToDTO(doc));
                }
                return doclist;
            }
        }

        public IEnumerable<DoctorDTO> QueryByID(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var docset = ctx.Doctors.AsNoTracking().Where(e => e.doctor_ID == ID);
                List<DoctorDTO> doclist = new List<DoctorDTO>();
                foreach (var doc in docset)
                {
                    doclist.Add(ToDTO(doc));
                }
                return doclist;
            }
        }

        public float RetrunDoctorTotalSalary()
        {
            using (MyContext ctx = new MyContext())
            {
                float total = 0;
                foreach(var doc in ctx.Doctors)
                {
                    total += doc.salary;
                }
                return total;
            }
        }

    }

}
