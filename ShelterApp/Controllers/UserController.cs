using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelterApp.Models;
using ShelterApp.Services;
using Microsoft.AspNetCore.Authorization;
using ShelterApp.ViewModels;

namespace ShelterApp.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Policy = "User")]
        public IEnumerable<UserEntity> GetUsers()
        {
            var users = _userService.getUsers();
            return users;
        }


        [HttpGet("{id}")]
        [Authorize(Policy = "User")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.getUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "User")]
        public IActionResult UpdateUser(long id, [FromBody]UserEntity user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var updatedUser = _userService.getUser(id);
            if (updatedUser == null)
            {
                return NotFound();
            }
            _userService.updateUser(id, user);
            return Ok(user);
        }

        [HttpPost]
        [Authorize(Policy = "User")]
        public IActionResult CreateUser([FromBody]UserEntity user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _userService.createUser(user);

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegisterUser([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _userService.registerUser(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "User")]
        public IActionResult DeleteUser(long id)
        {
            var user = _userService.getUser(id);
            if(user == null)
            {
                return NotFound();
            }

            _userService.deleteUser(user);

            return Ok(user);
        }
    }
}
