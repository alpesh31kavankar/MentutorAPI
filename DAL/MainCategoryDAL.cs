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
    public class MainCategoryDAL
    {
        DbConnection conn = null;
        public MainCategoryDAL()
        {
            conn = new DbConnection();
        }

        public List<MainCategory> GetAllMainCategory()
        {
            List<MainCategory> mainCategoryList = new List<MainCategory>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllMainCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                MainCategory mainCategory = new MainCategory();

                mainCategory.MainCategoryId = Convert.ToInt32(dr["MainCategoryId"]);

                mainCategory.Title = Convert.ToString(dr["Title"]);
                mainCategory.Description = Convert.ToString(dr["Description"]);
                mainCategory.Photo = Convert.ToString(dr["Photo"]);
                mainCategory.Status = Convert.ToString(dr["Status"]);
                mainCategory.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                mainCategory.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                mainCategory.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                mainCategory.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                mainCategoryList.Add(mainCategory);
            }
            con.Close();
            return mainCategoryList;
        }





        public MainCategory GetMainCategoryById(int MainCategoryId)
        {
            MainCategory mainCategory = new MainCategory();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetMainCategoryById", con);
            cmd.Parameters.Add("MainCategoryId", SqlDbType.Int).Value = MainCategoryId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                mainCategory.MainCategoryId = Convert.ToInt32(dr["MainCategoryId"]);

                mainCategory.Title = Convert.ToString(dr["Title"]);
                mainCategory.Description = Convert.ToString(dr["Description"]);
                mainCategory.Photo = Convert.ToString(dr["Photo"]);
                mainCategory.Status = Convert.ToString(dr["Status"]);
                mainCategory.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                mainCategory.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                mainCategory.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                mainCategory.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return mainCategory;
        }


        public string AddMainCategory(MainCategory mainCategory)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddMainCategory", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = instructor.Id;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = mainCategory.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = mainCategory.Description;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = mainCategory.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = mainCategory.Status;
           
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = mainCategory.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = mainCategory.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = mainCategory.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = mainCategory.UpdatedDate;
          
            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var MainCategoryId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return MainCategoryId.ToString();

        }

        [HttpPost]
        public string UpdateMainCategory(MainCategory mainCategory)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateMainCategory", con);
            cmd.Parameters.Add("MainCategoryId", SqlDbType.Int).Value = mainCategory.MainCategoryId;

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = mainCategory.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = mainCategory.Description;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = mainCategory.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = mainCategory.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = mainCategory.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = mainCategory.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = mainCategory.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = mainCategory.UpdatedDate;

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var MainCategoryId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return mainCategory.MainCategoryId.ToString();

        }
        public string DeleteMainCategory(int MainCategoryId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteMainCategory", con);
            cmd.Parameters.Add("MainCategoryId", SqlDbType.Int).Value = MainCategoryId;
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