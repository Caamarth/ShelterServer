using ShelterApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.Services
{
    public interface IAnimalService
    {
        IEnumerable<AnimalEntity> getAnimals();
        AnimalEntity getAnimal(long id);
        void CreateAnimal(AnimalEntity animal);
        void UpdateAnimal(AnimalEntity animal);
        void DeleteAnimal(long id);
    }
}
