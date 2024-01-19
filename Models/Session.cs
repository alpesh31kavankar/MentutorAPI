using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Session
    {
        public int SessionId { get; set; }

        public int MentorSkillId { get; set; }
        public int MentorId { get; set; }
        public int SessionFormatId { get; set; }
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Link { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}