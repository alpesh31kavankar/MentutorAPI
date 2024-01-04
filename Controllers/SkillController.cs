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
    public class SkillController : ApiController
    {
        // GET: Skill
        public Logger Log = null;
        public SkillController()
        {
            Log = Logger.GetLogger();
        }

        SkillDAL skillDAL = new SkillDAL();

        [HttpGet]
        [ActionName("GetAllSkill")]
        public List<Skill> GetAllSkill()
        {
            Log.writeMessage("SkillController GetAllSkill Start");
            List<Skill> list = null;
            try
            {
                list = skillDAL.GetAllSkill();
            }
            catch (Exception ex)
            {
                Log.writeMessage("SkillController GetAllSkill Error " + ex.Message);
            }
            Log.writeMessage("SkillController GetAllSkill End");
            return list;
        }

        [HttpGet]
        [ActionName("GetSkillById")]
        public Skill GetSkillById(int Id)
        {
            Log.writeMessage("SkillController GetSkillById Start");
            Skill skill = null;
            try
            {
                skill = skillDAL.GetSkillById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("SkillController GetSkillById Error " + ex.Message);
            }
            Log.writeMessage("SkillController GetSkillById End");
            return skill;
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
        [ActionName("AddSkill")]
        public IHttpActionResult AddSkill(Skill skill)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                skill.CreatedBy = "Admin";
                skill.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                skill.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                skill.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = skillDAL.AddSkill(skill);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SkillController AddSkill Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateSkill")]
        public IHttpActionResult UpdateMSkill(Skill skill)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                skill.CreatedBy = "Admin";
                skill.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                skill.UpdatedBy = "Admin";
                skill.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = skillDAL.UpdateSkill(skill);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SkillController AddSkill Error " + ex.Message);
            }
            return Ok(result);
        }
        /// DELETE: api/Address/5

        public IHttpActionResult DeleteMainCategory(int Id)
        {
            try
            {
                var result = skillDAL.DeleteSkill(Id);

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
                Log.writeMessage("SkillController DeleteSkill Error " + ex.Message);
            }
            return Ok("Failed");
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveSkillImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/Skill" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var skill = skillDAL.GetSkillById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (skill.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Skill" + "/" + skill.Photo);
                        skill.Photo = Id + "_" + filename;
                        var result = skillDAL.UpdateSkill(skill);

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