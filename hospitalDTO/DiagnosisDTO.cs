using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital1DTO
{
    public class DiagnosisDTO
    {
        public string doc_ID { get; set; }      
        public string dia_patient { get; set; }      
        public string visit_ID { get; set; }      
        public string med_ID { get; set; }
        public int med_Num { get; set; }
        public System.DateTime date { get; set; }
        public string result { get; set; }

        public string doc_name { get; set; }
        public string pat_name { get; set; }
        public string med_name { get; set; }
    }
}
