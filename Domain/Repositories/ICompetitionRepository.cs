using FullStack_Project_IE_2.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Domain.Repositories
{
    public interface ICompetitionRepository
    {
        Task<IEnumerable<Competition>> ListAsync();
        Task AddAsync(Competition competition);
        Task<Competition> FindById(int id);
        void Update(Competition competition);
        void Remove(Competition competition);
    }
}
