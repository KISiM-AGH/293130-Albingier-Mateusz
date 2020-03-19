using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Domain.Services
{
    public interface ICompetitionService
    {
        Task<IEnumerable<Competition>> ListAsync();
        Task<CompetitionResponse> SaveAsync(Competition competition);
        Task<CompetitionResponse> UpdateAsync(int id, Competition competition);
        Task<CompetitionResponse> DeleteAsync(int id);
    }
}
