using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crud_mvc.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string empname { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
    }
}