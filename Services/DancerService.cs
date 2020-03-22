using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Repositories;
using FullStack_Project_IE_2.Domain.Services;
using FullStack_Project_IE_2.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Services
{
    public class DancerService : IDancerService
    {

        private readonly IDancerRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public DancerService(IDancerRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<DancerResponse> DeleteAsync(int id)
        {
            var existingFella = await userRepository.FindById(id);
            if(existingFella == null) return new DancerResponse("User not found.");

            try
            {
                userRepository.Remove(existingFella);
                await unitOfWork.CompleteAsync();

                return new DancerResponse(existingFella);
            }
            catch(Exception e)
            {
                return new DancerResponse($"An error occurred when deleting dancer: {e.Message}");
            }

            
        }

        public async Task<IEnumerable<Dancer>> ListAsync()
        {
            return await userRepository.ListAsync();
        }

        public async Task<DancerResponse> SaveAsync(Dancer user)
        {
            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
                return new DancerResponse(user);
            }
            catch(Exception e)
            {
                return new DancerResponse($"Error when saving user: {e.Message}");
            }
        }

        public async Task<DancerResponse> UpdateAsync(int id, Dancer user)
        {
            var existingFella = await userRepository.FindById(id);

            if(existingFella == null) return new DancerResponse("ERROR: User not found.");

            existingFella.Name = user.Name;
            existingFella.LA = user.LA;
            existingFella.ST = user.ST;
            existingFella.PointsLA = user.PointsLA;
            existingFella.PointsST = user.PointsST;

            try
            {
                userRepository.Update(existingFella);
                await unitOfWork.CompleteAsync();
                return new DancerResponse(existingFella);
            }
            catch(Exception e)
            {
                return new DancerResponse($"An error occurred when updating the category: {e.Message}");
            }

        }
    }
}
