using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScoringAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ScoringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoringController : ControllerBase
    {
        private readonly ILogger _logger;
        public ScoringController(ILogger<ScoringController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Application>> DefineStatus(Application application)
        {
            application.ScoringStatus = await ProcessImitation(1000);
            application.ScoringDate = DateTime.Now;
            return Ok(application);
            /*try
            {
                
            }
            finally
            {
                Response.OnCompleted(async () =>
                {
                    bool result = await ProcessImitation(2000);
                    application.ScoringStatus = result;
                    return Ok(application);
                });
            }*/
        }
        private async Task<bool> ProcessImitation(int timeoutValue)
        {
            //Thread.Sleep(timeoutValue);
            await Task.Delay(timeoutValue);
            var random = new Random();
            return (bool)(random.Next(2) == 1);
        }
    }
}
