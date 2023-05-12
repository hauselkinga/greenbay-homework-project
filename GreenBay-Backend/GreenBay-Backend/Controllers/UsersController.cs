namespace GreenBay_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<ActionResult> Register(UserCreationDTO userData)
        {
            if (string.IsNullOrEmpty(userData.UserName)
                || string.IsNullOrEmpty(userData.Password))
            {
                return BadRequest();
            }

            if (userData.UserName.Length < 3)
            {
                return BadRequest("Error: UserName must be at least 3 characters long.");
            } else if (userData.UserName.Length > 64)
            {
                return BadRequest("Error: UserName must be less than 64 characters long.");
            }

            if (userData.Password.Length < 8)
            {
                return BadRequest("Error: Password must be at least 8 characters long.");
            } else if (userData.Password.Length > 256)
            {
                return BadRequest("Error: Incorrect password format.");
            }

            if (_userRepository.UsernameExists(userData.UserName))
            {
                return Conflict("Error: UserName already exists.");
            }

            var user = _mapper.Map<User>(userData);

            _userRepository.AddUser(user);
            await _userRepository.SaveUser();

            return Ok(user);
        }
    }
}
