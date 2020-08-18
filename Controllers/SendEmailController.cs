using System;
using ApiEmails.Domain;
using ApiEmails.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiEmails.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendEmailController : ControllerBase
    {
        private readonly ILogger<SendEmailController> _logger;
        private readonly ISendEmailAppService _appService;

        public SendEmailController(ILogger<SendEmailController> logger, ISendEmailAppService appService)
        {
            _logger = logger;
            _appService = appService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] 
        public IActionResult SendEmail([FromBody]EmailViewModel email)
        {          
            if (!email.IsValid().Item1) return BadRequest(email.IsValid().Item2);

            _appService.SendEmail(email);

            return Ok("E-mail enviado com sucesso");
        }

        [HttpGet]
        public IActionResult GetDate() => Ok(DateTime.Now.ToString());        
    }
}
