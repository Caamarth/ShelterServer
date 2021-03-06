﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelterApp.Services;
using ShelterApp.Models;
using Microsoft.AspNetCore.Authorization;
using ShelterApp.ViewModels;

namespace ShelterApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    public class StudyController : Controller
    {

        private IStudyService _studyService;
        private IApplyService _applyService;

        public StudyController (IStudyService studyService, IApplyService applyService)
        {
            _studyService = studyService;
            _applyService = applyService;
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

        [HttpGet("application/{id}")]
        public IActionResult GetStudyForApplication(int id)
        {
            var application = _applyService.GetApplication(id);
            if (application == null)
            {
                return NotFound("Nem sikerült megtalálni az igénylést!");
            }

            var studies = _studyService.GetStudiesForApplication(id);
            return Ok(studies);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateStudy([FromBody]CreateStudyModel study)
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

            return Ok(study);
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

            return Ok(id);
        }
    }
}
