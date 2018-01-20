using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.ViewModels
{
    public class RatingViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double RatingValue { get; set; }
        [Required]
        public int ApplyId { get; set; }
    }
}
