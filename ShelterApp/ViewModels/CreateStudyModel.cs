using ShelterApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.ViewModels
{
    public class CreateStudyModel
    {
        public string Title { get; set; } //Ügyiratszám
        public string Description { get; set; } //Vélemény
        public double Rating { get; set; } //Értékelés

        public double Size { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfPeople { get; set; }
        public int NumberOfAnimals { get; set; }

        public HomeType HomeTypeLevel { get; set; }
        public ComfortType ComfortLevel { get; set; }
        public Habitability HabitabilityLevel { get; set; }
        public Clean CleanLevel { get; set; }

        public int ApplyId { get; set; }
    }
}
