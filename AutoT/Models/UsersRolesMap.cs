using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutoT.Models
{
    public class UsersRolesMap
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        [Display(Name = "RoleId")]
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}