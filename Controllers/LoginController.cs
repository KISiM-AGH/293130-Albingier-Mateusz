using AutoMapper;
using FullStack_Project_IE_2.Core.Security.Tokens;
using FullStack_Project_IE_2.Core.Services;
using FullStack_Project_IE_2.Resources;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Controllers
{
    [ApiController]
    public class LoginController : Controller
    {

        private readonly IMapper mapper;
        private readonly IAuthenticationService authenticationService;

        public LoginController(IMapper mapper, IAuthenticationService authenticationService)
        {
            this.mapper = mapper;
            this.authenticationService = authenticationService;
        }

        [Route("/api/login")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] UserCredentialsResource userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await authenticationService.CreateAccessTokenAsync(userCredentials.Email, userCredentials.Password);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var accessTokenResource = mapper.Map<AccessToken, TokenResource>(response.Token);
            return Ok(accessTokenResource);
        }

        [Route("/api/token/refresh")]
        [HttpPost]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenResource refreshTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await authenticationService.RefreshTokenAsync(refreshTokenResource.Token, refreshTokenResource.UserEmail);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var tokenResource = mapper.Map<AccessToken, TokenResource>(response.Token);
            return Ok(tokenResource);
        }

        [Route("/api/token/revoke")]
        [HttpPost]
        public IActionResult RevokeToken([FromBody] RevokeTokenResource revokeTokenResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            authenticationService.RevokeRefreshToken(revokeTokenResource.Token);
            return NoContent();
        }
    }
}
