using FullStack_Project_IE_2.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullStack_Project_IE_2.Resources
{
    public class SaveCoupleResource
    {
        [Required]
        public bool Point_LA { set; get; }
        [Required]
        public bool Point_ST { set; get; }
        [Required]
        public IList<Couple> Dancers { set; get; } = new List<Couple>();
    }
}
