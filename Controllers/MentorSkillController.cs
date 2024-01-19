
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
    public class MentorSkillController : ApiController
    {
        // GET: MentorSkill
        public Logger Log = null;
        public MentorSkillController()
        {
            Log = Logger.GetLogger();
        }

        MentorSkillDAL mentorSkillDAL = new MentorSkillDAL();

        [HttpGet]
        [ActionName("GetAllMentorSkill")]
        public List<MentorSkill> GetAllMentorSkill()
        {
            Log.writeMessage("MentorSkillController GetAllMentorSkill Start");
            List<MentorSkill> list = null;
            try
            {
                list = mentorSkillDAL.GetAllMentorSkill();
            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorSkillController GetAllMentorSkill Error " + ex.Message);
            }
            Log.writeMessage("MentorSkillController GetAllMentorSkill End");
            return list;
        }

        [HttpGet]
        [ActionName("GetMentorSkillById")]
        public MentorSkill GetMentorSkillById(int MentorSkillId)
        {
            Log.writeMessage("MentorSkillController GetMentorSkillById Start");
            MentorSkill mentorSkill = null;
            try
            {
                mentorSkill = mentorSkillDAL.GetMentorSkillById(MentorSkillId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorSkillController GetMentorSkillById Error " + ex.Message);
            }
            Log.writeMessage("MentorSkillController GetMentorSkillById End");
            return mentorSkill;
        }

        //[HttpGet]
        //[ActionName("GetMentorSkillByEmail")]
        //public MentorSkill GetMentorSkillByEmail(string Email)
        //{
        //    Log.writeMessage("LoginCodeController GetLoginCodeByEmail Start");
        //    LoginCode loginCode = null;
        //    try
        //    {
        //        loginCode = loginCodeDAL.GetLoginCodeByEmail(Email);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("LoginCodeController GetLoginCodeByEmail Error " + ex.Message);
        //    }
        //    Log.writeMessage("LoginCodeController GetLoginCodeByEmail End");
        //    return loginCode;
        //}

        [HttpPost]
        [ActionName("AddMentorSkill")]
        public IHttpActionResult AddMentorSkill(MentorSkill mentorSkill)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                mentorSkill.CreatedBy = "Admin";
                mentorSkill.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                mentorSkill.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                mentorSkill.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = mentorSkillDAL.AddMentorSkill(mentorSkill);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorSkillController AddMentorSkill Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateMentorSkill")]
        public IHttpActionResult UpdateMentorSkill(MentorSkill mentorSkill)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                mentorSkill.CreatedBy = "Admin";
                mentorSkill.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                mentorSkill.UpdatedBy = "Admin";
                mentorSkill.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = mentorSkillDAL.UpdateMentorSkill(mentorSkill);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorSkillController AddMentorSkill Error " + ex.Message);
            }
            return Ok(result);
        }


        //[HttpGet]
        //[ActionName("Login")]
        //public Loginc Loginc(string Email, string Password)
        //{
        //    Log.writeMessage("LoginCodeController GetLoginCodeById Start");
        //    Loginc user = null;
        //    try
        //    {
        //        user = loginCodeDAL.Loginc(Email, Password);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("LoginCodeController GetLoginCodeById Error " + ex.Message);
        //    }
        //    Log.writeMessage("LoginCodeController GetLoginCodeById End");
        //    return user;
        //}

        //[HttpGet]
        //[ActionName("OtpNo")]
        //public OtpNo OtpNo(string Mobile)
        //{
        //    Log.writeMessage("LoginCodeController GetLoginCodeById Start");
        //    OtpNo OtpNo = null;
        //    try
        //    {
        //        OtpNo = loginCodeDAL.OtpNo(Mobile);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("LoginCodeController GetLoginCodeById Error " + ex.Message);
        //    }
        //    Log.writeMessage("LoginCodeController GetLoginCodeById End");
        //    return OtpNo;
        //}
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

        public IHttpActionResult DeleteMentorSkill(int MentorSkillId)
        {
            try
            {
                var result = mentorSkillDAL.DeleteMentorSkill(MentorSkillId);

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
                Log.writeMessage("MentorSkillController DeleteMentorSkill Error " + ex.Message);
            }
            return Ok("Failed");
        }


        //[HttpPost]
        //public async Task<IActionResult> SendMail([FromBody] Email email)
        //{
        //    Console.WriteLine("Sending email");
        //    var client = new System.Net.Mail.SmtpClient("smtp.example.com", 111);
        //    client.UseDefaultCredentials = false;
        //    client.EnableSsl = true;
        //    client.Credentials = new System.Net.NetworkCredential(emailid, password);
        //    var mailMessage = new System.Net.Mail.MailMessage();
        //    mailMessage.From = new System.Net.Mail.MailAddress(senderemail);
        //    mailMessage.To.Add(email.To);
        //    mailMessage.Body = email.Text;
        //    await client.SendMailAsync(mailMessage);
        //    return Ok();
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


        //[HttpPost]
        //public async Task<IHttpActionResult> SaveLoginCodeImage(int Id)
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
        //            File.WriteAllBytes(theDirectory + "/Content/LoginCode" + "/" + Id + "_" + filename, buffer);
        //            //Do whatever you want with filename and its binary data.

        //            // get existing rocrd
        //            var loginCode = loginCodeDAL.GetLoginCodeById(Id);
        //            var filenamenew = Id + "_" + filename;
        //            if (loginCode.Photo.ToLower() != filenamenew.ToLower())
        //            {
        //                File.Delete(theDirectory + "/Content/LoginCode" + "/" + loginCode.Photo);
        //                loginCode.Photo = Id + "_" + filename;
        //                var result = loginCodeDAL.UpdateLoginCode(loginCode);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }

        //    return Ok();
        //}
    }
}