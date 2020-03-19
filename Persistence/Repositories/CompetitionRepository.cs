using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Repositories;
using FullStack_Project_IE_2.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Persistence.Repositories
{
    public class CompetitionRepository : BaseRepository, ICompetitionRepository
    {
        public CompetitionRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(Competition competition)
        {
            await context.AddAsync(competition);
        }

        public async Task<Competition> FindById(int id)
        {
            return await context.Competitions.FindAsync(id);
        }

        public async Task<IEnumerable<Competition>> ListAsync()
        {
            return await context.Competitions.Include(a => a.Dancers).ToListAsync();
        }

        public void Remove(Competition competition)
        {
            context.Competitions.Remove(competition);
        }

        public void Update(Competition competition)
        {
            context.Competitions.Update(competition);
        }
    }
}
