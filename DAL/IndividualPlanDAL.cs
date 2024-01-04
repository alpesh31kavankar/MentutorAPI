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
    public class IndividualPlanDAL
    {
        DbConnection conn = null;
        public IndividualPlanDAL()
        {
            conn = new DbConnection();
        }

        public List<IndividualPlan> GetAllIndividualPlan()
        {
            List<IndividualPlan> individualPlanList = new List<IndividualPlan>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllIndividualPlan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                IndividualPlan individualPlan = new IndividualPlan();

                individualPlan.IndividualPlanId = Convert.ToInt32(dr["IndividualPlanId"]);

                individualPlan.Title = Convert.ToString(dr["Title"]);
                individualPlan.Description = Convert.ToString(dr["Description"]);
                individualPlan.Price = Convert.ToString(dr["Price"]);
                individualPlan.Status = Convert.ToString(dr["Status"]);
                



                individualPlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                individualPlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                individualPlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                individualPlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                


                individualPlanList.Add(individualPlan);
            }
            con.Close();
            return individualPlanList;
        }





        public IndividualPlan GetIndividualPlanById(int Id)
        {
            IndividualPlan individualPlan = new IndividualPlan();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetIndividualPlanById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                individualPlan.IndividualPlanId = Convert.ToInt32(dr["IndividualPlanId"]);

                individualPlan.Title = Convert.ToString(dr["Title"]);
                individualPlan.Description = Convert.ToString(dr["Description"]);
                individualPlan.Price = Convert.ToString(dr["Price"]);
                individualPlan.Status = Convert.ToString(dr["Status"]);
                



                individualPlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                individualPlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                individualPlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                individualPlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
                





            }
            con.Close();
            return individualPlan;
        }


        public string AddIndividualPlan(IndividualPlan individualPlan)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddIndividualPlan", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = instructor.Id;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = individualPlan.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = individualPlan.Description;
            cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = individualPlan.Price;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = individualPlan.Status;
           


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = individualPlan.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = individualPlan.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = individualPlan.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = individualPlan.UpdatedDate;
            



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
        public string UpdateIndividualPlan(IndividualPlan individualPlan)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateIndividualPlan", con);
            cmd.Parameters.Add("IndividualPlanId", SqlDbType.Int).Value = individualPlan.IndividualPlanId;

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = individualPlan.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = individualPlan.Description;
            cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = individualPlan.Price;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = individualPlan.Status;
           



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = individualPlan.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = individualPlan.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = individualPlan.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = individualPlan.UpdatedDate;
          



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return individualPlan.IndividualPlanId.ToString();

        }
        public string DeleteIndividualPlan(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteIndividualPlan", con);
            cmd.Parameters.Add("IndividualPlanId", SqlDbType.Int).Value = Id;
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