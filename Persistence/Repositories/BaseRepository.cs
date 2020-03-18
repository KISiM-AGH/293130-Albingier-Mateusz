using FullStack_Project_IE_2.Persistence.Contexts;

namespace FullStack_Project_IE_2.Persistence.Repositories
{
    public abstract class BaseRepository

    {
        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }

    }
}
