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
    public class StudentController : ApiController
    {
        // GET: Student
        public Logger Log = null;
        public StudentController()
        {
            Log = Logger.GetLogger();
        }

        StudentDAL studentDAL = new StudentDAL();

        [HttpGet]
        [ActionName("GetAllStudent")]
        public List<Student> GetAllStudent()
        {
            Log.writeMessage("StudentController GetAllStudent Start");
            List<Student> list = null;
            try
            {
                list = studentDAL.GetAllStudent();
            }
            catch (Exception ex)
            {
                Log.writeMessage("StudentController GetAllStudent Error " + ex.Message);
            }
            Log.writeMessage("StudentController GetAllStudent End");
            return list;
        }

        [HttpGet]
        [ActionName("GetStudentById")]
        public Student GetStudentById(int Id)
        {
            Log.writeMessage("StudentController GetStudentById Start");
            Student student = null;
            try
            {
                student = studentDAL.GetStudentById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("StudentController GetStudentById Error " + ex.Message);
            }
            Log.writeMessage("StudentController GetStudentById End");
            return student;
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
        [ActionName("AddStudent")]
        public IHttpActionResult AddStudent(Student student)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                student.CreatedBy = "Admin";
                student.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                student.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                student.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = studentDAL.AddStudent(student);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("StudentController AddStudent Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateStudent")]
        public IHttpActionResult UpdateStudent(Student student)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                student.CreatedBy = "Admin";
                student.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                student.UpdatedBy = "Admin";
                student.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = studentDAL.UpdateStudent(student);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("StudentController AddStudent Error " + ex.Message);
            }
            return Ok(result);
        }
        /// DELETE: api/Address/5

        public IHttpActionResult DeleteStudent(int Id)
        {
            try
            {
                var result = studentDAL.DeleteStudent(Id);

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
                Log.writeMessage("StudentController DeleteStudent Error " + ex.Message);
            }
            return Ok("Failed");
        }

        [HttpPost]
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
        }
    }
}