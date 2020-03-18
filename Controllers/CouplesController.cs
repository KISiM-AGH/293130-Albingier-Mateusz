using AutoMapper;
using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Services;
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
    }
}
