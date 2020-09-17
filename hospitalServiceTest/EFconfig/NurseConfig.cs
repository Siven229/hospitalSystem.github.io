using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospitalServiceTest.EFconfig
{
    class NurseConfig:EntityTypeConfiguration<Nurse>
    {
        public NurseConfig()
        {
            ToTable("nurse");
            Property(e => e.nurse_ID).HasMaxLength(100).IsRequired();
            Property(e => e.nurse_name).HasMaxLength(100).IsRequired();
            Property(e => e.position).HasMaxLength(100).IsRequired();
            Property(e => e.nurse_dept).HasMaxLength(100).IsRequired();
            Property(e => e.sex).IsRequired();
            Property(e => e.salary).IsRequired();
        }
    }
}
