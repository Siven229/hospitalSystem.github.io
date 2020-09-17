using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace hospital1.EFconfig
{
    class PatientConfig : EntityTypeConfiguration<Patient>
    {
        public PatientConfig()
        {
            ToTable("patient");
            Property(e => e.patient_ID).HasMaxLength(10).IsRequired();
            Property(e => e.patient_name).HasMaxLength(10).IsRequired();
            Property(e => e.patient_sex).HasMaxLength(2);
            HasKey(e => e.patient_ID);
        }
     
    }
}
