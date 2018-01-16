using ShelterApp.Models;
using ShelterApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.Services
{
    public interface IUserService
    {
        IEnumerable<UserEntity> getUsers();
        UserEntity getUser(long id);
        void createUser(UserEntity user);
        void updateUser(long id, UserEntity user);
        void deleteUser(UserEntity user);
        UserEntity getUserByName(string username);
        void registerUser(RegisterModel model);
    }
}
