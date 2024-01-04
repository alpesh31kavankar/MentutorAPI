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
    public class MentorProfileController : ApiController
    {
        // GET: MentorProfile
        public Logger Log = null;
        public MentorProfileController()
        {
            Log = Logger.GetLogger();
        }

        MentorProfileDAL mentorProfileDAL = new MentorProfileDAL();

        [HttpGet]
        [ActionName("GetAllMentorProfile")]
        public List<MentorProfile> GetAllMentorProfile()
        {
            Log.writeMessage("MentorProfileController GetAllMentorProfile Start");
            List<MentorProfile> list = null;
            try
            {
                list = mentorProfileDAL.GetAllMentorProfile();
            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorProfileController GetAllMentorProfile Error " + ex.Message);
            }
            Log.writeMessage("MentorProfileController GetAllMentorProfile End");
            return list;
        }

        [HttpGet]
        [ActionName("GetMentorProfileById")]
        public MentorProfile GetMentorProfileById(int Id)
        {
            Log.writeMessage("MentorProfileController GetMentorProfileById Start");
            MentorProfile mentorProfile = null;
            try
            {
                mentorProfile = mentorProfileDAL.GetMentorProfileById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorProfileController GetMentorProfileById Error " + ex.Message);
            }
            Log.writeMessage("MentorProfileController GetMentorProfileById End");
            return mentorProfile;
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
        [ActionName("AddMentorProfile")]
        public IHttpActionResult AddMentorProfile(MentorProfile mentorProfile)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                mentorProfile.CreatedBy = "Admin";
                mentorProfile.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                mentorProfile.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                mentorProfile.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = mentorProfileDAL.AddMentorProfile(mentorProfile);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorProfileController AddMentorProfile Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateMentorProfile")]
        public IHttpActionResult UpdateMentorProfile(MentorProfile mentorProfile)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                mentorProfile.CreatedBy = "Admin";
                mentorProfile.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                mentorProfile.UpdatedBy = "Admin";
                mentorProfile.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = mentorProfileDAL.UpdateMentorProfile(mentorProfile);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorProfileController AddMentorProfile Error " + ex.Message);
            }
            return Ok(result);
        }
        /// DELETE: api/Address/5

        public IHttpActionResult DeleteStudent(int Id)
        {
            try
            {
                var result = mentorProfileDAL.DeleteMentorProfile(Id);

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
                Log.writeMessage("MentorProfileController DeleteMentorProfile Error " + ex.Message);
            }
            return Ok("Failed");
        }

        /*[HttpPost]
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