using ShelterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShelterApp.Enums;
using Microsoft.EntityFrameworkCore;

namespace ShelterApp.Services
{
    public class AnimalService : IAnimalService
    {
        private EntityContext _entityContext;

        public AnimalService(EntityContext entityContect)
        {
            _entityContext = entityContect;

            if (!_entityContext.Animals.Any())
            {
                _entityContext.Animals.Add(new AnimalEntity
                {
                    Name = "Kevin",
                    Sex = Sex.Male,
                    Race = "Yorkshire Terrier",
                    RaceType = TypeClassification.Emlős,
                    BirthDate = DateTime.Parse("2008-04-03"),
                    AdmissionDate = DateTime.Parse("2012-05-21"),
                    Weight = 3.1,
                    Width = 10,
                    Height = 35,
                    Length = 50,
                    Description = "A legjobb kutyus a világon",
                    Classification = AnimalClassification.Szelid
                });
                _entityContext.SaveChanges();
            }
        }

        public void CreateAnimal(AnimalEntity animal)
        {
            _entityContext.Animals.Add(animal);
            _entityContext.SaveChanges();
        }

        public void DeleteAnimal(long id)
        {
            var animal = _entityContext.Animals.FirstOrDefault(x => x.Id == id);
            if (animal != null)
            {
                _entityContext.Animals.Remove(animal);
                _entityContext.SaveChanges();
            }
        }

        public AnimalEntity getAnimal(long id)
        {
            var animal = _entityContext.Animals.FirstOrDefault(x => x.Id == id);
            animal.Applications = _entityContext.Applications.Where(x => x.AnimalEntityId == id).ToList();
            return animal;
        }

        public IEnumerable<AnimalEntity> getAnimals()
        {
            return _entityContext.Animals
                .Include(animal => animal.Applications);
        }

        public void UpdateAnimal(AnimalEntity animal)
        {
            var updatedAnimal = _entityContext.Animals.FirstOrDefault(x => x.Id == animal.Id);
            if (updatedAnimal != null)
            {
                updatedAnimal.Name = animal.Name;
                updatedAnimal.Sex = animal.Sex;
                updatedAnimal.Race = animal.Race;
                updatedAnimal.RaceType = animal.RaceType;
                updatedAnimal.BirthDate = animal.BirthDate;
                updatedAnimal.AdmissionDate = animal.AdmissionDate;
                updatedAnimal.Weight = animal.Weight;
                updatedAnimal.Width = animal.Width;
                updatedAnimal.Height = animal.Height;
                updatedAnimal.Length = animal.Length;
                updatedAnimal.Description = animal.Description;
                updatedAnimal.Classification = animal.Classification;
            }

            _entityContext.Animals.Update(updatedAnimal);
            _entityContext.SaveChanges();
        }
    }
}
