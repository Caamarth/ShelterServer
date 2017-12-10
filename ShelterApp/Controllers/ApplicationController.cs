using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelterApp.Models;
using ShelterApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShelterApp.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        private IApplyService _applyService;

        public ApplicationController(IApplyService applyService)
        {
            _applyService = applyService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Apply> GetApplications()
        {
            var applications = _applyService.GetApplications();
            return applications;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetApplication(int id)
        {
            var application = _applyService.GetApplication(id);
            if (application == null)
            {
                return NotFound();
            }
            return new ObjectResult(application);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateApplication([FromBody]Apply application)
        {
            if (application == null)
            {
                return BadRequest();
            }
            _applyService.CreateApplication(application);
            return Ok(application);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult UpdateApplication(int id, [FromBody]Apply application)
        {
            var updateApplication = _applyService.GetApplication(id);
            if (updateApplication == null)
            {
                return NotFound();
            }
            _applyService.UpdateApplicaton(id, application);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var application = _applyService.GetApplication(id);
            if (application == null)
            {
                return NotFound();
            }
            _applyService.DeleteApplication(id);
            return Ok();
        }
    }
}
