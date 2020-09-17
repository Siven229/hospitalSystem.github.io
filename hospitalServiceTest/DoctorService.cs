using hospitalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
{
    public class DoctorService
    {
        public string AddNewDoctor(string doctor_ID, string doctor_name, string doctor_dept, 
            string doctor_position, float salary, int age, string sex, int is_arranged)
        {
            using (MyContext ctx = new MyContext())
            {
                var f = ctx.Departments.SingleOrDefault(e => e.dept_name == doctor_dept);
                if (f == null)
                {
                    return "NO";
                }
                Doctor s = new Doctor();
                s.doctor_ID = doctor_ID;
                s.doctor_name = doctor_name;
                s.doctor_dept = doctor_dept;
                s.doctor_position = doctor_position;
                s.salary = salary;
                s.sex = sex;
                s.age = age;
                s.is_arranged = is_arranged;
                ctx.Doctors.Add(s);
                ctx.SaveChanges();
            }
            return "YES";
        }
        public void DeleteDoctorByID(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var doc = ctx.Doctors.SingleOrDefault(s=>s.doctor_ID == ID);
                if (doc == null)
                {
                    throw new ArgumentException("抱歉！并为找到ID为" + ID + "的医生！");
                }
                ctx.Doctors.Remove(doc);
                ctx.SaveChanges();
            }
        }

        public string ChangeDoctorByID(string p_ID,string doctor_ID, string doctor_name, string doctor_dept,
            string doctor_position, float salary, int age, string sex, int is_arranged)//按ID查找后进行修改
        {
            using (MyContext ctx = new MyContext())
            {
                var f = ctx.Departments.SingleOrDefault(e => e.dept_name == doctor_dept);
                if (f == null)
                {
                    return "NO";
                }
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == p_ID);
                
                s.doctor_ID = doctor_ID;
                s.doctor_name = doctor_name;
                s.doctor_dept = doctor_dept;
                s.doctor_position = doctor_position;
                s.salary = salary;
                s.sex = sex;
                s.age = age;
                s.is_arranged = is_arranged;
                
                ctx.SaveChanges();
            }
            return "YES";
        }

        public IEnumerable<DoctorDTO> GetDoctorByID(string ID)//按ID查找
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == ID);
                if(s == null)
                {
                    return null;
                }
                List<DoctorDTO> list = new List<DoctorDTO>();
                DoctorDTO dto = new DoctorDTO();
                dto.doctor_ID = s.doctor_ID;
                dto.doctor_name = s.doctor_name;
                dto.doctor_dept = s.doctor_dept;
                dto.doctor_position = s.doctor_position;
                dto.salary = s.salary;
                dto.sex = s.sex;
                dto.age = s.age;
                dto.is_arranged = s.is_arranged;
                list.Add(dto);
                return list;
            }
        }

        public DoctorDTO GetDoctorByIDe(string ID)//按ID查找
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Doctors.SingleOrDefault(e => e.doctor_ID == ID);
                if (s == null)
                {
                    return null;
                }
                DoctorDTO dto = new DoctorDTO();
                dto.doctor_ID = s.doctor_ID;
                dto.doctor_name = s.doctor_name;
                dto.doctor_dept = s.doctor_dept;
                dto.doctor_position = s.doctor_position;
                dto.salary = s.salary;
                dto.sex = s.sex;
                dto.age = s.age;
                dto.is_arranged = s.is_arranged;
                return dto;
            }
        }


        public IEnumerable<DoctorDTO> GetDoctorByName(string doctor_name)//按名查找
        {
            using (MyContext ctx = new MyContext())
            {
                var docs = ctx.Doctors.Where(e => e.doctor_name == doctor_name);
                if (docs == null)
                {
                    return null;
                }
                List<DoctorDTO> list = new List<DoctorDTO>();
                foreach (var s in docs)
                {
                    DoctorDTO dto = new DoctorDTO();
                    dto.doctor_ID = s.doctor_ID;
                    dto.doctor_name = s.doctor_name;
                    dto.doctor_dept = s.doctor_dept;
                    dto.doctor_position = s.doctor_position;
                    dto.salary = s.salary;
                    dto.sex = s.sex;
                    dto.age = s.age;
                    dto.is_arranged = s.is_arranged;
                    list.Add(dto);
                }
                return list;
            }
        }
        public IEnumerable<DoctorDTO> GetAllDoctor()//按名查找
        {
            using (MyContext ctx = new MyContext())
            {
                var docs = ctx.Doctors;
                if (docs == null)
                {
                    return null;
                }
                List<DoctorDTO> list = new List<DoctorDTO>();
                foreach (var s in docs)
                {
                    DoctorDTO dto = new DoctorDTO();
                    dto.doctor_ID = s.doctor_ID;
                    dto.doctor_name = s.doctor_name;
                    dto.doctor_dept = s.doctor_dept;
                    dto.doctor_position = s.doctor_position;
                    dto.salary = s.salary;
                    dto.sex = s.sex;
                    dto.age = s.age;
                    dto.is_arranged = s.is_arranged;
                    list.Add(dto);
                }
                return list;
            }
        }
    }
}
