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
    [Route("api/SMS")]
    public class SMSController : Controller
    {
        private readonly ISMSService _smsService;

        public SMSController()
        {
            _smsService = new SMSService(new InMemeorySMSRepository());
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sms = await _smsService.GetAllReadyToSent();

            return Json(sms);
        }

    }
}