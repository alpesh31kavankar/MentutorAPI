using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string Photo { get; set; }

    }
}