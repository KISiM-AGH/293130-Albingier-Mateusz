using AutoMapper;
using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Resources;
using FullStack_Project_IE_2.Extensions;
using FullStack_Project_IE_2.Core.Models;
using FullStack_Project_IE_2.Core.Security.Tokens;

namespace FullStack_Project_IE_2.Mapping
{
    public class ModelToResourceProfile : Profile
    {

        public ModelToResourceProfile()
        {
            CreateMap<Dancer, DancerResource>().ForMember(s=>s.LA, o=>o.MapFrom(s=>s.LA.ToDescriptionEnum())).ForMember(s=>s.ST, o=>o.MapFrom(s=>s.ST.ToDescriptionEnum())).ForMember(s=>s.role, o=>o.MapFrom(s=>s.role.ToDescriptionEnum()));
            CreateMap<Couple, CoupleResource>();
            CreateMap<Competition, CompetitionResource>();
            CreateMap<User, UserResource>().ForMember(u=>u.Types, o=>o.MapFrom(u=>u.UserTypes));
            CreateMap<AccessToken, TokenResource>().ForMember(q=>q.AccessToken, o=>o.MapFrom(q=>q.Token)).ForMember(q=>q.RefreshToken, o=>o.MapFrom(q=>q.RefreshToken.Token)).ForMember(q=>q.Expitarion, o=>o.MapFrom(q=>q.Expiration));
        }
    }
}
