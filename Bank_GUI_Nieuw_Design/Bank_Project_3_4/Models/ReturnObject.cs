using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Project_3_4.ViewModels;

namespace Bank_Project_3_4
{
    class ReturnObject
    {
        public int StatusCode { get; set; }
        public String pErrorDiscription { get; set; }
        public bool StatusOK { get; internal set; }
        public UserTagViewModel ReturnUserTag { get; set; }
    }
}
