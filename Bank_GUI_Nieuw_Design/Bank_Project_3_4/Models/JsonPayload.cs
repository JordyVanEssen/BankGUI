using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project_3_4.Models
{
    class JsonPayload
    {
        public String revBank { get; set; }
        public String senBank { get; set; }
        public String Func { get; set; }
        public String IBAN { get; set; }
        public String PIN { get; set; }
        public double Amount { get; set; }
    }
}
