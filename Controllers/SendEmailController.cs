using System;
using ApiEmails.Domain;
using ApiEmails.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public IActionResult SendEmail(EmailViewModel email)
        {
            try
            {
                _appService.SendEmail(email);

                return Ok("E-mail enviado com sucesso");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetDate() => Ok(DateTime.Now.ToString());        
    }
}
