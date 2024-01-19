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
using System.Net.Mail;

namespace PrismAPI.Controllers
{
    public class RegistrationController : ApiController
    {
        // GET: Registration
        public Logger Log = null;
        public RegistrationController()
        {
            Log = Logger.GetLogger();
        }
        RegistrationDAL registrationDAL = new RegistrationDAL();

        [HttpGet]
        [ActionName("GetAllRegistration")]

        public List<Registration> GetAllRegistration()
        {
            Log.writeMessage("RegistrationController GetAllRegistration Start");
            List<Registration> list = null;
            try
            {
                list = registrationDAL.GetAllRegistration();
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetAllRegistration Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetAllRegistration End");
            return list;

        }

        [HttpPost]
        [ActionName("AddRegistration")]
        public IHttpActionResult AddRegistration(Registration registration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                registration.CreatedBy = "Admin";
                registration.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                registration.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                registration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = registrationDAL.AddRegistration(registration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController AddRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateRegistration")]
        public IHttpActionResult UpdateRegistration(Registration registration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                registration.CreatedBy = "Admin";
                registration.UpdatedBy = "Admin";
                registration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = registrationDAL.UpdateRegistration(registration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController AddRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetRegistrationById")]
        public Registration GetRegistrationById(int RegistrationId)
        {
            Log.writeMessage("RegistrationController GetRegistrationById Start");
            Registration registration = null;
            try
            {
                registration = registrationDAL.GetRegistrationById(RegistrationId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationById End");
            return registration;
        }

        [HttpGet]
        [ActionName("GetRegistrationByEmail")]
        public Registration GetRegistrationByEmail(string Email)
        {
            Log.writeMessage("RegistrationController GetRegistrationByEmail Start");
            Registration registration = null;
            try
            {
                registration = registrationDAL.GetRegistrationByEmail(Email);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationByEmail Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationByEmail End");
            return registration;
        }

        [HttpGet]
        [ActionName("Login")]
        public Login Login(string Email, string Password)
        {
            Log.writeMessage("RegistrationController GetRegistrationById Start");
            Login user = null;
            try
            {
                user = registrationDAL.Login(Email, Password);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationById End");
            return user;
        }


        [HttpPost]
        [ActionName("SendOTPEmail")]
        public IHttpActionResult SendOTPEmail(string Email)
        {
            Log.writeMessage("RegistrationController GetRegistrationById Start");

            try
            {
                // string fromEmail = "your-email@example.com"; // Replace with your email address
                //string fromEmailPassword = "your-password"; // Replace with your email password

                var smtpClient = new SmtpClient("smtp.gmail.com") // Replace with your SMTP server
                {
                    Port = 587, // Gmail uses port 587 for TLS
                    Credentials = new NetworkCredential("testsumit19@gmail.com", "dyld bnbm auks eopc"), // Replace with your Gmail email and password
                    EnableSsl = true,
                };


                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("testsumit19@gmail.com.com");
                mailMessage.To.Add(Email);
                mailMessage.Subject = "Your OTP Code";

                // Generate a 6-digit random OTP
                Random random = new Random();
                int otpValue = random.Next(100000, 999999);
                string otp = otpValue.ToString();

                mailMessage.Body = "Your OTP Code is: " + otp;

                smtpClient.Send(mailMessage);
                return Ok(new { otp });
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                Log.writeMessage("Error sending email: " + ex.Message);
                return BadRequest("Failed to send email: " + ex.Message);
            }
        }


        public IHttpActionResult DeleteRegistration(int RegistrationId)
        {
            try
            {
                var result = registrationDAL.DeleteRegistration(RegistrationId);

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
                Log.writeMessage("RegistrationController DeleteRegistration Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}