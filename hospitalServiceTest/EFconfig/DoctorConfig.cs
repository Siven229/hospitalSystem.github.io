using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospitalServiceTest.EFconfig
{
    class DoctorConfig:EntityTypeConfiguration<Doctor>
    {
        public DoctorConfig()
        {
            ToTable("doctor");
            Property(e => e.doctor_ID).HasMaxLength(100).IsRequired();
            Property(e => e.doctor_name).HasMaxLength(100).IsRequired();
            Property(e => e.doctor_position).HasMaxLength(100).IsRequired();
            Property(e => e.doctor_dept).HasMaxLength(100).IsRequired();
            Property(e => e.age).IsRequired();
            Property(e => e.is_arranged).IsRequired();
            Property(e => e.salary).IsRequired();
            Property(e => e.sex).HasMaxLength(100).IsRequired();
        }
    }
}
