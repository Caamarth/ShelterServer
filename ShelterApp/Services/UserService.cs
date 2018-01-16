using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShelterApp.Models;
using Microsoft.EntityFrameworkCore;
using ShelterApp.ViewModels;

namespace ShelterApp.Services
{
    public class UserService : IUserService
    {
        private EntityContext _entityContext;

        public UserService(EntityContext entityContext)
        {
            _entityContext = entityContext;

            if (!_entityContext.Users.Any())
            {
                _entityContext.Users.Add(new UserEntity
                {
                    Username = "Superadmin",
                    Password = "Ebv3fv.",
                    Firstname = "Super",
                    Lastname = "Admin",
                    Birthdate = DateTime.Parse("1990-07-29"),
                    Address = "4400 Nyíregyháza, Fazekas J. tér 20. fszt/4.",
                    EmailAddress = "superadmin@test.hu",
                    PhoneNumber = "30/511-6309",
                    Role = "Admin"
                });
                _entityContext.SaveChanges();
            }
        }

        public void createUser(UserEntity user)
        {
            _entityContext.Users.Add(user);
            _entityContext.SaveChanges();
        }

        public void registerUser(RegisterModel model)
        {
            var user = new UserEntity
            {
                Username = model.Username,
                Password = model.Password
            };
            _entityContext.Users.Add(user);
            _entityContext.SaveChanges();
        }

        public void deleteUser(UserEntity user)
        {
            _entityContext.Remove(user);
            _entityContext.SaveChanges();

        }

        public UserEntity getUser(long id)
        {
            var user = _entityContext.Users.FirstOrDefault(x => x.Id == id);

            user.Applies = _entityContext.Applications.Where(x => x.UserEntityId == id).ToList();

            return user;
            
        }

        public IEnumerable<UserEntity> getUsers()
        {
            return _entityContext.Users
                .Include(user => user.Applies);
        }

        public void updateUser(long id, UserEntity user)
        {

            var todo = _entityContext.Users.FirstOrDefault(t => t.Id == id);

            if (todo != null)
            {
                todo.Username = user.Username;
                todo.Password = user.Password;
                todo.Firstname = user.Firstname;
                todo.Password = user.Password;
                todo.EmailAddress = user.EmailAddress;
                todo.Birthdate = user.Birthdate;
                todo.PhoneNumber = user.PhoneNumber;
                todo.Role = user.Role;

                _entityContext.Users.Update(todo);
                _entityContext.SaveChanges();
            }
        }

        public UserEntity getUserByName(string username)
        {
            var user = _entityContext.Users.FirstOrDefault(t => t.Username == username);
            return user;
        }
    }
}
