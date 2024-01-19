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
    public class SkillDAL
    {
        DbConnection conn = null;
        public SkillDAL()
        {
            conn = new DbConnection();
        }

        public List<Skill> GetAllSkill()
        {
            List<Skill> skillList = new List<Skill>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllSkill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Skill skill = new Skill();
                skill.subCategory = new SubCategory();

                skill.SkillId = Convert.ToInt32(dr["SkillId"]);
                skill.subCategory.SubCategoryId = Convert.ToInt32(dr["SubcategoryId"]);
                skill.subCategory.Title = Convert.ToString(dr["Title1"]);
                skill.Title = Convert.ToString(dr["Title"]);
                skill.Description = Convert.ToString(dr["Description"]);
                skill.Photo = Convert.ToString(dr["Photo"]);
                skill.Status = Convert.ToString(dr["Status"]);




                skill.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                skill.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                skill.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                skill.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);



                skillList.Add(skill);
            }
            con.Close();
            return skillList;
        }





        public Skill GetSkillById(int SkillId)
        {
            Skill skill = new Skill();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetSkillById", con);
            cmd.Parameters.Add("SkillId", SqlDbType.Int).Value = SkillId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                skill.subCategory = new SubCategory();
                skill.SkillId = Convert.ToInt32(dr["SkillId"]);
                skill.subCategory.SubCategoryId = Convert.ToInt32(dr["SubcategoryId"]);
                skill.subCategory.Title = Convert.ToString(dr["Title1"]);
                skill.Title = Convert.ToString(dr["Title"]);
                skill.Description = Convert.ToString(dr["Description"]);
                skill.Photo = Convert.ToString(dr["Photo"]);
                skill.Status = Convert.ToString(dr["Status"]);



                skill.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                skill.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                skill.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                skill.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);






            }
            con.Close();
            return skill;
        }


        public string AddSkill(Skill skill)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddSkill", con);
            cmd.Parameters.Add("SubCategoryId", SqlDbType.Int).Value = skill.subCategory.SubCategoryId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = skill.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = skill.Description;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = skill.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = skill.Status;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = skill.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = skill.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = skill.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = skill.UpdatedDate;




            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var SkillId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return SkillId.ToString();

        }

        [HttpPost]
        public string UpdateSkill(Skill skill)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateSkill", con);
            cmd.Parameters.Add("SkillId", SqlDbType.Int).Value = skill.SkillId;
            cmd.Parameters.Add("SubCategoryId", SqlDbType.Int).Value = skill.subCategory.SubCategoryId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = skill.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = skill.Description;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = skill.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = skill.Status;




            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = skill.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = skill.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = skill.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = skill.UpdatedDate;




            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var SkillId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return skill.SkillId.ToString();

        }
        public string DeleteSkill(int SkillId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteSkill", con);
            cmd.Parameters.Add("SkillId", SqlDbType.Int).Value = SkillId;
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