using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Domain.Repositories
{
    public interface IUnitOfWork
    {

        Task CompleteAsync();
    }
}
