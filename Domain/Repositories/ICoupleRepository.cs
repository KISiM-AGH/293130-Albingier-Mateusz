using FullStack_Project_IE_2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Domain.Repositories
{
    public interface ICoupleRepository
    {
        Task<IEnumerable<Couple>> ListAsync();
        Task AddAsync(Couple couple);
        Task<Couple> FindById(int id);
        void Update(Couple couple);
        void Remove(Couple couple);
    }
}
