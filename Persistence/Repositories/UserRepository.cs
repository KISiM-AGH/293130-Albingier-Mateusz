using FullStack_Project_IE_2.Core.Models;
using FullStack_Project_IE_2.Core.Repositories;
using FullStack_Project_IE_2.Persistence.Contexts;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FullStack_Project_IE_2.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(User user, EType[] userRoles)
        {
            var typeNames = userRoles.Select(t=>t.ToString()).ToList();
            var roles = await context.Types.Where(r=>typeNames.Contains(r.Name)).ToListAsync();

            foreach(var type in roles)
            {
                user.UserTypes.Add(new UserType{ TypeId = type.Id});
            }
            context.Users.Add(user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await context.Users.Include(u=>u.UserTypes).ThenInclude(t=>t.Type).SingleOrDefaultAsync(u=>u.Email == email);
        }
    }
}
