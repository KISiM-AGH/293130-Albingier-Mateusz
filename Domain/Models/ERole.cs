using System.ComponentModel;

namespace FullStack_Project_IE_2.Domain.Models
{
    public enum ERole : byte
    {
        [Description("O")]
        Ordinary = 1,

        [Description("D")]
        Dancer = 2,

        [Description("J")]
        Judge = 3,

        [Description("C")]
        Chairman = 4

    }
}
