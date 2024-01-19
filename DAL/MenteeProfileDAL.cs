using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class MenteeProfileDAL
    {
        DbConnection conn = null;
        public MenteeProfileDAL()
        {
            conn = new DbConnection();
        }

        public List<MenteeProfile> GetAllMenteeProfile()
        {
            List<MenteeProfile> MenteeProfileList = new List<MenteeProfile>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllMenteeProfile", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                MenteeProfile menteeProfile = new MenteeProfile();

                menteeProfile.MenteeProfileId = Convert.ToInt32(dr["MenteeProfileId"]);
                menteeProfile.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
           
                menteeProfile.JobTitle = Convert.ToString(dr["JobTitle"]);
                menteeProfile.Industry = Convert.ToString(dr["Industry"]);
                menteeProfile.YearsOfExperience = Convert.ToString(dr["YearsOfExperience"]);
                menteeProfile.TargetedDesignation = Convert.ToString(dr["TargetedDesignation"]);
                menteeProfile.Status = Convert.ToString(dr["Status"]);

                menteeProfile.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                menteeProfile.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                menteeProfile.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                menteeProfile.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                MenteeProfileList.Add(menteeProfile);
            }
            con.Close();
            return MenteeProfileList;
        }






        public MenteeProfile GetMenteeProfileById(int Id)
        {
            MenteeProfile menteeProfile = new MenteeProfile();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetMenteeProfileById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                menteeProfile.MenteeProfileId = Convert.ToInt32(dr["MenteeProfileId"]);
                menteeProfile.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                menteeProfile.JobTitle = Convert.ToString(dr["JobTitle"]);
                menteeProfile.Industry = Convert.ToString(dr["Industry"]);
                menteeProfile.YearsOfExperience = Convert.ToString(dr["YearsOfExperience"]);
                menteeProfile.TargetedDesignation = Convert.ToString(dr["TargetedDesignation"]);
                menteeProfile.Status = Convert.ToString(dr["Status"]);

                menteeProfile.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                menteeProfile.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                menteeProfile.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                menteeProfile.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return menteeProfile;
        }


        public string AddMenteeProfile(MenteeProfile menteeProfile)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddMenteeProfile", con);
            //cmd.Parameters.Add("MenteeProfileId", SqlDbType.Int).Value = menteeProfile.MenteeProfileId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = menteeProfile.RegistrationId;       
            cmd.Parameters.Add("JobTitle", SqlDbType.NVarChar).Value = menteeProfile.JobTitle;
            cmd.Parameters.Add("Industry", SqlDbType.NVarChar).Value = menteeProfile.Industry;
            cmd.Parameters.Add("YearsOfExperience", SqlDbType.NVarChar).Value = menteeProfile.YearsOfExperience;
            cmd.Parameters.Add("TargetedDesignation", SqlDbType.NVarChar).Value = menteeProfile.TargetedDesignation;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = menteeProfile.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = menteeProfile.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = menteeProfile.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = menteeProfile.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = menteeProfile.UpdatedDate;


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
        public string UpdateMenteeProfile(MenteeProfile menteeProfile)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateMenteeProfile", con);
            cmd.Parameters.Add("MenteeProfileId", SqlDbType.Int).Value = menteeProfile.MenteeProfileId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = menteeProfile.RegistrationId;
            cmd.Parameters.Add("JobTitle", SqlDbType.NVarChar).Value = menteeProfile.JobTitle;
            cmd.Parameters.Add("Industry", SqlDbType.NVarChar).Value = menteeProfile.Industry;
            cmd.Parameters.Add("YearsOfExperience", SqlDbType.NVarChar).Value = menteeProfile.YearsOfExperience;
            cmd.Parameters.Add("TargetedDesignation", SqlDbType.NVarChar).Value = menteeProfile.TargetedDesignation;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = menteeProfile.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = menteeProfile.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = menteeProfile.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = menteeProfile.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = menteeProfile.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return menteeProfile.MenteeProfileId.ToString();

        }


        //public string UpdateFirstModel(FirstModel firstModel)
        //{
        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("UpdateFirstModel", con);
        //    cmd.Parameters.Add("Id", SqlDbType.Int).Value = firstModel.Id;
        //    cmd.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = firstModel.FirstName;
        //    cmd.Parameters.Add("LastName", SqlDbType.NVarChar).Value = firstModel.LastName;
        //    cmd.Parameters.Add("DOB", SqlDbType.NVarChar).Value = firstModel.DOB;





        //    //cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = firstModel.CreatedBy;
        //    //cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = firstModel.CreatedDate;
        //    //cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = firstModel.UpdatedBy;
        //    //cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = firstModel.UpdatedDate;

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    object result = cmd.ExecuteScalar();

        //    con.Close();
        //    if (result.ToString() == "0")
        //    {
        //        return "Failed";
        //    }
        //    return "Success";
        //}


        public string DeleteMenteeProfile(int MenteeProfileId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteMenteeProfile", con);
            cmd.Parameters.Add("MenteeProfileId", SqlDbType.Int).Value = MenteeProfileId;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
        }
    }
}