using AutoMapper;
using FullStack_Project_IE_2.Domain.Models;
using FullStack_Project_IE_2.Domain.Services;
using FullStack_Project_IE_2.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FullStack_Project_IE_2.Extensions;

namespace FullStack_Project_IE_2.Controllers
{
    [Route("/api/[controller]")]
    public class UsersController : Controller
    {
        
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAllAsync()
        {
            var userList = await userService.ListAsync();
            var resources = mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(userList);

            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var user = mapper.Map<SaveUserResource, User>(resource);
            var result  = await userService.SaveAsync(user);

            if(!result.Success) return BadRequest(result.Message);

            var userResource = mapper.Map<User, UserResource>(result.User);
            return Ok(userResource);
            
        } 

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessages());

            var user = mapper.Map<SaveUserResource, User>(resource);
            var result = await userService.UpdateAsync(id, user);

            if(!result.Success) return BadRequest(result.Message);

            var userResource = mapper.Map<User, UserResource>(result.User);
            return Ok(userResource);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await userService.DeleteAsync(id);
            
            if(!result.Success) return BadRequest(result.Message);

            var userResource = mapper.Map<User, UserResource>(result.User);
            return Ok(userResource);
        }
    }
}