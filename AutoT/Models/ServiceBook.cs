using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoT.Models
{
    public class ServiceBook
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        public User User { get; set; }
    }
}