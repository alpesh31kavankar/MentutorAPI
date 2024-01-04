using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;
using PrismAPI.DAL;
using System.Data.Common;

namespace PrismAPI.DAL
{
    public class MentorProfileDAL
    {
        DbConnection conn = null;
        public MentorProfileDAL()
        {
            conn = new DbConnection();
        }

        public List<MentorProfile> GetAllMentorProfile()
        {
            List<MentorProfile> mentorProfileList = new List<MentorProfile>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllMentorProfile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                MentorProfile mentorProfile = new MentorProfile();

                mentorProfile.MentorProfileId = Convert.ToInt32(dr["MentorProfileId"]);

                mentorProfile.UserDetailId = Convert.ToString(dr["UserDetailId"]);
                mentorProfile.TransactionId = Convert.ToString(dr["TransactionId"]);
                mentorProfile.Address = Convert.ToString(dr["Address"]);
                mentorProfile.JobTitle = Convert.ToString(dr["JobTitle"]);
                mentorProfile.Company = Convert.ToString(dr["Company"]);
                mentorProfile.Industry = Convert.ToInt32(dr["Industry"]);
                mentorProfile.HighestEducation = Convert.ToString(dr["HighestEducation"]);
                mentorProfile.Resume = Convert.ToString(dr["Resume"]);
                mentorProfile.AreaOfExpertise = Convert.ToString(dr["AreaOfExpertise"]);
                mentorProfile.LanguagesSpoken = Convert.ToString(dr["LanguagesSpoken"]);




                mentorProfile.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                mentorProfile.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                mentorProfile.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                mentorProfile.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);



                mentorProfileList.Add(mentorProfile);
            }
            con.Close();
            return mentorProfileList;
        }





        public MentorProfile GetMentorProfileById(int Id)
        {
            MentorProfile mentorProfile = new MentorProfile();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetMentorProfileById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                mentorProfile.MentorProfileId = Convert.ToInt32(dr["MentorProfileId"]);

                mentorProfile.UserDetailId = Convert.ToString(dr["UserDetailId"]);
                mentorProfile.TransactionId = Convert.ToString(dr["TransactionId"]);
                mentorProfile.Address = Convert.ToString(dr["Address"]);
                mentorProfile.JobTitle = Convert.ToString(dr["JobTitle"]);
                mentorProfile.Company = Convert.ToString(dr["Company"]);
                mentorProfile.Industry = Convert.ToInt32(dr["Industry"]);
                mentorProfile.HighestEducation = Convert.ToString(dr["HighestEducation"]);
                mentorProfile.Resume = Convert.ToString(dr["Resume"]);
                mentorProfile.AreaOfExpertise = Convert.ToString(dr["AreaOfExpertise"]);
                mentorProfile.LanguagesSpoken = Convert.ToString(dr["LanguagesSpoken"]);



                mentorProfile.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                mentorProfile.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                mentorProfile.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                mentorProfile.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
              





            }
            con.Close();
            return mentorProfile;
        }


        public string AddMentorProfile(MentorProfile mentorProfile)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddMentorProfile", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = instructor.Id;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = mentorProfile.Address;
            cmd.Parameters.Add("JobTitle", SqlDbType.NVarChar).Value = mentorProfile.JobTitle;
            cmd.Parameters.Add("Company", SqlDbType.NVarChar).Value = mentorProfile.Company;
            cmd.Parameters.Add("Industry", SqlDbType.NVarChar).Value = mentorProfile.Industry;
            cmd.Parameters.Add("HighestEducation", SqlDbType.NVarChar).Value = mentorProfile.HighestEducation;
            cmd.Parameters.Add("Resume", SqlDbType.NVarChar).Value = mentorProfile.Resume;
            cmd.Parameters.Add("AreaOfExpertise", SqlDbType.NVarChar).Value = mentorProfile.AreaOfExpertise;
            cmd.Parameters.Add("LanguagesSpoken", SqlDbType.NVarChar).Value = mentorProfile.LanguagesSpoken;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = mentorProfile.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = mentorProfile.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = mentorProfile.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = mentorProfile.UpdatedDate;
         



            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return Id.ToString();

        }

        [HttpPost]
        public string UpdateStudent(MentorProfile mentorProfile)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateStudent", con);
            cmd.Parameters.Add("MentorProfileId", SqlDbType.Int).Value = mentorProfile.MentorProfileId;

            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = mentorProfile.Address;
            cmd.Parameters.Add("JobTitle", SqlDbType.NVarChar).Value = mentorProfile.JobTitle;
            cmd.Parameters.Add("Company", SqlDbType.NVarChar).Value = mentorProfile.Company;
            cmd.Parameters.Add("Industry", SqlDbType.NVarChar).Value = mentorProfile.Industry;
            cmd.Parameters.Add("HighestEducation", SqlDbType.NVarChar).Value = mentorProfile.HighestEducation;
            cmd.Parameters.Add("Resume", SqlDbType.NVarChar).Value = mentorProfile.Resume;
            cmd.Parameters.Add("AreaOfExpertise", SqlDbType.NVarChar).Value = mentorProfile.AreaOfExpertise;
            cmd.Parameters.Add("LanguagesSpoken", SqlDbType.NVarChar).Value = mentorProfile.LanguagesSpoken;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = mentorProfile.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = mentorProfile.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = mentorProfile.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = mentorProfile.UpdatedDate;
         



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return mentorProfile.MentorProfileId.ToString();

        }
        public string DeleteMentorProfile(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteMentorProfile", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
        }

        internal string UpdateMentorProfile(MentorProfile mentorProfile)
        {
            throw new NotImplementedException();
        }
    }
}