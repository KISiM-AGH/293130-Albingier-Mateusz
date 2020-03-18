using System.Collections.Generic;

namespace FullStack_Project_IE_2.Domain.Models
{
    public class Couple
    {
        public int Id { get; set;}
        public bool Point_LA { set; get;}
        public bool Point_ST { set; get; }

        public IList<User> Dancers { set; get;} = new List<User>();
    }
}