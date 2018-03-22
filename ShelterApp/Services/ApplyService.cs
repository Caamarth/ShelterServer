using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShelterApp.Models;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace ShelterApp.Services
{
    public class ApplyService : IApplyService
    {
        private EntityContext _entityContext;

        public ApplyService(EntityContext entityContext)
        {
            _entityContext = entityContext;
            if (!_entityContext.Applications.Any())
            {
                _entityContext.Applications.Add(new Apply
                {
                    PublishDate = DateTime.Parse("2017-12-05"),
                    ApplyStatus = Enums.Status.SentIn,
                    UserEntityId = _entityContext.Users.FirstOrDefault(x => x.Id == 1).Id,
                    AnimalEntityId = _entityContext.Animals.FirstOrDefault(x => x.Id == 1).Id
                });
                _entityContext.SaveChanges();
            }
        }
        public void CreateApplication(Apply application)
        {
            if (application != null)
            {
                _entityContext.Applications.Add(application);
                _entityContext.SaveChanges();
            }
        }

        public void DeleteApplication(int id)
        {
            var application = _entityContext.Applications.FirstOrDefault(x => x.Id == id);
            if (application != null)
            {
                _entityContext.Applications.Remove(application);
                _entityContext.SaveChanges();
            }
        }

        public Apply GetApplication(int id)
        {
            var application = _entityContext.Applications.FirstOrDefault(x => x.Id == id);

            application.Studies = _entityContext.Studies
                .Where(x => x.ApplyId == id).ToList();

            application.UserEntity = _entityContext.Users
                .Where(x => x.Id == application.UserEntityId).FirstOrDefault();

            application.AnimalEntity = _entityContext.Animals
                .FirstOrDefault(x => x.Id == application.AnimalEntityId);

            return application;
                
        }

        public IEnumerable<Apply> GetApplications()
        {
            return _entityContext.Applications
                .Include(apply => apply.Studies)
                .Include(apply => apply.UserEntity)
                .Include(apply => apply.AnimalEntity);
        }

        public IEnumerable<Apply> GetApplicationsForUser(int id)
        {
            return _entityContext.Applications.Where(x => x.UserEntityId == id)
               .Include(apply => apply.Studies)
               .Include(apply => apply.UserEntity)
               .Include(apply => apply.AnimalEntity);
        }

        public void UpdateApplicaton(int id, Apply application)
        {
            var apply = _entityContext.Applications.FirstOrDefault(x => x.Id == id);
            if (apply != null)
            {
                apply.Studies = application.Studies;
                apply.PublishDate = application.PublishDate;
                apply.ApplyStatus = application.ApplyStatus;
                apply.UserEntityId = application.UserEntityId;
                apply.AnimalEntityId = application.AnimalEntityId;
            }
            _entityContext.Applications.Update(apply);
            _entityContext.SaveChanges();
        }
    }
}
