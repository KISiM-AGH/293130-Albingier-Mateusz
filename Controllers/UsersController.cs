using AutoMapper;
using FullStack_Project_IE_2.Core.Models;
using FullStack_Project_IE_2.Core.Services;
using FullStack_Project_IE_2.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> CreateNewUserAsync([FromBody] UserCredentialsResource userCredentials)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var user = mapper.Map<UserCredentialsResource, User>(userCredentials);
            var response = await userService.CreateUserAsync(user, EType.Common);

            if(!response.Success) return BadRequest(response.Message);
            var userResource = mapper.Map<User, UserResource>(response.User);
            return Ok(userResource);
        }
    }
}
