using FullStack_Project_IE_2.Domain.Models;
using System.Collections.Generic;

namespace FullStack_Project_IE_2.Resources
{
    public class CoupleResource
    {
        public int Id { set; get;}
        public bool Point_LA { set; get; }
        public bool Point_ST { set; get; }

        public IList<Dancer> Dancers { set; get; } = new List<Dancer>();
    }
}
