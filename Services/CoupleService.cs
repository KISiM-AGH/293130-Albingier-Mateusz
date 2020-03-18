using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Repositories;
using FullStack_Project_IE_2.Domain.Services;
using FullStack_Project_IE_2.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Services
{
    public class CoupleService : ICoupleService
    {
        private readonly ICoupleRepository coupleRepository;
        private readonly IUnitOfWork unitOfWork;

        public CoupleService(ICoupleRepository coupleRepository, IUnitOfWork unitOfWork)
        {
            this.coupleRepository = coupleRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CoupleResponse> DeleteAsync(int id)
        {
            var existingFella = await coupleRepository.FindById(id);
            if (existingFella == null) return new CoupleResponse("Couple not found.");

            try
            {
                coupleRepository.Remove(existingFella);
                await unitOfWork.CompleteAsync();

                return new CoupleResponse(existingFella);
            }
            catch (Exception e)
            {
                return new CoupleResponse($"An error occurred when deleting couple: {e.Message}");
            }
        }

        public async Task<IEnumerable<Couple>> ListAsync()
        {
            return await coupleRepository.ListAsync();
        }

        public async Task<CoupleResponse> SaveAsync(Couple couple)
        {
            try
            {
                await coupleRepository.AddAsync(couple);
                await unitOfWork.CompleteAsync();
                return new CoupleResponse(couple);
            }
            catch (Exception e)
            {
                return new CoupleResponse($"Error when saving couple: {e.Message}");
            }
        }

        public async Task<CoupleResponse> UpdateAsync(int id, Couple couple)
        {
            var existingFella = await coupleRepository.FindById(id);

            if (existingFella == null) return new CoupleResponse("ERROR: Couple not found.");

            existingFella.Point_LA = couple.Point_LA;
            existingFella.Point_ST = couple.Point_ST;

            try
            {
                coupleRepository.Update(existingFella);
                await unitOfWork.CompleteAsync();
                return new CoupleResponse(existingFella);
            }
            catch (Exception e)
            {
                return new CoupleResponse($"An error occurred when updating couple: {e.Message}");
            }
        }
    }
}
