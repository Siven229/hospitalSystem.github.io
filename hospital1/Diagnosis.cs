using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital1
{
    public class Diagnosis
    {
        [ForeignKey("Doctor")]
        public string doc_ID { get; set; }
        [ForeignKey("Patient")]
        public string dia_patient { get; set; }
        public string visit_ID { get; set; }
        [ForeignKey("Medicine")]
        public string med_ID { get; set; }
        public int med_Num { get; set; }
        public System.DateTime date { get; set; }
        public string result { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Medicine Medicine { get; set; }
    }
}
