using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Domain.Services
{
    public interface ICoupleService
    {

        Task<IEnumerable<Couple>> ListAsync();
        Task<CoupleResponse> SaveAsync(Couple couple);
        Task<CoupleResponse> UpdateAsync(int id, Couple couple);
        Task<CoupleResponse> DeleteAsync(int id);
    }
}
