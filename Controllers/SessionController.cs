
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
    public class SessionController : ApiController
    {
        // GET: Session
        public Logger Log = null;
        public SessionController()
        {
            Log = Logger.GetLogger();
        }

        SessionDAL sessionDAL = new SessionDAL();

        [HttpGet]
        [ActionName("GetAllSession")]
        public List<Session> GetAllSession()
        {
            Log.writeMessage("SessionController GetAllSession Start");
            List<Session> list = null;
            try
            {
                list = sessionDAL.GetAllSession();
            }
            catch (Exception ex)
            {
                Log.writeMessage("SessionController GetAllSession Error " + ex.Message);
            }
            Log.writeMessage("SessionController GetAllSession End");
            return list;
        }

        [HttpGet]
        [ActionName("GetSessionById")]
        public Session GetSessionById(int Id)
        {
            Log.writeMessage("SessionController GetSessionById Start");
            Session session = null;
            try
            {
                session = sessionDAL.GetSessionById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("SessionController GetSessionById Error " + ex.Message);
            }
            Log.writeMessage("StudentController GetStudentById End");
            return session;
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
        [ActionName("AddSession")]
        public IHttpActionResult AddSession(Session session)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                session.CreatedBy = "Admin";
                session.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                session.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                session.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = sessionDAL.AddSession(session);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SessionController AddSession Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateSession")]
        public IHttpActionResult UpdateSession(Session session)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                session.CreatedBy = "Admin";
                session.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                session.UpdatedBy = "Admin";
                session.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = sessionDAL.UpdateSession(session);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SessionController AddSession Error " + ex.Message);
            }
            return Ok(result);
        }
        /// DELETE: api/Address/5

        public IHttpActionResult DeleteStudent(int Id)
        {
            try
            {
                var result = sessionDAL.DeleteSession(Id);

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
                Log.writeMessage("SessionController DeleteSession Error " + ex.Message);
            }
            return Ok("Failed");
        }

        /*[HttpPost]
        public async Task<IHttpActionResult> SaveSessionImage(int Id)
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
                    var student = sessionDAL.GetSessionById(Id);
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