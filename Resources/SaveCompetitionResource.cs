using FullStack_Project_IE_2.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullStack_Project_IE_2.Resources
{
    public class SaveCompetitionResource
    {
        [Required]
        public string Location { set; get; }
        public DateTime date { get; set; }

        public IList<Dancer> Dancers { set; get; } = new List<Dancer>();
    }
}
