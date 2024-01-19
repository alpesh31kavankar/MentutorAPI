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
        public MainCategory GetMainCategoryById(int MainCategoryId)
        {
            Log.writeMessage("MainCategoryController GetMainCategoryById Start");
            MainCategory mainCategory = null;
            try
            {
                mainCategory = mainCategoryDAL.GetMainCategoryById(MainCategoryId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("MainCategoryController GetMainCategoryById Error " + ex.Message);
            }
            Log.writeMessage("MainCategoryController GetMainCategoryById End");
            return mainCategory;
        }

      
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

        public IHttpActionResult DeleteMainCategory(int MainCategoryId)
        {
            try
            {
                var result = mainCategoryDAL.DeleteMainCategory(MainCategoryId);

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
        public async Task<IHttpActionResult> SaveMainCategoryImage(int MainCategoryId)
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
                    File.WriteAllBytes(theDirectory + "/Content/MainCategory" + "/" + MainCategoryId + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var mainCategory = mainCategoryDAL.GetMainCategoryById(MainCategoryId);
                    var filenamenew = MainCategoryId + "_" + filename;
                    if (mainCategory.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/MainCategory" + "/" + mainCategory.Photo);
                        mainCategory.Photo = MainCategoryId + "_" + filename;
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