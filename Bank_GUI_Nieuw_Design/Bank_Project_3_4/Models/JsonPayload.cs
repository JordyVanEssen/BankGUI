﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Project_3_4.Models
{
    class Message
    {
        public String IDRecBank { get; set; }
        public String IDSenBank { get; set; }
        public String Func { get; set; }
        public String IBAN { get; set; }
        public String PIN { get; set; }
    }
}