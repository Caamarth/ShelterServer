using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelterApp.Services;
using ShelterApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShelterApp.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(Policy = "User")]
    [AllowAnonymous]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<AnimalEntity> GetAnimals()
        {
            var animals = _animalService.getAnimals();
            return animals;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetAnimal(long id)
        {
            var animal = _animalService.getAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }
            return new ObjectResult(animal);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateAnimal([FromBody]AnimalEntity animal)
        {
            if (animal == null)
            {
                return BadRequest();
            }
            _animalService.CreateAnimal(animal);
            return Ok(animal);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(long id, [FromBody]AnimalEntity animal)
        {
            if (animal == null)
            {
                return BadRequest();
            }
            var updatedAnimal = _animalService.getAnimal(id);
            if (updatedAnimal == null)
            {
                return NotFound();
            }
            _animalService.UpdateAnimal(animal);
            return Ok(animal);
            
        }

        [HttpPost("images/{id}")]
        public IActionResult UploadPictures(int id, [FromBody]string[] images)
        {
            if (images == null)
            {
                return BadRequest("No file uploaded");
            }

            foreach (var img in images)
            {
                var imageEntity = new AnimalImages
                {
                    AnimalId = id,
                    AnimalImgs = img
                };
                _animalService.SaveImages(imageEntity);
            }

            return Ok(images);
        }

        [HttpGet("images/{id}")]
        public IActionResult GetImages(int id)
        {
            var images = _animalService.GetAnimalImages(id);
            if (images == null)
            {
                return NotFound("Nem találhatóak képek!");
            }

            return Ok(images);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = _animalService.getAnimal(id);
            if (animal == null)
            {
                return NotFound();
            }
            _animalService.DeleteAnimal(id);
            return Ok(id);
        }
    }
}
