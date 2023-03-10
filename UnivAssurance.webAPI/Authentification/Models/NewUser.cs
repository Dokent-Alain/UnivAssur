using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace UnivAssurance.webAPI.Authentification.Models
{
    public class NewUser
    {
        public static object Username { get; internal set; }
        [Required(ErrorMessage = ("UserName is required"))]
        public string? UserName { get; set; }
        [Required(ErrorMessage = ("Password is required"))]
        public  string? Password { get; set; }
        [Required(ErrorMessage = ("Email is required"))]
        [EmailAddress]
        public string? Email { get; set; }

    }
}