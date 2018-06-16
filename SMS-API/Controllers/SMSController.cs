using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Api.Domain;

namespace SMS.Api.Controllers
{
    /// <summary>
    /// Controller for SMS model.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SMSController : Controller
    {
        /// <summary>
        /// Private member of service for \rel SMS model
        /// </summary>
        private readonly ISMSService _smsService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="smsService">Service for SMS model</param>
        public SMSController(ISMSService smsService)
        {
            _smsService = smsService;
        }
        /// <summary>
        /// Method that implements GET Http request.
        /// </summary>
        /// <returns>SMS list in JSON format</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sms = await _smsService.GetAllReadyToSent();

            return Json(sms);
        }

        /// <summary>
        /// Method that implements POST Http request.
        /// </summary>
        /// <param name="request">Data for new object</param>
        /// <returns>response: Created</returns>
        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateSMS request)
        {
            await _smsService.AddNewAsync(request.Message, request.PhoneNumber, new DateTime(1000,10,10));

            return Created("api/SMS", null);
        }

        /// <summary>
        /// Method that implements DELETE Http request.
        /// </summary>
        /// <param name="id">Id of sms'</param>
        /// <returns>response: NoContent</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _smsService.RemoveAsync(Guid.Parse(id));
            return NoContent();
        }
    }

    /// <summary>
    /// Class needed for POST request. Contains data about new object.
    /// </summary>
    public class CreateSMS
    {
        /// <summary>
        /// Text message for sms.
        /// </summary>
        public string Message { get; set; } 
        /// <summary>
        /// Recipient's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }

}