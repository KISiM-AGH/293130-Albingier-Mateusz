using FullStack_Project_IE_2.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace FullStack_Project_IE_2.Resources
{
    public class SaveDancerResource
    {
        [Required]
        public int Id { set; get;}
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public EClass ST { get; set;}
        [Required]
        public EClass LA { get; set; }
        [Required]
        public ERole role { set; get;}

    }
}
