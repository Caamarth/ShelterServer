using ShelterApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterApp.Models
{
    public class Apply
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PublishDate { get; set; }

        public Status ApplyStatus { get; set; }

        public string Description { get; set; }

        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
        public int AnimalEntityId { get; set; }
        public AnimalEntity AnimalEntity { get; set; }

        public ICollection<Study> Studies { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
