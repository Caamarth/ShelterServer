﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int RatingValue { get; set; }
        public int ApplicationId { get; set; }
    }
}
