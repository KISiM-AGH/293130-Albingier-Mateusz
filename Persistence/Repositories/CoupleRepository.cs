using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Repositories;
using FullStack_Project_IE_2.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Persistence.Repositories
{
    public class CoupleRepository : BaseRepository, ICoupleRepository
    {

        public CoupleRepository(AppDbContext context) : base(context)
        {

        }



        public async Task AddAsync(Couple couple)
        {
            await context.AddAsync(couple);
        }

        public async Task<Couple> FindById(int id)
        {
            return await context.Couples.FindAsync(id);
        }

        public async Task<IEnumerable<Couple>> ListAsync()
        {
            return await context.Couples.Include(a=>a.Dancers).ToListAsync();
        }

        public void Remove(Couple couple)
        {
            context.Couples.Remove(couple);
        }

        public void Update(Couple couple)
        {
            context.Couples.Update(couple);
        }
    }
}
