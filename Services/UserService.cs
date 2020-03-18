using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Repositories;
using FullStack_Project_IE_2.Domain.Services;
using FullStack_Project_IE_2.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingFella = await userRepository.FindById(id);
            if(existingFella == null) return new UserResponse("User not found.");

            try
            {
                userRepository.Remove(existingFella);
                await unitOfWork.CompleteAsync();

                return new UserResponse(existingFella);
            }
            catch(Exception e)
            {
                return new UserResponse($"An error occurred when deleting the category: {e.Message}");
            }

            
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
                return new UserResponse(user);
            }
            catch(Exception e)
            {
                return new UserResponse($"Error when saving user: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingFella = await userRepository.FindById(id);

            if(existingFella == null) return new UserResponse("ERROR: User not found.");

            existingFella.Name = user.Name;
            existingFella.LA = user.LA;
            existingFella.ST = user.ST;
            existingFella.PointsLA = user.PointsLA;
            existingFella.PointsST = user.PointsST;

            try
            {
                userRepository.Update(existingFella);
                await unitOfWork.CompleteAsync();
                return new UserResponse(existingFella);
            }
            catch(Exception e)
            {
                return new UserResponse($"An error occurred when updating the category: {e.Message}");
            }

        }
    }
}
