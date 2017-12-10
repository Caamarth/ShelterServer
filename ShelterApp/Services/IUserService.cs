﻿using ShelterApp.Models;
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
    }
}