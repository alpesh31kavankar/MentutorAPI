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
    public class SessionDAL
    {
        DbConnection conn = null;
        public SessionDAL()
        {
            conn = new DbConnection();
        }

        public List<Session> GetAllSession()
        {
            List<Session> sessionList = new List<Session>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllSession", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Session session = new Session();

                session.SessionId = Convert.ToInt32(dr["SessionId"]);

                session.MentorSkillId = Convert.ToInt32(dr["MentorSkillId"]);
                session.MentorId = Convert.ToInt32(dr["MentorId"]);
                session.SessionFormatId = Convert.ToInt32(dr["SessionFormatId"]);
                session.Title = Convert.ToString(dr["Title"]);
                session.SubTitle = Convert.ToString(dr["SubTitle"]);
                session.Description = Convert.ToString(dr["Description"]);
                session.Date = Convert.ToString(dr["Date"]);
                session.StartTime = Convert.ToString(dr["StartTime"]);
                session.EndTime = Convert.ToString(dr["EndTime"]);
                session.Link = Convert.ToString(dr["Link"]);
                session.Status = Convert.ToString(dr["Status"]);



                session.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                session.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                session.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                session.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);



                sessionList.Add(session);
            }
            con.Close();
            return sessionList;
        }





        public Session GetSessionById(int Id)
        {
            Session session = new Session();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetSessionById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                session.SessionId = Convert.ToInt32(dr["SessionId"]);

                session.MentorSkillId = Convert.ToInt32(dr["MentorSkillId"]);
                session.MentorId = Convert.ToInt32(dr["MentorId"]);
                session.SessionFormatId = Convert.ToInt32(dr["SessionFormatId"]);
                session.Title = Convert.ToString(dr["Title"]);
                session.SubTitle = Convert.ToString(dr["SubTitle"]);
                session.Description = Convert.ToString(dr["Description"]);
                session.Date = Convert.ToString(dr["Date"]);
                session.StartTime = Convert.ToString(dr["StartTime"]);
                session.EndTime = Convert.ToString(dr["EndTime"]);
                session.Link = Convert.ToString(dr["Link"]);
                session.Status = Convert.ToString(dr["Status"]);



                session.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                session.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                session.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                session.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);






            }
            con.Close();
            return session;
        }


        public string AddSession(Session session)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddSession", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = instructor.Id;
            cmd.Parameters.Add("MentorSkillId", SqlDbType.NVarChar).Value = session.MentorSkillId;
            cmd.Parameters.Add("MentorId", SqlDbType.NVarChar).Value = session.MentorId;
            cmd.Parameters.Add("SessionFormatId", SqlDbType.NVarChar).Value = session.SessionFormatId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = session.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = session.SubTitle;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = session.Description;
            cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = session.Date;
            cmd.Parameters.Add("StartTime", SqlDbType.NVarChar).Value = session.StartTime;
            cmd.Parameters.Add("EndTime", SqlDbType.NVarChar).Value = session.EndTime;
            cmd.Parameters.Add("Link", SqlDbType.NVarChar).Value = session.Link;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = session.Status;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = session.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = session.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = session.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = session.UpdatedDate;




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
        public string UpdateSession(Session session)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateSession", con);
            cmd.Parameters.Add("SessionId", SqlDbType.Int).Value = session.SessionId;
            cmd.Parameters.Add("MentorSkillId", SqlDbType.Int).Value = session.MentorSkillId;
            cmd.Parameters.Add("MentorId", SqlDbType.Int).Value = session.MentorId;
            cmd.Parameters.Add("SessionFormatId", SqlDbType.Int).Value = session.SessionFormatId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = session.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = session.SubTitle;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = session.Description;
            cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = session.Date;
            cmd.Parameters.Add("StartTime", SqlDbType.NVarChar).Value = session.StartTime;
            cmd.Parameters.Add("EndTime", SqlDbType.NVarChar).Value = session.EndTime;
            cmd.Parameters.Add("Link", SqlDbType.NVarChar).Value = session.Link;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = session.Status;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = session.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = session.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = session.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = session.UpdatedDate;




            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return session.SessionId.ToString();

        }
        public string DeleteSession(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteSession", con);
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
    }
}