using ShelterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.ViewModels
{
    public class LoginResponseModel
    {
        public UserEntity User { get; set; }
        public string Token { get; set; }
    }
}
