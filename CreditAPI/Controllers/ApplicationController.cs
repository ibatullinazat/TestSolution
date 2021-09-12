using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditAPI.Models;
using CreditAPI.Repositories;
using CreditAPI.Dtos;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Net;
using Microsoft.Extensions.Logging;

namespace CreditAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IRepository _applicationRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _clientFactory;
        public ApplicationController(IRepository applicationRepository, IMapper mapper, IConfiguration configuration, ILogger<ApplicationController> logger, IHttpClientFactory clientFactory)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            var applications = await _applicationRepository.GetAll();
            return Ok(applications);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            var application = await _applicationRepository.Get(id);
            if (application == null)
                return NotFound();

            return Ok(application);
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationCreateResultDto>> CreateApplication(ApplicationDto createApplicationDto)
        {
            if (createApplicationDto == null)
            {
                return BadRequest();
            }
            Application toAdd = _mapper.Map<Application>(createApplicationDto);
            try
            {
                await _applicationRepository.Add(toAdd);
                return Ok(_mapper.Map<ApplicationCreateResultDto>(toAdd));
            }
            finally
            {
                Response.OnCompleted(async () =>
                {
                    var client = _clientFactory.CreateClient("Scoring");
                    var response = await client.PostAsync("api/Scoring", new StringContent(JsonSerializer.Serialize(_mapper.Map<ApplicationStatusDto>(toAdd)), UnicodeEncoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        var applStatusDto = JsonSerializer.Deserialize<ApplicationStatusDto>(response.Content.ReadAsStringAsync().Result);
                        toAdd = _mapper.Map<Application>(applStatusDto);
                        toAdd.ScoringStatus = applStatusDto.ScoringStatus;
                        toAdd.ScoringDate = applStatusDto.ScoringDate;
                        await _applicationRepository.Update(toAdd);
                    }
                });
            }
            //return CreatedAtAction(nameof(toAdd), new { id = toAdd.Id }, createApplicationDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApplication(int id)
        {
            await _applicationRepository.Delete(id);
            return Ok();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateApplication(int id, ApplicationDto updatepApplicationDto)
        {
            Application application = new Application();
            await _applicationRepository.Update(application);
            return Ok();
        }
        
    }
}
