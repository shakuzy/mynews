using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mynewsreally.Models
{
    public class UserRole
    {
        public string UserId { get; set; }

        [Display(Name ="Nombre de usuario")]
        public string UserName { get; set; }

        [Display(Name = "Rol")]
        public string RoleId { get; set; }
        public string RolName { get; set; }


    }
}
