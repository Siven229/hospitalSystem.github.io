using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace hospital1
{
    public class MyContext:DbContext
    {
        public MyContext():base("name=connStr")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(
                 Assembly.GetExecutingAssembly()
                );
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Bill> Bills { get; set; }
    }
}
