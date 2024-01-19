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
    public class MentorSkillDAL
    {
        DbConnection conn = null;
        public MentorSkillDAL()
        {
            conn = new DbConnection();
        }

        public List<MentorSkill> GetAllMentorSkill()
        {
            List<MentorSkill> mentorSkillList = new List<MentorSkill>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllMentorSkill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                MentorSkill mentorSkill = new MentorSkill();

                mentorSkill.MentorSkillId = Convert.ToInt32(dr["MentorSkillId"]);
                mentorSkill.MentorProfileId = Convert.ToInt32(dr["MentorProfileId"]);
                mentorSkill.SkillId = Convert.ToInt32(dr["SkillId"]);

                mentorSkill.Certificate = Convert.ToString(dr["Certificate"]);
                mentorSkill.Status = Convert.ToString(dr["Status"]);
                mentorSkill.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                mentorSkill.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                mentorSkill.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                mentorSkill.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                mentorSkillList.Add(mentorSkill);
            }
            con.Close();
            return mentorSkillList;
        }


        //public LoginCode GetLoginCodeByEmail(string Email)
        //{
        //    LoginCode loginCode = new LoginCode();

        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("GetUserLoginByEmail", con);
        //    cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        loginCode.Id = Convert.ToInt32(dr["Id"]);

        //        loginCode.Name = Convert.ToString(dr["Name"]);
        //        loginCode.Email = Convert.ToString(dr["Email"]);
        //        loginCode.Mobile = Convert.ToString(dr["Mobile"]);
        //        loginCode.Password = Convert.ToString(dr["Password"]);
        //        loginCode.Address = Convert.ToString(dr["Address"]);

        //        loginCode.BirthDate = Convert.ToString(dr["BirthDate"]);

        //        loginCode.Photo = Convert.ToString(dr["Photo"]);
        //        loginCode.EmailStatus = Convert.ToString(dr["EmailStatus"]);

        //        loginCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
        //        loginCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
        //        loginCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
        //        loginCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
        //    }
        //    con.Close();
        //    return loginCode;
        //}



        public MentorSkill GetMentorSkillById(int MentorSkillId)
        {
            MentorSkill mentorSkill = new MentorSkill();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetMentorSkillById", con);
            cmd.Parameters.Add("MentorSkillId", SqlDbType.Int).Value = MentorSkillId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                mentorSkill.MentorSkillId = Convert.ToInt32(dr["MentorSkillId"]);
                mentorSkill.MentorProfileId = Convert.ToInt32(dr["MentorProfileId"]);
                mentorSkill.SkillId = Convert.ToInt32(dr["SkillId"]);

                mentorSkill.Certificate = Convert.ToString(dr["Certificate"]);
                mentorSkill.Status = Convert.ToString(dr["Status"]);
                mentorSkill.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                mentorSkill.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                mentorSkill.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                mentorSkill.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return mentorSkill;
        }


        public string AddMentorSkill(MentorSkill mentorSkill)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddMentorSkill", con);
            //cmd.Parameters.Add("MentorSkillId", SqlDbType.Int).Value = mentorSkill.MentorSkillId;
            cmd.Parameters.Add("MentorProfileId", SqlDbType.Int).Value = mentorSkill.MentorProfileId;
            cmd.Parameters.Add("SkillId", SqlDbType.Int).Value = mentorSkill.SkillId;
            cmd.Parameters.Add("Certificate", SqlDbType.NVarChar).Value = mentorSkill.Certificate;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = mentorSkill.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = mentorSkill.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = mentorSkill.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = mentorSkill.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = mentorSkill.UpdatedDate;


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
        public string UpdateMentorSkill(MentorSkill mentorSkill)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateMentorSkill", con);
            cmd.Parameters.Add("MentorSkillId", SqlDbType.Int).Value = mentorSkill.MentorSkillId;
            cmd.Parameters.Add("MentorProfileId", SqlDbType.Int).Value = mentorSkill.MentorProfileId;
            cmd.Parameters.Add("SkillId", SqlDbType.Int).Value = mentorSkill.SkillId;
            cmd.Parameters.Add("Certificate", SqlDbType.NVarChar).Value = mentorSkill.Certificate;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = mentorSkill.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = mentorSkill.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = mentorSkill.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = mentorSkill.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = mentorSkill.UpdatedDate;

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return mentorSkill.MentorSkillId.ToString();

        }

        //public Loginc Loginc(string Email, string Password)
        //{
        //    Loginc user = new Loginc();
        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("GetUserEmailAndPassword", con);
        //    cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
        //    cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        // user.Id = Convert.ToInt32(dr["Id"]);
        //        //user.Role = Convert.ToString(dr["Role"]);
        //    }
        //    return user;
        //}


        //public OtpNo OtpNo(string Mobile)
        //{
        //    OtpNo OtpNo = new OtpNo();
        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("GetUserOtp", con);
        //    cmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = Mobile;

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        OtpNo.Id = Convert.ToInt32(dr["Id"]);
        //        //user.Role = Convert.ToString(dr["Role"]);
        //    }
        //    return OtpNo;
        //}
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


        public string DeleteMentorSkill(int MentorSkillId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteMentorSkill", con);
            cmd.Parameters.Add("MentorSkillId", SqlDbType.Int).Value = MentorSkillId;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
            //}
        }
    }
}