using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class FeedBackDAL
    {
        DbConnection conn = null;
        public FeedBackDAL()
        {
            conn = new DbConnection();
        }

        public List<FeedBack> GetAllFeedBack()
        {
            List<FeedBack> FeedBackList = new List<FeedBack>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllFeedBack", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FeedBack feedBack = new FeedBack();

                feedBack.FeedBackId = Convert.ToInt32(dr["FeedBackId"]);
                feedBack.SessionId = Convert.ToInt32(dr["SessionId"]);
                feedBack.MenteeId = Convert.ToInt32(dr["MenteeId"]);
                feedBack.Rating = Convert.ToString(dr["Rating"]);
                feedBack.Message = Convert.ToString(dr["Message"]);
                feedBack.MentorStatus = Convert.ToString(dr["MentorStatus"]);
                feedBack.Status = Convert.ToString(dr["Status"]);

                feedBack.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                feedBack.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                feedBack.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                feedBack.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                FeedBackList.Add(feedBack);
            }
            con.Close();
            return FeedBackList;
        }


        public FeedBack GetFeedBackById(int Id)
        {
            FeedBack feedBack = new FeedBack();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetFeedBackById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                feedBack.FeedBackId = Convert.ToInt32(dr["FeedBackId"]);
                feedBack.SessionId = Convert.ToInt32(dr["SessionId"]);
                feedBack.MenteeId = Convert.ToInt32(dr["MenteeId"]);
                feedBack.Rating = Convert.ToString(dr["Rating"]);
                feedBack.Message = Convert.ToString(dr["Message"]);
                feedBack.MentorStatus = Convert.ToString(dr["MentorStatus"]);
                feedBack.Status = Convert.ToString(dr["Status"]);

                feedBack.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                feedBack.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                feedBack.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                feedBack.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return feedBack;
        }


        public string AddFeedBack(FeedBack feedBack)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddfeedBack", con);
            //cmd.Parameters.Add("FeedBackId", SqlDbType.Int).Value = feedBack.FeedBackId;
            cmd.Parameters.Add("SessionId", SqlDbType.Int).Value = feedBack.SessionId;
            cmd.Parameters.Add("MenteeId", SqlDbType.Int).Value = feedBack.MenteeId;
            cmd.Parameters.Add("Rating", SqlDbType.NVarChar).Value = feedBack.Rating;
            cmd.Parameters.Add("Message", SqlDbType.NVarChar).Value = feedBack.Message;
            cmd.Parameters.Add("MentorStatus", SqlDbType.NVarChar).Value = feedBack.MentorStatus;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = feedBack.Status;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = feedBack.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = feedBack.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = feedBack.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = feedBack.UpdatedDate;


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
        public string UpdateFeedBack(FeedBack feedBack)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateCollegeCode", con);
            cmd.Parameters.Add("FeedBackId", SqlDbType.Int).Value = feedBack.FeedBackId;
            cmd.Parameters.Add("SessionId", SqlDbType.Int).Value = feedBack.SessionId;
            cmd.Parameters.Add("MenteeId", SqlDbType.Int).Value = feedBack.MenteeId;
            cmd.Parameters.Add("Rating", SqlDbType.NVarChar).Value = feedBack.Rating;
            cmd.Parameters.Add("Message", SqlDbType.NVarChar).Value = feedBack.Message;
            cmd.Parameters.Add("MentorStatus", SqlDbType.NVarChar).Value = feedBack.MentorStatus;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = feedBack.Status;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = feedBack.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = feedBack.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = feedBack.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = feedBack.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return feedBack.FeedBackId.ToString();

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


        public string DeleteFeedBack(int FeedBackId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteCollegeCode", con);
            cmd.Parameters.Add("FeedBackId", SqlDbType.Int).Value = FeedBackId;
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