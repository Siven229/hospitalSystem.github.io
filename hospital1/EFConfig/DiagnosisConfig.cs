using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital1.EFconfig
{
    class DiagnosisConfig : EntityTypeConfiguration<Diagnosis>
    {
        public DiagnosisConfig() 
        {
            ToTable("diagnosis");
            Property(e => e.doc_ID).HasMaxLength(10).IsRequired();
            Property(e => e.dia_patient).HasMaxLength(10).IsRequired();
            Property(e => e.visit_ID).IsRequired();
            Property(e => e.med_ID).HasMaxLength(10);
            Property(e => e.result).HasMaxLength(200);
            HasKey(e => e.doc_ID);
            HasKey(e => e.dia_patient);
            HasKey(e => e.visit_ID);
        }
    }
}
