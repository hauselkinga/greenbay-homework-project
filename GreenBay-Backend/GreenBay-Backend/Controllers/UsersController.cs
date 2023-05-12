using GreenBay_Backend.Repositories;

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
        public async Task<ActionResult> Register(UserCreationDTO userData)
        {
            var user = _mapper.Map<User>(userData);

            _userRepository.AddUser(user);
            await _userRepository.SaveUser();

            return Ok(user);
        }
    }
}
