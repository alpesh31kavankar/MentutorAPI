using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class MentorPlan
    {
        public int MentorPlanId { get; set; }

        public int MentorProfileId { get; set; }

        public int IndividualPlanId { get; set; }

        public string Status { get; set; }



        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}