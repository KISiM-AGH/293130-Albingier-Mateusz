using System.ComponentModel.DataAnnotations.Schema;

namespace FullStack_Project_IE_2.Core.Models
{
    [Table("UserTypes")]
    public class UserType
    {
        public int UserId { get; set;}
        public User User { get; set;}

        public int TypeId { set; get;}
        public Type Type { get; set;}
    }
}
