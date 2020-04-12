using AutoMapper;
using FullStack_Project_IE_2.Core.Models;
using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Resources;

namespace FullStack_Project_IE_2.Mapping
{
    public class ResourceToModelProfile : Profile
    {

        public ResourceToModelProfile()
        {
            CreateMap<SaveDancerResource, Dancer>();
            CreateMap<SaveCoupleResource,Couple>();
            CreateMap<SaveCompetitionResource, Competition>();
            CreateMap<UserCredentialsResource, User>();
        }
    }
}
