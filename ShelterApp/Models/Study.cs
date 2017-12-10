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
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }

        public int ApplyId { get; set; }
        public Apply Apply { get; set; }
    }
}
