﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital1.EFConfig
{
    class DoctorConfig: EntityTypeConfiguration<Doctor>
    {
        public DoctorConfig()
        {
            ToTable("doctor");
            HasKey(e =>e.doctor_ID );
            Property(e => e.doctor_ID).HasMaxLength(10).IsRequired();
            Property(e => e.doctor_name).HasMaxLength(10).IsRequired();
            Property(e => e.doctor_dept).HasMaxLength(20).IsRequired();
            Property(e => e.doctor_position).HasMaxLength(10).IsRequired();
            Property(e => e.salary);
            Property(e => e.age);
            Property(e => e.sex).IsRequired();
            Property(e => e.is_arranged);
            //HasRequired(e => e.account).WithOptional().WillCascadeOnDelete();
        }
    }
}
