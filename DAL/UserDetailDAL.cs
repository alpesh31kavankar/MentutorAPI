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
    public class UserDetailDAL
    {
        DbConnection conn = null;
        public UserDetailDAL()
        {
            conn = new DbConnection();
        }

        public List<UserDetail> GetAllUserDetail()
        {
            List<UserDetail> userDetailList = new List<UserDetail>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                UserDetail userDetail = new UserDetail();

                userDetail.UserDetailId = Convert.ToInt32(dr["UserDetailId"]);
                userDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                userDetail.CountryId = Convert.ToInt32(dr["CountryId"]);
                userDetail.StateId = Convert.ToInt32(dr["StateId"]);
                userDetail.CityId = Convert.ToInt32(dr["CityId"]);
                userDetail.Address = Convert.ToString(dr["Address"]);
                userDetail.Contact = Convert.ToString(dr["Contact"]);
                userDetail.Photo = Convert.ToString(dr["Photo"]);
                userDetail.Status = Convert.ToString(dr["Status"]);




                userDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                userDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                userDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                userDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);



                userDetailList.Add(userDetail);
            }
            con.Close();
            return userDetailList;
        }





        public UserDetail GetuserDetailById(int Id)
        {
            UserDetail userDetail = new UserDetail();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserDetailById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                userDetail.UserDetailId = Convert.ToInt32(dr["UserDetailId"]);
                userDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                userDetail.CountryId = Convert.ToInt32(dr["CountryId"]);
                userDetail.StateId = Convert.ToInt32(dr["StateId"]);
                userDetail.CityId = Convert.ToInt32(dr["CityId"]);
                userDetail.Address = Convert.ToString(dr["Address"]);
                userDetail.Contact = Convert.ToString(dr["Contact"]);
                userDetail.Photo = Convert.ToString(dr["Photo"]);
                userDetail.Status = Convert.ToString(dr["Status"]);




                userDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                userDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                userDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                userDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);






            }
            con.Close();
            return userDetail;
        }


        public string AddUserDetail(UserDetail userDetail)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserDetail", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = instructor.Id;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = userDetail.Address;
            cmd.Parameters.Add("Contact", SqlDbType.NVarChar).Value = userDetail.Contact;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = userDetail.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = userDetail.Status;




            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userDetail.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userDetail.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userDetail.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userDetail.UpdatedDate;




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
        public string UpdateUserDetail(UserDetail userDetail)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserDetail", con);
            cmd.Parameters.Add("UserDetailId", SqlDbType.Int).Value = userDetail.UserDetailId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = userDetail.RegistrationId;
            cmd.Parameters.Add("CountryId", SqlDbType.Int).Value = userDetail.CountryId;
            cmd.Parameters.Add("StateId", SqlDbType.Int).Value = userDetail.StateId;
            cmd.Parameters.Add("CityId", SqlDbType.Int).Value = userDetail.CityId;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = userDetail.Address;
            cmd.Parameters.Add("Contact", SqlDbType.NVarChar).Value = userDetail.Contact;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = userDetail.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = userDetail.Status;




            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userDetail.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userDetail.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userDetail.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userDetail.UpdatedDate;




            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return userDetail.UserDetailId.ToString();

        }
        public string DeleteUserDetail(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteUserDetail", con);
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

        internal UserDetail GetUserDetailById(int id)
        {
            throw new NotImplementedException();
        }
    }
}