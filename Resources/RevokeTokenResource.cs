using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Resources
{
    public class RevokeTokenResource
    {

        [Required]
        public string Token { get; set;}
    }
}
