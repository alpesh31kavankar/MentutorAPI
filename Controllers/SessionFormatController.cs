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
    public class SessionFormatController : ApiController
    {
        // GET: SessionFormat
        public Logger Log = null;
        public SessionFormatController()
        {
            Log = Logger.GetLogger();
        }

        SessionFormatDAL sessionFormatDAL = new SessionFormatDAL();

        [HttpGet]
        [ActionName("GetAllSessionFormat")]
        public List<SessionFormat> GetAllSessionFormat()
        {
            Log.writeMessage("SessionFormatController GetAllSessionFormat Start");
            List<SessionFormat> list = null;
            try
            {
                list = sessionFormatDAL.GetAllSessionFormat();
            }
            catch (Exception ex)
            {
                Log.writeMessage("SessionFormatController GetAllSessionFormat Error " + ex.Message);
            }
            Log.writeMessage("SessionFormatController GetAllSessionFormat End");
            return list;
        }

        [HttpGet]
        [ActionName("GetSessionFormatById")]
        public SessionFormat GetSessionFormatById(int Id)
        {
            Log.writeMessage("SessionFormatController GetSessionFormatById Start");
            SessionFormat sessionFormat = null;
            try
            {
                sessionFormat = sessionFormatDAL.GetSessionFormatById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("SessionFormatController GetSessionFormatById Error " + ex.Message);
            }
            Log.writeMessage("SessionFormatController GetSessionFormatById End");
            return sessionFormat;
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
        [ActionName("AddSessionFormat")]
        public IHttpActionResult AddSessionFormat(SessionFormat sessionFormat)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                sessionFormat.CreatedBy = "Admin";
                sessionFormat.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                sessionFormat.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                sessionFormat.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = sessionFormatDAL.AddSessionFormat(sessionFormat);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SessionFormatController AddSessionFormat Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateSessionFormat")]
        public IHttpActionResult UpdateSessionFormat(SessionFormat sessionFormat)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                sessionFormat.CreatedBy = "Admin";
                sessionFormat.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                sessionFormat.UpdatedBy = "Admin";
                sessionFormat.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = sessionFormatDAL.UpdateSessionFormat(sessionFormat);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SessionFormatController AddSessionFormat Error " + ex.Message);
            }
            return Ok(result);
        }
        /// DELETE: api/Address/5

        public IHttpActionResult DeleteSessionFormat(int Id)
        {
            try
            {
                var result = sessionFormatDAL.DeleteSessionFormat(Id);

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
                Log.writeMessage("SessionFormatController DeleteSessionFormat Error " + ex.Message);
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