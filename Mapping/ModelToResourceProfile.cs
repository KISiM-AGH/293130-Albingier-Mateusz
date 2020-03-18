using AutoMapper;
using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Resources;

namespace FullStack_Project_IE_2.Mapping
{
    public class ModelToResourceProfile : Profile
    {

        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
        }
    }
}
