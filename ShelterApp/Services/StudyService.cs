using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShelterApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ShelterApp.Services
{
    public class StudyService : IStudyService
    {
        private readonly EntityContext _entityContext;

        public StudyService(EntityContext entityContext)
        {
            _entityContext = entityContext;

            if (!_entityContext.Studies.Any())
            {
                _entityContext.Studies.Add(new Study
                {
                    Title = "Első környezettanulmány",
                    PublishDate = DateTime.Parse("2017-12-01"),
                    Description = "Teszt környezettanulmány adat",
                    Rating = 9.2,
                    ApplyId = _entityContext.Applications.FirstOrDefault(x => x.Id == 1).Id
                });
                _entityContext.SaveChanges();
            }

        }

        public void CreateStudy(Study study)
        {
            if (study != null)
            {
                _entityContext.Studies.Add(study);
                _entityContext.SaveChanges();
            }
        }

        public void DeleteStudy(long id)
        {
            var study = _entityContext.Studies.FirstOrDefault(x => x.Id == id);
            if (study != null)
            {
                _entityContext.Studies.Remove(study);
                _entityContext.SaveChanges();
            }
        }

        public IEnumerable<Study> GetStudies()
        {
            return _entityContext.Studies.Include(
                study => study.Apply);
        }

        public Study GetStudy(long id)
        {
            var study = _entityContext.Studies.FirstOrDefault(x => x.Id == id);

            study.Apply = _entityContext.Applications.FirstOrDefault(x => x.Id == study.ApplyId);

            return study;
        }

        public void UpdateStudy(long id, Study study)
        {
            var updatedStudy = _entityContext.Studies.FirstOrDefault(x => x.Id == id);
            if (updatedStudy != null)
            {
                updatedStudy.Title = study.Title;
                updatedStudy.PublishDate = study.PublishDate;
                updatedStudy.Description = study.Description;
                updatedStudy.Rating = study.Rating;
                updatedStudy.ApplyId = study.ApplyId;

                _entityContext.Studies.Update(updatedStudy);
                _entityContext.SaveChanges();
            }
        }
    }
}
