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
    public class CompetitionService : ICompetitionService
    {

        private readonly ICompetitionRepository competitionRepository;
        private readonly IUnitOfWork unitOfWork;

        public CompetitionService(ICompetitionRepository competitionRepository, IUnitOfWork unitOfWork)
        {
            this.competitionRepository = competitionRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<CompetitionResponse> DeleteAsync(int id)
        {
            var existingFella = await competitionRepository.FindById(id);
            if (existingFella == null) return new CompetitionResponse("Competition not found.");

            try
            {
                competitionRepository.Remove(existingFella);
                await unitOfWork.CompleteAsync();

                return new CompetitionResponse(existingFella);
            }
            catch (Exception e)
            {
                return new CompetitionResponse($"An error occurred when deleting competition: {e.Message}");
            }
        }

        public async Task<IEnumerable<Competition>> ListAsync()
        {
            return await competitionRepository.ListAsync();
        }

        public async Task<CompetitionResponse> SaveAsync(Competition competition)
        {
            try
            {
                await competitionRepository.AddAsync(competition);
                await unitOfWork.CompleteAsync();
                return new CompetitionResponse(competition);
            }
            catch (Exception e)
            {
                return new CompetitionResponse($"Error when saving competition: {e.Message}");
            }
        }

        public async Task<CompetitionResponse> UpdateAsync(int id, Competition competition)
        {
            var existingFella = await competitionRepository.FindById(id);

            if (existingFella == null) return new CompetitionResponse("ERROR: Couple not found.");

            existingFella.Location = competition.Location;
            existingFella.Dancers = competition.Dancers;
            existingFella.date = competition.date;

            try
            {
                competitionRepository.Update(existingFella);
                await unitOfWork.CompleteAsync();
                return new CompetitionResponse(existingFella);
            }
            catch (Exception e)
            {
                return new CompetitionResponse($"An error occurred when updating competition: {e.Message}");
            }
        }
    } 
}
