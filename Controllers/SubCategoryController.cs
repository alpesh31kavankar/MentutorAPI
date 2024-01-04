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
    public class SubCategoryController : ApiController
    {
        // GET: SubCategory
        public Logger Log = null;
        public SubCategoryController()
        {
            Log = Logger.GetLogger();
        }

        SubCategoryDAL subCategoryDAL = new SubCategoryDAL();

        [HttpGet]
        [ActionName("GetAllSubCategory")]
        public List<SubCategory> GetAllSubCategory()
        {
            Log.writeMessage("SubCategoryController GetAllSubCategory Start");
            List<SubCategory> list = null;
            try
            {
                list = subCategoryDAL.GetAllSubCategory();
            }
            catch (Exception ex)
            {
                Log.writeMessage("SubCategoryController GetAllSubCategory Error " + ex.Message);
            }
            Log.writeMessage("SubCategoryController GetAllSubCategory End");
            return list;
        }

        [HttpGet]
        [ActionName("GetSubCategoryById")]
        public SubCategory GetSubCategoryById(int Id)
        {
            Log.writeMessage("SubCategoryController GetSubCategoryById Start");
            SubCategory subCategory = null;
            try
            {
                subCategory = subCategoryDAL.GetSubCategoryById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("SubCategoryController GetSubCategoryById Error " + ex.Message);
            }
            Log.writeMessage("SubCategoryController GetSubCategoryById End");
            return subCategory;
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
        [ActionName("AddSubCategory")]
        public IHttpActionResult AddSubCategory(SubCategory subCategory)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                subCategory.CreatedBy = "Admin";
                subCategory.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                subCategory.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                subCategory.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = subCategoryDAL.AddSubCategory(subCategory);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SubCategoryController AddSubCategory Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateSubCategory")]
        public IHttpActionResult UpdateSubCategory(SubCategory subCategory)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                subCategory.CreatedBy = "Admin";
                subCategory.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                subCategory.UpdatedBy = "Admin";
                subCategory.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = subCategoryDAL.UpdateSubCategory(subCategory);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SubCategoryController AddSubCategory Error " + ex.Message);
            }
            return Ok(result);
        }
        /// DELETE: api/Address/5

        public IHttpActionResult DeleteMainCategory(int Id)
        {
            try
            {
                var result = subCategoryDAL.DeleteSubCategory(Id);

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
                Log.writeMessage("SubCategoryController DeleteSubCategory Error " + ex.Message);
            }
            return Ok("Failed");
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveSubCategoryImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/SubCategory" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var subCategory = subCategoryDAL.GetSubCategoryById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (subCategory.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/SubCategory" + "/" + subCategory.Photo);
                        subCategory.Photo = Id + "_" + filename;
                        var result = subCategoryDAL.UpdateSubCategory(subCategory);

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