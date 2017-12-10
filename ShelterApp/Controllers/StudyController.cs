using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelterApp.Services;
using ShelterApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShelterApp.Controllers
{
    [Route("api/[controller]")]
    public class StudyController : Controller
    {

        private IStudyService _studyService;

        public StudyController (IStudyService studyService)
        {
            _studyService = studyService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Study> GetStudies()
        {
            var studies = _studyService.GetStudies();
            return studies;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetStudy(int id)
        {
            var study = _studyService.GetStudy(id);
            if (study == null)
            {
                return NotFound();
            }
            return new ObjectResult(study);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateStudy([FromBody]Study study)
        {
            if (study == null)
            {
                return BadRequest();
            }
            _studyService.CreateStudy(study);

            return Ok(study);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult UpdateStudy(int id, [FromBody]Study study)
        {
            var updateStudy = _studyService.GetStudy(id);
            if (updateStudy == null)
            {
                return NotFound();
            }
            if (study == null)
            {
                return BadRequest();
            }
            _studyService.UpdateStudy(id, study);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStudy(int id)
        {
            var study = _studyService.GetStudy(id);
            if (study == null)
            {
                return NotFound();
            }
            _studyService.DeleteStudy(id);

            return Ok();
        }
    }
}
