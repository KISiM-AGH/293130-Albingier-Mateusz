using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Domain.Services
{
    public interface IDancerService
    {
        Task<IEnumerable<Dancer>> ListAsync();
        Task<DancerResponse> SaveAsync(Dancer user);
        Task<DancerResponse> UpdateAsync(int id, Dancer user);
        Task<DancerResponse> DeleteAsync(int id);
    }
}
