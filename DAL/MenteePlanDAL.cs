using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class MenteePlanDAL
    {
        DbConnection conn = null;
        public MenteePlanDAL()
        {
            conn = new DbConnection();
        }


        public List<MenteePlan> GetAllMenteePlan()

        {
            List<MenteePlan> MenteePlanList = new List<MenteePlan>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllMenteePlan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                MenteePlan menteePlan = new MenteePlan();



                menteePlan.MenteePlanId = Convert.ToInt32(dr["MenteePlanId"]);
                menteePlan.MenteeProfileId = Convert.ToInt32(dr["MenteeProfileId"]);
                menteePlan.IndividualPlanId = Convert.ToInt32(dr["IndividualPlanId"]);
                menteePlan.Status = Convert.ToString(dr["Status"]);

                menteePlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                menteePlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                menteePlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                menteePlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                MenteePlanList.Add(menteePlan);
            }
            con.Close();
            return MenteePlanList;
        }
        public string AddMenteePlan(MenteePlan menteePlan)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddMenteePlan", con);
            //cmd.Parameters.Add("MenteePlanId", SqlDbType.Int).Value = menteePlan.MenteePlanId;
            cmd.Parameters.Add("MenteeProfileId", SqlDbType.Int).Value = menteePlan.MenteeProfileId;
            cmd.Parameters.Add("IndividualPlanId", SqlDbType.Int).Value = menteePlan.IndividualPlanId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = menteePlan.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = menteePlan.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = menteePlan.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = menteePlan.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = menteePlan.UpdatedDate;

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
        public string UpdateMenteePlan(MenteePlan menteePlan)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateMenteePlan", con);

            cmd.Parameters.Add("MenteePlanId", SqlDbType.Int).Value = menteePlan.MenteePlanId;
            cmd.Parameters.Add("MenteeProfileId", SqlDbType.Int).Value = menteePlan.MenteeProfileId;
            cmd.Parameters.Add("IndividualPlanId", SqlDbType.Int).Value = menteePlan.IndividualPlanId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = menteePlan.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = menteePlan.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = menteePlan.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = menteePlan.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = menteePlan.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return menteePlan.MenteePlanId.ToString();

        }

        public MenteePlan GetMenteePlanById(int MenteePlanId)
        {
            MenteePlan menteePlan = new MenteePlan();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetMenteePlanById", con);
            cmd.Parameters.Add("MenteePlanId", SqlDbType.Int).Value = MenteePlanId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cmd.Parameters.Add("MenteePlanId", SqlDbType.Int).Value = menteePlan.MenteePlanId;
                cmd.Parameters.Add("MenteeProfileId", SqlDbType.Int).Value = menteePlan.MenteeProfileId;
                cmd.Parameters.Add("IndividualPlanId", SqlDbType.Int).Value = menteePlan.IndividualPlanId;
                cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = menteePlan.Status;

                cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = menteePlan.CreatedBy;
                cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = menteePlan.CreatedDate;
                cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = menteePlan.UpdatedBy;
                cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = menteePlan.UpdatedDate;


            }
            con.Close();
            return menteePlan;
        }

        public string DeleteMenteePlan(int MenteePlanId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteMenteePlan", con);
            cmd.Parameters.Add("MenteePlanId", SqlDbType.Int).Value = MenteePlanId;
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