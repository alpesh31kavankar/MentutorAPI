using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class MenteeProfile
    {
        public int MenteeProfileId { get; set; }

        public int RegistrationId { get; set; }
        
        public string JobTitle { get; set; }
        public string Industry { get; set; }
       
        public string YearsOfExperience { get; set; }
        public string TargetedDesignation { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}