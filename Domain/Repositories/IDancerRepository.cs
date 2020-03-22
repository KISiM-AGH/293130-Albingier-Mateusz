using FullStack_Project_IE_2.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Domain.Repositories
{
    public interface IDancerRepository
    {

        Task<IEnumerable<Dancer>> ListAsync();
        Task AddAsync(Dancer user);
        Task<Dancer> FindById(int id);
        void Update(Dancer user);
        void Remove(Dancer user);
    }
}
