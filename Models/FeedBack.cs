using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class FeedBack
    {
        public int FeedBackId { get; set; }
        public int SessionId { get; set; }
        public int MenteeId { get; set; }


        public string Rating { get; set; }

        public string Message { get; set; }

        public string MentorStatus { get; set; }
        public string Status { get; set; }


        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}