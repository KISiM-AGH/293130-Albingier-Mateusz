using FullStack_Project_IE_2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Core.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user, EType[] userTypes);
        Task<User> FindByEmailAsync(string email);
    }
}
