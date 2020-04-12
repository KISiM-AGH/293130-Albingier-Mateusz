using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Resources
{
    public class RefreshTokenResource
    {
        [Required]
        public string Token { get; set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(250)]
        public string UserEmail { get; set; }
    }
}
