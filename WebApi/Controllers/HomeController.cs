using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi.Models;
using WebApi.Repositories;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public HomeController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Login(AuthenticateRequest model)
        {
            var user = _userRepository.GetUser(model.Username, model.Password);
            if(user is null)
                return BadRequest(new { message = "Username or password is incorrect." });

            var token = _tokenService.GenerateToken(user);
            var response = new AuthenticateResponse(user, token);
            return Ok(response);
        }

        [Authorize(Roles = "employee")]
        [HttpGet]
        [Route("employees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _userRepository.GetUsers().Where(x => x.Type == "employee");
            return Ok(employees);
        }

        [Authorize(Roles = "manager")]
        [HttpGet]
        [Route("managers")]
        public IActionResult GetAllManagers()
        {
            var employees = _userRepository.GetUsers().Where(x => x.Type == "manager");
            return Ok(employees);
        }
    }
}
