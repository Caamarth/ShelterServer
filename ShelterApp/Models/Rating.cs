﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public double RatingValue { get; set; }
        public int UserId { get; set; }

        public int ApplyId { get; set; }
        
    }
}