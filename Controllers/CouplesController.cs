using AutoMapper;
using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Services;
using FullStack_Project_IE_2.Extensions;
using FullStack_Project_IE_2.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Controllers
{
    [Route("/api/[controller]")]
    public class CouplesController : Controller
    {

        private readonly ICoupleService coupleService;
        private readonly IMapper mapper;

        public CouplesController(ICoupleService coupleService, IMapper mapper)
        {
            this.coupleService = coupleService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CoupleResource>> GetTaskAsync()
        {
            var coupleList = await coupleService.ListAsync();
            var resources = mapper.Map<IEnumerable<Couple>, IEnumerable<CoupleResource>>(coupleList);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCoupleResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var couple = mapper.Map<SaveCoupleResource, Couple>(resource);
            var result = await coupleService.SaveAsync(couple);

            if (!result.Success) return BadRequest(result.Message);

            var coupleResource = mapper.Map<Couple, CoupleResource>(result.couple);
            return Ok(coupleResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCoupleResource couple)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var c = mapper.Map<SaveCoupleResource, Couple>(couple);
            var result = await coupleService.UpdateAsync(id, c);

            if (!result.Success) return BadRequest(result.Message);

            var coupleResource = mapper.Map<Couple, CoupleResource>(result.couple);
            return Ok(coupleResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await coupleService.DeleteAsync(id);

            if (!result.Success) return BadRequest(result.Message);

            var coupleResource = mapper.Map<Couple, CoupleResource>(result.couple);
            return Ok(coupleResource);
        }
    }
}
