﻿using AutoMapper;
using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Services;
using FullStack_Project_IE_2.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FullStack_Project_IE_2.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace FullStack_Project_IE_2.Controllers
{
    [Authorize]
    [Route("/api/[controller]")]
    public class DancersController : Controller
    {
        
        private readonly IDancerService userService;
        private readonly IMapper mapper;

        public DancersController(IDancerService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DancerResource>> GetAllAsync()
        {
            var userList = await userService.ListAsync();
            var resources = mapper.Map<IEnumerable<Dancer>, IEnumerable<DancerResource>>(userList);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveDancerResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var user = mapper.Map<SaveDancerResource, Dancer>(resource);
            var result  = await userService.SaveAsync(user);

            if(!result.Success) return BadRequest(result.Message);

            var userResource = mapper.Map<Dancer, DancerResource>(result.User);
            return Ok(userResource);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDancerResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var user = mapper.Map<SaveDancerResource, Dancer>(resource);
            var result = await userService.UpdateAsync(id, user);

            if(!result.Success) return BadRequest(result.Message);

            var userResource = mapper.Map<Dancer, DancerResource>(result.User);
            return Ok(userResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await userService.DeleteAsync(id);
            
            if(!result.Success) return BadRequest(result.Message);

            var userResource = mapper.Map<Dancer, DancerResource>(result.User);
            return Ok(userResource);
        }
    }
}