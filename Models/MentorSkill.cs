using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class MentorSkill
    {
        public int MentorSkillId { get; set; }
        public int MentorProfileId { get; set; }
        public int SkillId { get; set; }
        public string Certificate { get; set; }
        public string Status { get; set; }


        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}