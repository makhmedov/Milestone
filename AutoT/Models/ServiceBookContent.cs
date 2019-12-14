using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoT.Models
{
    public class ServiceBookContent
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "MechanicsUserId")]
        public int MechanicsUserId { get; set; }

        [Display(Name = "Content")]
        public int Content { get; set; }

        [Display(Name = "duration")]
        public int duration { get; set; }

        [Required]
        [Display(Name = "ServiceBookId")]
        public int RaServiceBookIdtingId { get; set; }

        public ServiceBook ServiceBook { get; set; }
    }
}