using FullStack_Project_IE_2.Domain.Models;
using System;
using System.Collections.Generic;

namespace FullStack_Project_IE_2.Resources
{
    public class CompetitionResource
    {
        public string Location { set; get; }
        public DateTime date { get; set; }

        public IList<User> Dancers { set; get; } = new List<User>();
    }
}
