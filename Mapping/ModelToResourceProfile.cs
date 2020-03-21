using AutoMapper;
using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Resources;
using FullStack_Project_IE_2.Extensions;

namespace FullStack_Project_IE_2.Mapping
{
    public class ModelToResourceProfile : Profile
    {

        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>().ForMember(s=>s.LA, o=>o.MapFrom(s=>s.LA.ToDescriptionEnum())).ForMember(s=>s.ST, o=>o.MapFrom(s=>s.ST.ToDescriptionEnum())).ForMember(s=>s.role, o=>o.MapFrom(s=>s.role.ToDescriptionEnum()));
            CreateMap<Couple, CoupleResource>();
            CreateMap<Competition, CompetitionResource>();
        }
    }
}
