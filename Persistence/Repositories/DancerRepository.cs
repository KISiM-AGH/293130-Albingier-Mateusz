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
            return await context.Dancers.ToListAsync();
        }

        public async Task AddAsync(Dancer dancer)
        {
            await context.Dancers.AddAsync(dancer);
        }

        public async Task<Dancer> FindById(int id)
        {
            return await context.Dancers.FindAsync(id);
        }

        public void Update(Dancer dancer)
        {
            context.Dancers.Update(dancer);
        }

        public void Remove(Dancer dancer)
        {
            context.Dancers.Remove(dancer);
        }
    }
}
