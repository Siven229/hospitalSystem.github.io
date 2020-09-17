﻿using hospitalDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalServiceTest
{
    public class NurseService
    {
        public string AddNewNurse(string nurse_ID, string nurse_name, string nurse_dept, 
            string position, string sex, int salary)
        {
            using (MyContext ctx = new MyContext())
            {
                var f = ctx.Departments.SingleOrDefault(e => e.dept_name == nurse_dept);
                if (f == null)
                {
                    return "NO";
                }
                Nurse s = new Nurse();
                s.nurse_ID = nurse_ID;
                s.nurse_name = nurse_name;
                s.nurse_dept = nurse_dept;
                s.position = position;
                s.sex = sex;
                s.salary = salary;
                ctx.Nurses.Add(s);
                ctx.SaveChanges();
            }
            return "YES";
        }
        public void DeleteNurseByID(string ID)
        {
            using (MyContext ctx = new MyContext())
            {
                var nrs = ctx.Nurses.SingleOrDefault(s=>s.nurse_ID == ID);
                if (nrs == null)
                {
                    throw new ArgumentException("抱歉！并为找到ID为" + ID + "的护士！");
                }
                ctx.Nurses.Remove(nrs);
                ctx.SaveChanges();
            }
        }

        public string ChangeNurseByID(string p_ID,string nurse_ID, string nurse_name, string nurse_dept,
            string position, string sex, int salary)//按ID查找后进行修改
        {
            using (MyContext ctx = new MyContext())
            {
                var f = ctx.Departments.SingleOrDefault(e => e.dept_name == nurse_dept);
                if (f == null)
                {
                    return "NO";
                }
                var s = ctx.Nurses.SingleOrDefault(e => e.nurse_ID == p_ID);
                s.nurse_ID = nurse_ID;
                s.nurse_name = nurse_name;
                s.nurse_dept = nurse_dept;
                s.position = position;
                s.sex = sex;
                s.salary = salary;
                ctx.SaveChanges();
            }
            return "YES";
        }


        public IEnumerable<NurseDTO> GetNurseByID(string ID)//按ID查找
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Nurses.SingleOrDefault(e => e.nurse_ID == ID);
                if(s == null)
                {
                    return null;
                }
                List<NurseDTO> list = new List<NurseDTO>();
                NurseDTO dto = new NurseDTO();
                dto.nurse_ID = s.nurse_ID;
                dto.nurse_name = s.nurse_name;
                dto.nurse_dept = s.nurse_dept;
                dto.position = s.position;
                dto.salary = s.salary;
                dto.sex = s.sex;
                list.Add(dto);
                return list;
            }
        }

        public NurseDTO GetNurseByIDe(string ID)//按ID查找
        {
            using (MyContext ctx = new MyContext())
            {
                var s = ctx.Nurses.SingleOrDefault(e => e.nurse_ID == ID);
                if (s == null)
                {
                    return null;
                }
                NurseDTO dto = new NurseDTO();
                dto.nurse_ID = s.nurse_ID;
                dto.nurse_name = s.nurse_name;
                dto.nurse_dept = s.nurse_dept;
                dto.position = s.position;
                dto.salary = s.salary;
                dto.sex = s.sex;
                return dto;
            }
        }

        public IEnumerable<NurseDTO> GetNurseByName(string Name)//按名查找
        {
            using (MyContext ctx = new MyContext())
            {
                var docs = ctx.Nurses.Where(e => e.nurse_name == Name);
                if (docs == null)
                {
                    return null;
                }
                List<NurseDTO> list = new List<NurseDTO>();
                foreach (var s in docs)
                {
                    NurseDTO dto = new NurseDTO();
                    dto.nurse_ID = s.nurse_ID;
                    dto.nurse_name = s.nurse_name;
                    dto.nurse_dept = s.nurse_dept;
                    dto.position = s.position;
                    dto.salary = s.salary;
                    dto.sex = s.sex;
                    list.Add(dto);
                }
                return list;
            }
        }
        public IEnumerable<NurseDTO> GetAllNurse()//按名查找
        {
            using (MyContext ctx = new MyContext())
            {
                var docs = ctx.Nurses;
                if (docs == null)
                {
                    return null;
                }
                List<NurseDTO> list = new List<NurseDTO>();
                foreach (var s in docs)
                {
                    NurseDTO dto = new NurseDTO();
                    dto.nurse_ID = s.nurse_ID;
                    dto.nurse_name = s.nurse_name;
                    dto.nurse_dept = s.nurse_dept;
                    dto.position = s.position;
                    dto.salary = s.salary;
                    dto.sex = s.sex;
                    list.Add(dto);
                }
                return list;
            }
        }
    }
}
