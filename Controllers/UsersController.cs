using CompleteDeveloperNetworkWebApp.DTOs;
using CompleteDeveloperNetworkWebApp.DTOs.Users;
using CompleteDeveloperNetworkWebApp.Models;
using CompleteDeveloperNetworkWebApp.Services.Skills;
using CompleteDeveloperNetworkWebApp.Services.Users;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompleteDeveloperNetworkWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        private readonly IUserService _userService;

        private readonly ISkillService _skillService;

        public UsersController(ILogger<UsersController> logger, IUserService userService, ISkillService skillService) {
            _logger = logger;
            _userService = userService;
            _skillService = skillService;
        }


        // GET: api/users
        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("GetAll()");
            var users = _userService.GetAll();

            var userDtos = users.Select(u => new GetUserResponseDto(
                u.Id,
                u.Username,
                u.Mail,
                u.PhoneNumber,
                u.SkillSets,
                u.Hobby)).ToList();

            var responseDto = new GetAllUsersResponseDto(userDtos);

            _logger.LogInformation("GetAll() END, response={}", responseDto);
            return Ok(responseDto);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Get(id={})", id);

            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            var responseDto = new GetUserResponseDto(
                user.Id,
                user.Username,
                user.Mail,
                user.PhoneNumber,
                user.SkillSets,
                user.Hobby);

            _logger.LogInformation("Get(id={}) END, response={}", id, responseDto);
            return Ok(responseDto);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post(CreateUserRequestDto requestDto)
        {
            _logger.LogInformation("Post(requestDto={})", requestDto);

            var skillSets = requestDto.SkillSets.Select((skillName) => new Skill { Name = skillName }).ToList();

            var user = new User(
                requestDto.Username,
                requestDto.Mail,
                requestDto.PhoneNumber,
                skillSets,
                requestDto.Hobby);

            _userService.Create(user);

            var responseDto = new CreateUserResponseDto(
                user.Id,
                user.Username,
                user.Mail,
                user.PhoneNumber,
                user.SkillSets,
                user.Hobby);

            _logger.LogInformation("Post(requestDto={}) END, response={}", requestDto, responseDto);
            return CreatedAtAction(nameof(Get), new { id = responseDto.Id}, responseDto);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateUserRequestDto requestDto)
        {
            _logger.LogInformation("Put(id={}, requestDto={})", id, requestDto);

            var user = _userService.Get(id);
            UpdateUserResponseDto responseDto;

            if (user == null)
            {
                var skillSets = requestDto.SkillSets.Select((skillName) => new Skill { Name = skillName }).ToList();

                user = new User(
                    requestDto.Username,
                    requestDto.Mail,
                    requestDto.PhoneNumber,
                    skillSets,
                    requestDto.Hobby);

                _userService.Create(user);

                responseDto = new UpdateUserResponseDto(
                    user.Id,
                    user.Username,
                    user.Mail,
                    user.PhoneNumber,
                    user.SkillSets,
                    user.Hobby);

                _logger.LogInformation("Put(id={}, requestDto={}) END, created, response={})", id, requestDto, responseDto);
                return CreatedAtAction(nameof(Get), new { id = responseDto.Id }, responseDto);
            }

            user = _userService.Update(id, user);
            responseDto = new UpdateUserResponseDto(
                user.Id,
                user.Username,
                user.Mail,
                user.PhoneNumber,
                user.SkillSets,
                user.Hobby);

            _logger.LogInformation("Put(id={}, requestDto={}) END, updated, response={})", id, requestDto, responseDto);
            return Ok(user);    
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete(id={})", id);
            _userService.Delete(id);
            return Ok();
        }
    }
}
