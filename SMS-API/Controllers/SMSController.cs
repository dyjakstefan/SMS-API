using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.Api.Domain;

namespace SMS.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SMSController : Controller
    {
        private readonly ISMSService _smsService;

        public SMSController(ISMSService smsService)
        {
            _smsService = smsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sms = await _smsService.GetAllReadyToSent();

            return Json(sms);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateSMS request)
        {
            await _smsService.AddNewAsync(request.Message, request.PhoneNumber, new DateTime(1000,10,10));

            return Created("api/SMS", null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _smsService.RemoveAsync(Guid.Parse(id));
            return NoContent();
        }
    }

    public class CreateSMS
    {
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
    }

}