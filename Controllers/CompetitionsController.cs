using AutoMapper;
using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Services;
using FullStack_Project_IE_2.Extensions;
using FullStack_Project_IE_2.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CompetitionsController : Controller
    {
        private readonly ICompetitionService competitionService;
        private readonly IMapper mapper;

        public CompetitionsController(ICompetitionService competitionService, IMapper mapper)
        {
            this.competitionService = competitionService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompetitionResource>> GetTaskAsync()
        {
            var coupleList = await competitionService.ListAsync();
            var resources = mapper.Map<IEnumerable<Competition>, IEnumerable<CompetitionResource>>(coupleList);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompetitionResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var user = mapper.Map<SaveCompetitionResource, Competition>(resource);
            var result = await competitionService.SaveAsync(user);

            if (!result.Success) return BadRequest(result.Message);

            var coupleResource = mapper.Map<Competition, CompetitionResource>(result.competition);
            return Ok(coupleResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompetitionResource saveCompetitionResource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var c = mapper.Map<SaveCompetitionResource, Competition>(saveCompetitionResource);
            var result = await competitionService.UpdateAsync(id, c);

            if (!result.Success) return BadRequest(result.Message);

            var coupleResource = mapper.Map<Competition, CompetitionResource>(result.competition);
            return Ok(coupleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await competitionService.DeleteAsync(id);

            if (!result.Success) return BadRequest(result.Message);

            var coupleResource = mapper.Map<Competition, CompetitionResource>(result.competition);
            return Ok(coupleResource);
        }
    }
}
