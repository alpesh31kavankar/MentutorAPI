using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class MentorProfile
    {
        public int MentorProfileId { get; set; }
        public string UserDetailId { get; set; }
        public string TransactionId { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public int Industry { get; set; }
        public string HighestEducation { get; set; }
        public string Resume { get; set; }
        public string AreaOfExpertise { get; set; }
        public string LanguagesSpoken { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}