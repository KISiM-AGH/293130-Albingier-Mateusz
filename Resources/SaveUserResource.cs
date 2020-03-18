using FullStack_Project_IE_2.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace FullStack_Project_IE_2.Resources
{
    public class SaveUserResource
    {
        [Required]
        public int Id { get; set;}
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public ERole ST { get; set;}
        [Required]
        public ERole LA { get; set; }

    }
}
