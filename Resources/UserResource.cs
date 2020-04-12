using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Resources
{
    public class UserResource
    {

        public int Id { get; set;}
        public string Email { get; set;}
        public IEnumerable<string> Types { get; set;}
    }
}
