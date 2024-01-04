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
    public class SessionFormatDAL
    {
        DbConnection conn = null;
        public SessionFormatDAL()
        {
            conn = new DbConnection();
        }

        public List<SessionFormat> GetAllSessionFormat()
        {
            List<SessionFormat> sessionFormatList = new List<SessionFormat>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllSessionFormat", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SessionFormat sessionFormat = new SessionFormat();

                sessionFormat.SessionFormatId = Convert.ToInt32(dr["SessionFormatId"]);

                sessionFormat.Title = Convert.ToString(dr["Title"]);
                sessionFormat.Description = Convert.ToString(dr["Description"]);
             
                sessionFormat.Status = Convert.ToString(dr["Status"]);




                sessionFormat.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                sessionFormat.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                sessionFormat.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                sessionFormat.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);



                sessionFormatList.Add(sessionFormat);
            }
            con.Close();
            return sessionFormatList;
        }





        public SessionFormat GetSessionFormatById(int Id)
        {
            SessionFormat sessionFormat = new SessionFormat();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetSessionFormatById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                sessionFormat.SessionFormatId = Convert.ToInt32(dr["SessionFormatId"]);

                sessionFormat.Title = Convert.ToString(dr["Title"]);
                sessionFormat.Description = Convert.ToString(dr["Description"]);
             
                sessionFormat.Status = Convert.ToString(dr["Status"]);




                sessionFormat.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                sessionFormat.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                sessionFormat.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                sessionFormat.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);






            }
            con.Close();
            return sessionFormat;
        }


        public string AddSessionFormat(SessionFormat sessionFormat)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddSessionFormat", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = instructor.Id;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = sessionFormat.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = sessionFormat.Description;
         
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = sessionFormat.Status;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = sessionFormat.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = sessionFormat.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = sessionFormat.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = sessionFormat.UpdatedDate;




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
        public string UpdateSessionFormat(SessionFormat sessionFormat)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateSessionFormat", con);
            cmd.Parameters.Add("SessionFormatId", SqlDbType.Int).Value = sessionFormat.SessionFormatId;

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = sessionFormat.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = sessionFormat.Description;
         
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = sessionFormat.Status;




            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = sessionFormat.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = sessionFormat.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = sessionFormat.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = sessionFormat.UpdatedDate;




            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return sessionFormat.SessionFormatId.ToString();

        }
        public string DeleteSessionFormat(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteSessionFormat", con);
            cmd.Parameters.Add("SessionFormatId", SqlDbType.Int).Value = Id;
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