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
    public class MentorPlanController : ApiController
    {
        // GET: MentorPlan
        public Logger Log = null;
        public MentorPlanController()
        {
            Log = Logger.GetLogger();
        }
        MentorPlanDAL mentorPlanDAL = new MentorPlanDAL();

        [HttpGet]
        [ActionName("GetAllMentorPlan")]

        public List<MentorPlan> GetAllMentorPlan()
        {
            Log.writeMessage("MentorPlanController GetAllMentorPlan Start");
            List<MentorPlan> list = null;
            try
            {
                list = mentorPlanDAL.GetAllMentorPlan();
            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorPlanController GetAllMentorPlan Error " + ex.Message);
            }
            Log.writeMessage("MentorPlanController GetAllMentorPlan End");
            return list;

        }

        [HttpPost]
        [ActionName("AddMentorPlan")]
        public IHttpActionResult AddMentorPlan(MentorPlan mentorPlan)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                mentorPlan.CreatedBy = "Admin";
                mentorPlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                mentorPlan.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                mentorPlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = mentorPlanDAL.AddMentorPlan(mentorPlan);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorPlanController AddMentorPlan Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateMentorPlan")]
        public IHttpActionResult UpdateMentorPlan(MentorPlan mentorPlan)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                mentorPlan.CreatedBy = "Admin";
                mentorPlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                mentorPlan.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                mentorPlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = mentorPlanDAL.UpdateMentorPlan(mentorPlan);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MentorPlanController UpdateMentorPlan Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetMentorPlanById")]
        public MentorPlan GetMentorPlanById(int MentorPlanId)
        {
            Log.writeMessage("GetMentorPlanController GetMentorPlanById Start");
            MentorPlan mentorPlan = null;
            try
            {
                mentorPlan = mentorPlanDAL.GetMentorPlanById(MentorPlanId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetMentorPlanController GetMentorPlanById Error " + ex.Message);
            }
            Log.writeMessage("GetMentorPlanController GetMentorPlanById End");
            return mentorPlan;
        }
        public IHttpActionResult DeleteMentorPlan(int MentorPlanId)
        {
            try
            {
                var result = mentorPlanDAL.DeleteMentorPlan(MentorPlanId);

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
                Log.writeMessage("MentorPlanController DeleteMentorPlan Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}