using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Web.Http.Cors;
using PrismAPI.DAL;
using PrismAPI.Models;

namespace PrismAPI.Controllers
{
    public class OfficeController : ApiController
    {
        // GET: Office
        public Logger Log = null;
        public OfficeController()
        {
            Log = Logger.GetLogger();
        }

        OfficeDAL officeDAL = new OfficeDAL();

        [HttpGet]
        [ActionName("GetAllOffice")]
        public List<Office> GetAllOffice()
        {
            Log.writeMessage("OfficeController GetAllOffice Start");
            List<Office> list = null;
            try
            {
                list = officeDAL.GetAllOffice();
            }
            catch (Exception ex)
            {
                Log.writeMessage("OfficeController GetAllOffice Error " + ex.Message);
            }
            Log.writeMessage("OfficeController GetAllOffice End");
            return list;
        }

        [HttpGet]
        [ActionName("GetOfficeById")]
        public Office GetOfficeById(int Id)
        {
            Log.writeMessage("OfficeController GetOfficeById Start");
            Office office = null;
            try
            {
                office = officeDAL.GetOfficeById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("LoginCodeController GetLoginCodeById Error " + ex.Message);
            }
            Log.writeMessage("LoginCodeController GetLoginCodeById End");
            return office;
        }

        /*[HttpGet]
        [ActionName("GetLoginCodeByEmail")]
        public LoginCode GetLoginCodeByEmail(string Email)
        {
            Log.writeMessage("LoginCodeController GetLoginCodeByEmail Start");
            LoginCode loginCode = null;
            try
            {
                loginCode = loginCodeDAL.GetLoginCodeByEmail(Email);
            }
            catch (Exception ex)
            {
                Log.writeMessage("LoginCodeController GetLoginCodeByEmail Error " + ex.Message);
            }
            Log.writeMessage("LoginCodeController GetLoginCodeByEmail End");
            return loginCode;
        }*/

        [HttpPost]
        [ActionName("AddOffice")]
        public IHttpActionResult AddOffice(Office office)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                office.CreatedBy = "Admin";
                office.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                office.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                office.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = officeDAL.AddOffice(office);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("OfficeController AddOffice Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateOffice")]
        public IHttpActionResult UpdateOffice(Office office)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                office.CreatedBy = "Admin";
                office.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                office.UpdatedBy = "Admin";
                office.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = officeDAL.UpdateOffice(office);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("OfficeController AddOffice Error " + ex.Message);
            }
            return Ok(result);
        }
        /// DELETE: api/Address/5

        public IHttpActionResult DeleteOffice(int Id)
        {
            try
            {
                var result = officeDAL.DeleteOffice(Id);

                if (result == "Success")
               {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage("OfficeController DeleteOffice Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}