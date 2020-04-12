using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace FullStack_Project_IE_2.Core.Models
{
    public class User
    {
        public int Id { get; set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(250)]
        public string Email { get; set;}

        [Required]
        public string Password { get; set;}

        public ICollection<UserType> UserTypes { get; set;} = new Collection<UserType>();
    }
}
