using FullStack_Project_IE_2.Core.Models;
using FullStack_Project_IE_2.Core.Services.Communication;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Core.Services
{
    public interface IUserService
    {

        Task<CreateUserResponse> CreateUserAsync(User user, params EType[] userRoles);
        Task<User> FindByEmailAsync(string email);
    }
}
