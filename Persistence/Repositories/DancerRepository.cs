using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Repositories;
using FullStack_Project_IE_2.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Persistence.Repositories
{
    public class DancerRepository : BaseRepository, IDancerRepository
    {

        public DancerRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Dancer>> ListAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task AddAsync(Dancer user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task<Dancer> FindById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public void Update(Dancer user)
        {
            context.Users.Update(user);
        }

        public void Remove(Dancer user)
        {
            context.Users.Remove(user);
        }
    }
}
