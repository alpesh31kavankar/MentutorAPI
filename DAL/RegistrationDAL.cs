using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class RegistrationDAL
    {
        DbConnection conn = null;
        public RegistrationDAL()
        {
            conn = new DbConnection();
        }


        public List<Registration> GetAllRegistration()

        {
            List<Registration> RegistrationList = new List<Registration>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Registration registration = new Registration();

                registration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                registration.FName = Convert.ToString(dr["FName"]);
                registration.LName = Convert.ToString(dr["LName"]);
                registration.Email = Convert.ToString(dr["Email"]);
                registration.Password = Convert.ToString(dr["Password"]);
                registration.EmailStatus = Convert.ToString(dr["EmailStatus"]);
                registration.OTPNo = Convert.ToString(dr["OTPNo"]);
                registration.Status = Convert.ToString(dr["Status"]);

                registration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                registration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                registration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                registration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                RegistrationList.Add(registration);
            }
            con.Close();
            return RegistrationList;
        }

        public Registration GetRegistrationByEmail(string Email)
        {
            Registration registration = new Registration();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetRegistrationByEmail", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                registration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                registration.FName = Convert.ToString(dr["FName"]);
                registration.LName = Convert.ToString(dr["LName"]);
                registration.Email = Convert.ToString(dr["Email"]);
                registration.Password = Convert.ToString(dr["Password"]);
                registration.EmailStatus = Convert.ToString(dr["EmailStatus"]);
                registration.OTPNo = Convert.ToString(dr["OTPNo"]);
                registration.Status = Convert.ToString(dr["Status"]);

                registration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                registration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                registration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                registration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return registration;
        }

        public Login Login(string Email, string Password)
        {
            Login user = new Login();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserByEmailAndPassword", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                user.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                //user.Role = Convert.ToString(dr["Role"]);
            }
            return user;
        }



        public string AddRegistration(Registration registration)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddRegistration", con);
            //cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = registration.RegistrationId;

            cmd.Parameters.Add("FName", SqlDbType.NVarChar).Value = registration.FName;
            cmd.Parameters.Add("LName", SqlDbType.NVarChar).Value = registration.LName;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = registration.Email;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = registration.Password;
            cmd.Parameters.Add("EmailStatus", SqlDbType.NVarChar).Value = registration.EmailStatus;
            cmd.Parameters.Add("OTPNo", SqlDbType.NVarChar).Value = registration.OTPNo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = registration.Status;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = registration.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = registration.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = registration.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = registration.UpdatedDate;

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
        public string UpdateRegistration(Registration registration)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateRegistration", con);

            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = registration.RegistrationId;
            cmd.Parameters.Add("FName", SqlDbType.NVarChar).Value = registration.FName;
            cmd.Parameters.Add("LName", SqlDbType.NVarChar).Value = registration.LName;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = registration.Email;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = registration.Password;
            cmd.Parameters.Add("EmailStatus", SqlDbType.NVarChar).Value = registration.EmailStatus;
            cmd.Parameters.Add("OTPNo", SqlDbType.NVarChar).Value = registration.OTPNo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = registration.Status;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = registration.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = registration.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = registration.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = registration.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return registration.RegistrationId.ToString();

        }

        public Registration GetRegistrationById(int RegistrationId)
        {
            Registration registration = new Registration();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetRegistrationById", con);
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = RegistrationId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                registration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                registration.FName = Convert.ToString(dr["FName"]);
                registration.LName = Convert.ToString(dr["LName"]);
                registration.Email = Convert.ToString(dr["Email"]);
                registration.Password = Convert.ToString(dr["Password"]);
                registration.EmailStatus = Convert.ToString(dr["EmailStatus"]);
                registration.OTPNo = Convert.ToString(dr["OTPNo"]);
                registration.Status = Convert.ToString(dr["Status"]);


                registration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                registration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                registration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                registration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return registration;
        }

        public string DeleteRegistration(int RegistrationId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteRegistration", con);
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = RegistrationId;
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