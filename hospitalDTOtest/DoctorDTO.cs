﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalDTO
{
    public class DoctorDTO
    {
        [Key]
        public string doctor_ID { get; set; }
        public string doctor_name { get; set; }
        public string doctor_dept { get; set; }
        public string doctor_position { get; set; }
        public float salary { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public int is_arranged { get; set; }
    }
}
