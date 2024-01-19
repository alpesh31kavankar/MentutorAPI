using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class MenteeSkillDAL
    {
        DbConnection conn = null;
        public MenteeSkillDAL()
        {
            conn = new DbConnection();
        }

        public List<MenteeSkill> GetAllMenteeSkill()
        {
            List<MenteeSkill> MenteeSkillList = new List<MenteeSkill>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllMenteeSkill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                MenteeSkill menteeSkill = new MenteeSkill();

                menteeSkill.MenteeSkillId = Convert.ToInt32(dr["MenteeSkillId"]);
                menteeSkill.MenteeProfileId = Convert.ToInt32(dr["MenteeProfileId"]);
                menteeSkill.SkillId = Convert.ToInt32(dr["SkillId"]);
                menteeSkill.Status = Convert.ToString(dr["Status"]);

                menteeSkill.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                menteeSkill.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                menteeSkill.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                menteeSkill.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                MenteeSkillList.Add(menteeSkill);
            }
            con.Close();
            return MenteeSkillList;
        }

        public MenteeSkill GetMenteeSkillById(int MenteeSkillId)
        {
            MenteeSkill menteeSkill = new MenteeSkill();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetMenteeSkillById", con);
            cmd.Parameters.Add("MenteeSkillId", SqlDbType.Int).Value = MenteeSkillId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {




                menteeSkill.MenteeSkillId = Convert.ToInt32(dr["MenteeSkillId"]);
                menteeSkill.MenteeProfileId = Convert.ToInt32(dr["MenteeProfileId"]);
                menteeSkill.SkillId = Convert.ToInt32(dr["SkillId"]);
                menteeSkill.Status = Convert.ToString(dr["Status"]);

                menteeSkill.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                menteeSkill.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                menteeSkill.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                menteeSkill.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return menteeSkill;
        }


        public string AddMenteeSkill(MenteeSkill menteeSkill)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddMenteeSkill", con);
            //cmd.Parameters.Add("MenteeSkillId", SqlDbType.Int).Value = menteeSkill.MenteeSkillId;
            cmd.Parameters.Add("MenteeProfileId", SqlDbType.Int).Value = menteeSkill.MenteeProfileId;
            cmd.Parameters.Add("SkillId", SqlDbType.Int).Value = menteeSkill.SkillId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = menteeSkill.Status;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = menteeSkill.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = menteeSkill.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = menteeSkill.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = menteeSkill.UpdatedDate;


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
        public string UpdateMenteeSkill(MenteeSkill menteeSkill)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateMenteeSkill", con);


            cmd.Parameters.Add("MenteeSkillId", SqlDbType.Int).Value = menteeSkill.MenteeSkillId;
            cmd.Parameters.Add("MenteeProfileId", SqlDbType.Int).Value = menteeSkill.MenteeProfileId;
            cmd.Parameters.Add("SkillId", SqlDbType.Int).Value = menteeSkill.SkillId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = menteeSkill.Status;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = menteeSkill.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = menteeSkill.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = menteeSkill.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = menteeSkill.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return menteeSkill.MenteeSkillId.ToString();

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


        public string DeleteMenteeSkill(int MenteeSkillId)
        
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteMenteeSkill", con);
            cmd.Parameters.Add("MenteeSkillId", SqlDbType.Int).Value = MenteeSkillId;
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