﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelterApp.Models;
using ShelterApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace ShelterApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Policy = "User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserEntity> GetUsers()
        {
            var users = _userService.getUsers();
            return users;
        }


        [HttpGet("{id}")]
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
        public IActionResult CreateUser([FromBody]UserEntity user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _userService.createUser(user);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            var user = _userService.getUser(id);
            if(user == null)
            {
                return NotFound();
            }

            _userService.deleteUser(user);

            return Ok();
        }
    }
}
