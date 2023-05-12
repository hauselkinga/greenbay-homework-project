namespace GreenBay_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUserHelper _userHelper;
        public UsersController(IMapper mapper, IUserRepository userRepository, IUserHelper userHelper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userHelper = userHelper;
        }

        [HttpPost("register")]
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

            try
            {
                user.Password = _userHelper.HashPassword(user.Password);
                _userRepository.AddUser(user);
                await _userRepository.SaveUser();

                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult Login(UserLoginDTO loginData)
        {
            var userFromDb = _userRepository.GetUserByUsername(loginData.UserName);
            var hashedPassword = _userHelper.HashPassword(loginData.Password);

            if (userFromDb == null || hashedPassword != userFromDb.Password)
            {
                return Unauthorized("Error: Wrong UserName or Password");
            }

            return Ok();
        }
    }
}
