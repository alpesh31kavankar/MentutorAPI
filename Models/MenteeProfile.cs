using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class MenteeProfile
    {
        public int MenteeProfileId { get; set; }

        public int UserDetailId { get; set; }

        public int TransactionId { get; set; }
        public string PresentDesignation { get; set; }
        public string JobProfile { get; set; }
        public string YearsOfExperience { get; set; }
        public string TargetedDesignation { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}