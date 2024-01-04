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
    public class UserDetailController : ApiController
    {
        // GET: UserDetail
        public Logger Log = null;
        public UserDetailController()
        {
            Log = Logger.GetLogger();
        }

        UserDetailDAL userDetailDAL = new UserDetailDAL();

        [HttpGet]
        [ActionName("GetAllUserDetail")]
        public List<UserDetail> GetAllUserDetail()
        {
            Log.writeMessage("UserDetailController GetAllUserDetail Start");
            List<UserDetail> list = null;
            try
            {
                list = userDetailDAL.GetAllUserDetail();
            }
            catch (Exception ex)
            {
                Log.writeMessage("UserDetailController GetAllUserDetail Error " + ex.Message);
            }
            Log.writeMessage("UserDetailController GetAllUserDetail End");
            return list;
        }

        [HttpGet]
        [ActionName("GetUserDetailById")]
        public UserDetail GetUserDetailById(int Id)
        {
            Log.writeMessage("UserDetailController GetUserDetailById Start");
            UserDetail userDetail = null;
            try
            {
                userDetail = userDetailDAL.GetUserDetailById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("UserDetailController GetUserDetailById Error " + ex.Message);
            }
            Log.writeMessage("UserDetailController GetUserDetailById End");
            return userDetail;
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
        [ActionName("AddUserDetail")]
        public IHttpActionResult AddUserDetail(UserDetail userDetail)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                userDetail.CreatedBy = "Admin";
                userDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                userDetail.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                userDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = userDetailDAL.AddUserDetail(userDetail);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("UserDetailController AddUserDetail Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateUserDetail")]
        public IHttpActionResult UpdateUserDetail(UserDetail userDetail)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                userDetail.CreatedBy = "Admin";
                userDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                userDetail.UpdatedBy = "Admin";
                userDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = userDetailDAL.UpdateUserDetail(userDetail);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("UserDetailController AddUserDetail Error " + ex.Message);
            }
            return Ok(result);
        }
        /// DELETE: api/Address/5

        public IHttpActionResult DeleteMainCategory(int Id)
        {
            try
            {
                var result = userDetailDAL.DeleteUserDetail(Id);

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
                Log.writeMessage("UserDetailController DeleteUserDetail Error " + ex.Message);
            }
            return Ok("Failed");
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveMainCategoryImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/UserDetail" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var userDetail = userDetailDAL.GetuserDetailById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (userDetail.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/UserDetail" + "/" + userDetail.Photo);
                        userDetail.Photo = Id + "_" + filename;
                        var result = userDetailDAL.UpdateUserDetail(userDetail);

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