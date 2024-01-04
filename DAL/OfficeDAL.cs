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
    public class OfficeDAL
    {
        DbConnection conn = null;
        public OfficeDAL()
        {
            conn = new DbConnection();
        }

        public List<Office> GetAllOffice()
        {
            List<Office> officeList = new List<Office>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllOffice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Office office = new Office();

                office.Id = Convert.ToInt32(dr["Id"]);

                office.Fname = Convert.ToString(dr["Fname"]);
                office.Lname = Convert.ToString(dr["Lname"]);
                office.Contact = Convert.ToString(dr["Contact"]);
                office.Email = Convert.ToString(dr["Email"]);


                office.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                office.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                office.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                office.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                officeList.Add(office);
            }
            con.Close();
            return officeList;
        }


        public Office GetOfficeByEmail(string Email)
        {
            Office office = new Office();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetOfficeByEmail", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                office.Id = Convert.ToInt32(dr["Id"]);

                office.Fname = Convert.ToString(dr["Fname"]);
                office.Lname = Convert.ToString(dr["Lname"]);
                office.Contact = Convert.ToString(dr["Contact"]);
                office.Email = Convert.ToString(dr["Email"]);


                office.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                office.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                office.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                office.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);



            }
            con.Close();
            return office;
        }



        public Office GetOfficeById(int Id)
        {
            Office office = new Office();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetOfficeById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                office.Id = Convert.ToInt32(dr["Id"]);

                office.Fname = Convert.ToString(dr["Fname"]);
                office.Lname = Convert.ToString(dr["Lname"]);
                office.Contact = Convert.ToString(dr["Contact"]);
                office.Email = Convert.ToString(dr["Email"]);


                office.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                office.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                office.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                office.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);




            }
            con.Close();
            return office;
        }


        public string AddOffice(Office office)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddOffice", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = instructor.Id;
            cmd.Parameters.Add("Fname", SqlDbType.NVarChar).Value = office.Fname;
            cmd.Parameters.Add("Lname", SqlDbType.NVarChar).Value = office.Lname;
            cmd.Parameters.Add("Contact", SqlDbType.NVarChar).Value = office.Contact;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = office.Email;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = office.Address;

            
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = office.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = office.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = office.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = office.UpdatedDate;


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
        public string UpdateOffice(Office office)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateOffice", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = office.Id;

            cmd.Parameters.Add("Fname", SqlDbType.NVarChar).Value = office.Fname;
            cmd.Parameters.Add("Lname", SqlDbType.NVarChar).Value = office.Lname;
            cmd.Parameters.Add("Contact", SqlDbType.NVarChar).Value = office.Contact;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = office.Email;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = office.Address;

           
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = office.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = office.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = office.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = office.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return office.Id.ToString();

        }
        public string DeleteOffice(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteOffice", con);
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