using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoT.Models
{
    public class Rating
    {   

        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "very_low")]
        public int very_low { get; set; }

        [Required]
        [Display(Name = "low")]
        public int low { get; set; }

        [Required]
        [Display(Name = "medium")]
        public int medium { get; set; }

        [Required]
        [Display(Name = "high")]
        public int high { get; set; }

        [Required]
        [Display(Name = "very_high")]
        public int very_high { get; set; }
    }
}