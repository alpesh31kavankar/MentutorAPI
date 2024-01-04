using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class MentorPlanDAL
    {
        DbConnection conn = null;
        public MentorPlanDAL()
        {
            conn = new DbConnection();
        }


        public List<MentorPlan> GetAllMentorPlan()

        {
            List<MentorPlan> MentorPlanList = new List<MentorPlan>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllMentorPlan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                MentorPlan mentorPlan = new MentorPlan();



                mentorPlan.MentorPlanId = Convert.ToInt32(dr["MentorPlanId"]);
                mentorPlan.MentorProfileId = Convert.ToInt32(dr["MentorProfileId"]);
                mentorPlan.IndividualPlanId = Convert.ToInt32(dr["IndividualPlanId"]);
                mentorPlan.Status = Convert.ToString(dr["Status"]);

                mentorPlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                mentorPlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                mentorPlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                mentorPlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                MentorPlanList.Add(mentorPlan);
            }
            con.Close();
            return MentorPlanList;
        }
        public string AddMentorPlan(MentorPlan mentorPlan)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddMentorPlan", con);
            //cmd.Parameters.Add("MentorPlanId", SqlDbType.Int).Value = mentorPlan.MentorPlanId;
            cmd.Parameters.Add("MentorProfileId", SqlDbType.Int).Value = mentorPlan.MentorProfileId;
            cmd.Parameters.Add("IndividualPlanId", SqlDbType.Int).Value = mentorPlan.IndividualPlanId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = mentorPlan.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = mentorPlan.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = mentorPlan.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = mentorPlan.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = mentorPlan.UpdatedDate;

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
        public string UpdateMentorPlan(MentorPlan mentorPlan)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateMentorPlan", con);

            cmd.Parameters.Add("MentorPlanId", SqlDbType.Int).Value = mentorPlan.MentorPlanId;
            cmd.Parameters.Add("MentorProfileId", SqlDbType.Int).Value = mentorPlan.MentorProfileId;
            cmd.Parameters.Add("IndividualPlanId", SqlDbType.Int).Value = mentorPlan.IndividualPlanId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = mentorPlan.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = mentorPlan.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = mentorPlan.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = mentorPlan.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = mentorPlan.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return mentorPlan.MentorPlanId.ToString();

        }

        public MentorPlan GetMentorPlanById(int MentorPlanId)
        {
            MentorPlan mentorPlan = new MentorPlan();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetMentorPlanById", con);
            cmd.Parameters.Add("MentorPlanId", SqlDbType.Int).Value = MentorPlanId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cmd.Parameters.Add("MentorPlanId", SqlDbType.Int).Value = mentorPlan.MentorPlanId;
                cmd.Parameters.Add("MentorProfileId", SqlDbType.Int).Value = mentorPlan.MentorProfileId;
                cmd.Parameters.Add("IndividualPlanId", SqlDbType.Int).Value = mentorPlan.IndividualPlanId;
                cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = mentorPlan.Status;

                cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = mentorPlan.CreatedBy;
                cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = mentorPlan.CreatedDate;
                cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = mentorPlan.UpdatedBy;
                cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = mentorPlan.UpdatedDate;

            }
            con.Close();
            return mentorPlan;
        }

        public string DeleteMentorPlan(int MentorPlanId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteMentorPlan", con);
            cmd.Parameters.Add("MentorPlanId", SqlDbType.Int).Value = MentorPlanId;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "failed";
            }
            return "success";
        }
    }
}