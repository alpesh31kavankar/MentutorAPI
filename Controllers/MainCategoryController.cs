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
    public class MainCategoryController : ApiController
    {
        // GET: MainCategory
        public Logger Log = null;
        public MainCategoryController()
        {
            Log = Logger.GetLogger();
        }

        MainCategoryDAL mainCategoryDAL = new MainCategoryDAL();

        [HttpGet]
        [ActionName("GetAllMainCategory")]
        public List<MainCategory> GetAllMainCategory()
        {
            Log.writeMessage("MainCategoryController GetAllMainCategory Start");
            List<MainCategory> list = null;
            try
            {
                list = mainCategoryDAL.GetAllMainCategory();
            }
            catch (Exception ex)
            {
                Log.writeMessage("MainCategoryController GetAllMainCategory Error " + ex.Message);
            }
            Log.writeMessage("MainCategoryController GetAllMainCategory End");
            return list;
        }

        [HttpGet]
        [ActionName("GetMainCategoryById")]
        public MainCategory GetMainCategoryById(int Id)
        {
            Log.writeMessage("MainCategoryController GetMainCategoryById Start");
            MainCategory mainCategory = null;
            try
            {
                mainCategory = mainCategoryDAL.GetMainCategoryById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("MainCategoryController GetMainCategoryById Error " + ex.Message);
            }
            Log.writeMessage("MainCategoryController GetMainCategoryById End");
            return mainCategory;
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
        [ActionName("AddMainCategory")]
        public IHttpActionResult AddMainCategory(MainCategory mainCategory)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                mainCategory.CreatedBy = "Admin";
                mainCategory.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                mainCategory.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                mainCategory.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = mainCategoryDAL.AddMainCategory(mainCategory);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MainCategoryController AddMainCategory Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateMainCategory")]
        public IHttpActionResult UpdateMainCategory(MainCategory mainCategory)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                mainCategory.CreatedBy = "Admin";
                mainCategory.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                mainCategory.UpdatedBy = "Admin";
                mainCategory.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = mainCategoryDAL.UpdateMainCategory(mainCategory);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MainCategoryController AddMainCategory Error " + ex.Message);
            }
            return Ok(result);
        }
        /// DELETE: api/Address/5

        public IHttpActionResult DeleteMainCategory(int Id)
        {
            try
            {
                var result = mainCategoryDAL.DeleteMainCategory(Id);

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
                Log.writeMessage("MainCategoryController DeleteMainCategory Error " + ex.Message);
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
                    File.WriteAllBytes(theDirectory + "/Content/MainCategory" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var mainCategory = mainCategoryDAL.GetMainCategoryById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (mainCategory.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/MainCategory" + "/" + mainCategory.Photo);
                        mainCategory.Photo = Id + "_" + filename;
                        var result = mainCategoryDAL.UpdateMainCategory(mainCategory);

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