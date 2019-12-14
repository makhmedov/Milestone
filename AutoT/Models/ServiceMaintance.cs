using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoT.Models
{
    public class ServiceMaintance
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "RatingId")]
        public int RatingId { get; set; }

        public Rating Rating { get; set; }
    }
}