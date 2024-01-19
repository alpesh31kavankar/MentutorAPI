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
    public class IndividualPlanController : ApiController
    {
        // GET: IndividualPlan
        public Logger Log = null;
        public IndividualPlanController()
        {
            Log = Logger.GetLogger();
        }

        IndividualPlanDAL individualPlanDAL = new IndividualPlanDAL();

        [HttpGet]
        [ActionName("GetAllIndividualPlan")]
        public List<IndividualPlan> GetAllIndividualPlan()
        {
            Log.writeMessage("IndividualPlanController GetAllIndividualPlan Start");
            List<IndividualPlan> list = null;
            try
            {
                list = individualPlanDAL.GetAllIndividualPlan();
            }
            catch (Exception ex)
            {
                Log.writeMessage("IndividualPlanController GetAllIndividualPlan Error " + ex.Message);
            }
            Log.writeMessage("IndividualPlanController GetAllIndividualPlan End");
            return list;
        }

        [HttpGet]
        [ActionName("GetIndividualPlanById")]
        public IndividualPlan GetIndividualPlanById(int IndividualPlanId)
        {
            Log.writeMessage("IndividualPlanController GetIndividualPlanById Start");
            IndividualPlan individualPlan = null;
            try
            {
                individualPlan = individualPlanDAL.GetIndividualPlanById(IndividualPlanId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("IndividualPlanController GetIndividualPlanById Error " + ex.Message);
            }
            Log.writeMessage("IndividualPlanController GetIndividualPlanById End");
            return individualPlan;
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
        [ActionName("AddIndividualPlan")]
        public IHttpActionResult AddIndividualPlan(IndividualPlan individualPlan)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                individualPlan.CreatedBy = "Admin";
                individualPlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                individualPlan.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                individualPlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = individualPlanDAL.AddIndividualPlan(individualPlan);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("IndividualPlanController AddIndividualPlan Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateIndividualPlan")]
        public IHttpActionResult UpdateIndividualPlan(IndividualPlan individualPlan)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                individualPlan.CreatedBy = "Admin";
                individualPlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                individualPlan.UpdatedBy = "Admin";
                individualPlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = individualPlanDAL.UpdateIndividualPlan(individualPlan);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("IndividualPlanController AddIndividualPlan Error " + ex.Message);
            }
            return Ok(result);
        }
        /// DELETE: api/Address/5

        public IHttpActionResult DeleteIndividualPlan(int IndividualPlanId)
        {
            try
            {
                var result = individualPlanDAL.DeleteIndividualPlan(IndividualPlanId);

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
                Log.writeMessage("IndividualPlanController DeleteIndividualPlan Error " + ex.Message);
            }
            return Ok("Failed");
        }

      /*  [HttpPost]
        public async Task<IHttpActionResult> SaveStudentImage(int Id)
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.Contents)
                {
                    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                    var buffer = await file.ReadAsByteArrayAsync();
                    string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                    //get the folder that's in
                    string theDirectory = Path.GetDirectoryName(fullPath);
                    theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
                    File.WriteAllBytes(theDirectory + "/Content/Student" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var student = studentDAL.GetStudentById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (student.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Student" + "/" + student.Photo);
                        student.Photo = Id + "_" + filename;
                        var result = studentDAL.UpdateStudent(student);

                    }
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage(ex.Message);
            }

            return Ok();
        }*/
    }
}