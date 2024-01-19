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
    public class SubCategoryDAL
    {
        DbConnection conn = null;
        public SubCategoryDAL()
        {
            conn = new DbConnection();
        }

        public List<SubCategory> GetAllSubCategory()
        {
            List<SubCategory> subCategoryList = new List<SubCategory>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllSubCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SubCategory subCategory = new SubCategory();
                subCategory.mainCategory = new MainCategory();

                subCategory.SubCategoryId = Convert.ToInt32(dr["SubCategoryId"]);
                subCategory.mainCategory.MainCategoryId = Convert.ToInt32(dr["MainCategoryId"]);
                subCategory.mainCategory.Title = Convert.ToString(dr["Title1"]);
                subCategory.Title = Convert.ToString(dr["Title"]);
                subCategory.Description = Convert.ToString(dr["Description"]);
                subCategory.Photo = Convert.ToString(dr["Photo"]);
                subCategory.Status = Convert.ToString(dr["Status"]);
                subCategory.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                subCategory.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                subCategory.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                subCategory.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
             
                subCategoryList.Add(subCategory);
            }
            con.Close();
            return subCategoryList;
        }


        public SubCategory GetSubCategoryById(int SubCategoryId)
        {
            SubCategory subCategory = new SubCategory();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetSubCategoryById", con);
            cmd.Parameters.Add("SubCategoryId", SqlDbType.Int).Value = SubCategoryId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                subCategory.mainCategory = new MainCategory();
                subCategory.SubCategoryId = Convert.ToInt32(dr["SubCategoryId"]);
                subCategory.mainCategory.MainCategoryId = Convert.ToInt32(dr["MainCategoryId"]);
                subCategory.mainCategory.Title = Convert.ToString(dr["Title1"]);
                subCategory.Title = Convert.ToString(dr["Title"]);
                subCategory.Description = Convert.ToString(dr["Description"]);
                subCategory.Photo = Convert.ToString(dr["Photo"]);
                subCategory.Status = Convert.ToString(dr["Status"]);
                subCategory.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                subCategory.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                subCategory.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                subCategory.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return subCategory;
        }


        public string AddSubCategory(SubCategory subCategory)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddSubCategory", con);
            cmd.Parameters.Add("MainCategoryId", SqlDbType.Int).Value = subCategory.mainCategory.MainCategoryId; 
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = subCategory.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = subCategory.Description;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = subCategory.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = subCategory.Status;
         
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = subCategory.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = subCategory.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = subCategory.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = subCategory.UpdatedDate;

            Random r = new Random();
            int num = r.Next();

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var SubCategoryId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return SubCategoryId.ToString();

        }

        [HttpPost]
        public string UpdateSubCategory(SubCategory subCategory)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateSubCategory", con);
            cmd.Parameters.Add("SubCategoryId", SqlDbType.Int).Value = subCategory.SubCategoryId;
            cmd.Parameters.Add("MainCategoryId", SqlDbType.Int).Value = subCategory.mainCategory.MainCategoryId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = subCategory.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = subCategory.Description;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = subCategory.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = subCategory.Status;
     
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = subCategory.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = subCategory.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = subCategory.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = subCategory.UpdatedDate;
       
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var SubCategoryId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return subCategory.SubCategoryId.ToString();

        }
        public string DeleteSubCategory(int SubCategoryId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteSubCategory", con);
            cmd.Parameters.Add("SubCategoryId", SqlDbType.Int).Value = SubCategoryId;
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