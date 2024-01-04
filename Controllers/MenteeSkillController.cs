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
    public class MenteeSkillController : ApiController
    {
        // GET: MenteeSkill
        public Logger Log = null;
        // GET: MenteeSkill
        public MenteeSkillController()
        {
            Log = Logger.GetLogger();
        }
        MenteeSkillDAL menteeSkillDAL = new MenteeSkillDAL();

        [HttpGet]
        [ActionName("GetAllMenteeSkill")]
        public List<MenteeSkill> GetAllMenteeSkill()
        {
            Log.writeMessage("MenteeSkillController GetAllMenteeSkill Start");
            List<MenteeSkill> list = null;
            try
            {
                list = menteeSkillDAL.GetAllMenteeSkill();
            }
            catch (Exception ex)
            {
                Log.writeMessage("MenteeSkillController GetAllMenteeSkill Error " + ex.Message);
            }
            Log.writeMessage("MenteeSkillController GetAllMenteeSkill End");
            return list;
        }

        [HttpGet]
        [ActionName("GetMenteeSkillById")]
        public MenteeSkill GetMenteeSkillById(int Id)
        {
            Log.writeMessage("MenteeSkillController GetMenteeSkillById Start");
            MenteeSkill menteeSkill = null;
            try
            {
                menteeSkill = menteeSkillDAL.GetMenteeSkillById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("MenteeSkillController GetMenteeSkillById Error " + ex.Message);
            }
            Log.writeMessage("MenteeSkillController GetMenteeSkillById End");
            return menteeSkill;
        }



        [HttpPost]
        [ActionName("AddMenteeSkill")]
        public IHttpActionResult AddMenteeSkill(MenteeSkill menteeSkill)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                menteeSkill.CreatedBy = "Admin";
                menteeSkill.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                menteeSkill.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                menteeSkill.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = menteeSkillDAL.AddMenteeSkill(menteeSkill);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MenteeSkillController AddMenteeSkill Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateMenteeSkill")]
        public IHttpActionResult UpdateMenteeSkill(MenteeSkill menteeSkill)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                menteeSkill.CreatedBy = "Admin";
                menteeSkill.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                menteeSkill.UpdatedBy = "Admin";
                menteeSkill.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = menteeSkillDAL.UpdateMenteeSkill(menteeSkill);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MenteeSkillController AddMenteeSkill Error " + ex.Message);
            }
            return Ok(result);
        }





        // PUT: api/Address/5
        //[HttpPut]
        //[ActionName("UpdateFirstModel")]
        //public IHttpActionResult UpdateFirstModel(FirstModel firstModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        var result = firstDAL.UpdateFirstModel(firstModel);




        //        if (result == "Success")
        //        {
        //            return Ok("Success");
        //        }
        //        else
        //        {
        //            return Ok("Failed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("FirstController UpdateFirstModel Error " + ex.Message);
        //    }
        //    return Ok("Failed");
        //}

        //// DELETE: api/Address/5

        public IHttpActionResult DeleteMenteeSkill(int MenteeSkillId)
        {
            try
            {
                var result = menteeSkillDAL.DeleteMenteeSkill(MenteeSkillId);

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
                Log.writeMessage("MenteeSkillController DeleteMenteeSkill Error " + ex.Message);
            }
            return Ok("Failed");
        }


        // [HttpPost]
        //public async Task<IActionResult> SendMail([FromBody] Email email)
        //{
        //  Console.WriteLine("Sending email");
        //var client = new System.Net.Mail.SmtpClient("smtp.example.com", 111);
        //  client.UseDefaultCredentials = false;
        // client.EnableSsl = true;
        // client.Credentials = new System.Net.NetworkCredential(emailid, password);
        //var mailMessage = new System.Net.Mail.MailMessage();
        //mailMessage.From = new System.Net.Mail.MailAddress(senderemail);
        //mailMessage.To.Add(email.To);
        // mailMessage.Body = email.Text;
        // await client.SendMailAsync(mailMessage);
        //return Ok();
        //}


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
    }
}