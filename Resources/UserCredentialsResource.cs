using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Resources
{
    public class UserCredentialsResource
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(250)]
        public string Email { get; set;}
        
        [Required]
        [StringLength(250)]
        public string Password { get; set;}
    }
}
