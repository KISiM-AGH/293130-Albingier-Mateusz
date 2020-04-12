using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace FullStack_Project_IE_2.Core.Models
{
    public class Type
    {
        public int Id { set; get;}

        [Required]
        [StringLength(50)]
        public string Name { set; get;}

        public ICollection<UserType> userType { get; set;} = new Collection<UserType>();
    }
}
