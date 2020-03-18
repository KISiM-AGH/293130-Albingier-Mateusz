using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}
