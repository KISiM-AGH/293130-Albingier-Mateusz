using System;
using System.Collections.Generic;

namespace FullStack_Project_IE_2.Domain.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Location { set; get;}
        public DateTime date { get; set;}

        public IList<Dancer> Dancers { set; get; } = new List<Dancer>();
    }
}
