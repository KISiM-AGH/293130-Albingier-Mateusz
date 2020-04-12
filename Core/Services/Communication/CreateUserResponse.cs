using FullStack_Project_IE_2.Core.Models;
using FullStack_Project_IE_2.Domain.Services.Communication;

namespace FullStack_Project_IE_2.Core.Services.Communication
{
    public class CreateUserResponse : BaseResponse
    {
        public User User { get; private set;}
        public CreateUserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }
    }
}
