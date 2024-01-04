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
    public class MenteePlanController : ApiController
    {
        // GET: MenteePlan
        public Logger Log = null;
        public MenteePlanController()
        {
            Log = Logger.GetLogger();
        }
        MenteePlanDAL menteePlanDAL = new MenteePlanDAL();

        [HttpGet]
        [ActionName("GetAllMenteePlan")]

        public List<MenteePlan> GetAllEmployeeCode()
        {
            Log.writeMessage("MenteePlanController GetAllMenteePlan Start");
            List<MenteePlan> list = null;
            try
            {
                list = menteePlanDAL.GetAllMenteePlan();
            }
            catch (Exception ex)
            {
                Log.writeMessage("MenteePlanController GetAllMenteePlan Error " + ex.Message);
            }
            Log.writeMessage("MenteePlanController GetAllMenteePlan End");
            return list;

        }

        [HttpPost]
        [ActionName("AddMenteePlan")]
        public IHttpActionResult AddMenteePlan(MenteePlan menteePlan)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                menteePlan.CreatedBy = "Admin";
                menteePlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                menteePlan.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                menteePlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = menteePlanDAL.AddMenteePlan(menteePlan);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MenteePlanController AddMenteePlan Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateMenteePlan")]
        public IHttpActionResult UpdateMenteePlan(MenteePlan menteePlan)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                menteePlan.CreatedBy = "Admin";
                menteePlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                menteePlan.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                menteePlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = menteePlanDAL.UpdateMenteePlan(menteePlan);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MenteePlanController AddMenteePlan Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetMenteePlanById")]
        public MenteePlan GetMenteePlanById(int MenteePlanId)
        {
            Log.writeMessage("GetMenteePlanController GetMenteePlanById Start");
            MenteePlan menteePlan = null;
            try
            {
                menteePlan = menteePlanDAL.GetMenteePlanById(MenteePlanId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetMenteePlanController GetMenteePlanById Error " + ex.Message);
            }
            Log.writeMessage("GetMenteePlanController GetMenteePlanById End");
            return menteePlan;
        }
        public IHttpActionResult DeleteMenteePlan(int MenteePlanId)
        {
            try
            {
                var result = menteePlanDAL.DeleteMenteePlan(MenteePlanId);

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
                Log.writeMessage("MenteePlanController DeleteGetMenteePlan Error " + ex.Message);
            }
            return Ok("Failed");
        }


        //[HttpPost]
        //public async Task<IHttpActionResult> SaveProfilePhoto(int Id)
        //{
        //    try
        //    {
        //        if (!Request.Content.IsMimeMultipartContent())
        //            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

        //        var provider = new MultipartMemoryStreamProvider();
        //        await Request.Content.ReadAsMultipartAsync(provider);
        //        foreach (var file in provider.Contents)
        //        {
        //            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
        //            var buffer = await file.ReadAsByteArrayAsync();
        //            string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //            //get the folder that's in
        //            string theDirectory = Path.GetDirectoryName(fullPath);
        //            theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));

        //            File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);
        //            //Do whatever you want with filename and its binary data.
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }

        //    return Ok();
        //}

        //[HttpPost]
        //public void SaveProfilePhoto(UserProfilePhoto profile)
        //{
        //    try
        //    {
        //        byte[] imageBytes = Convert.FromBase64String(profile.Photo);
        //        string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //        string theDirectory = Path.GetDirectoryName(fullPath);
        //        theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
        //        //string filePath = "http://localhost:62842/ProfilePhoto/";
        //        File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "ProfilePicture_" + profile.Id + ".jpeg", imageBytes);
        //        //File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }
        //}

        //[HttpPost]
        //public async Task<IHttpActionResult> SaveEmployeeCodeImage(int Id)
        //{
        //    try
        //    {
        //        if (!Request.Content.IsMimeMultipartContent())
        //            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

        //        var provider = new MultipartMemoryStreamProvider();
        //        await Request.Content.ReadAsMultipartAsync(provider);
        //        foreach (var file in provider.Contents)
        //        {
        //            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
        //            var buffer = await file.ReadAsByteArrayAsync();
        //            string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //            //get the folder that's in
        //            string theDirectory = Path.GetDirectoryName(fullPath);
        //            theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
        //            File.WriteAllBytes(theDirectory + "/Content/EmployeeCode" + "/" + Id + "_" + filename, buffer);
        //            //Do whatever you want with filename and its binary data.

        //            // get existing rocrd
        //            var employeeCode = employeeCodeDAL.GetEmployeeCodeById(Id);
        //            var filenamenew = Id + "_" + filename;
        //            if (employeeCode.Photo.ToLower() != filenamenew.ToLower())
        //            {
        //                File.Delete(theDirectory + "/Content/EmployeeCode" + "/" + employeeCode.Photo);
        //                employeeCode.Photo = Id + "_" + filename;
        //                var result = employeeCodeDAL.UpdateEmployeeCode(employeeCode);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }

        //    return Ok();
        //}

    }
}