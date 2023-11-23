using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceProject.Model.Dto
{
    public class RegisterDto
    {
        [Required (ErrorMessage ="Email is required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        
        [Required(ErrorMessage ="need password")]
        [DataType(DataType.Password)]
        public string PassWord {get;set;}
        public string [] Role {get;set;}
    }
}