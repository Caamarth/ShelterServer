﻿using ShelterApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.Models
{
    public class Study
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } //Ügyiratszám
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PublishDate { get; set; } //Dátum
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
        public Apply Apply { get; set; }
    }
}
