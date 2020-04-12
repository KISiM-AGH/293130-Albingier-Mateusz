using FullStack_Project_IE_2.Core.Models;
using FullStack_Project_IE_2.Core.Repositories;
using FullStack_Project_IE_2.Core.Security.Hashing;
using FullStack_Project_IE_2.Core.Services;
using FullStack_Project_IE_2.Core.Services.Communication;
using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Repositories;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPasswordHasher passwordHasher;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            this.passwordHasher = passwordHasher;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }

        public async Task<CreateUserResponse> CreateUserAsync(User user, params EType[] userTypes)
        {
            var existingUser = await userRepository.FindByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return new CreateUserResponse(false, "Email already in use.", null);
            }

            user.Password = passwordHasher.HashPassword(user.Password);

            await userRepository.AddAsync(user, userTypes);
            await unitOfWork.CompleteAsync();

            return new CreateUserResponse(true, null, user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await userRepository.FindByEmailAsync(email);
        }
    }
}
