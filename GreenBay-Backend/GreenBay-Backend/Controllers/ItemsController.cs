namespace GreenBay_Backend.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepository _userRepository;

        public ItemsController(IMapper mapper, IItemRepository itemRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IQueryable<Item>>> GetAllItems([FromQuery] ItemQueryParameters queryParameters)
        {
            List<Item> items;
            List<ItemDTO> result;
            bool pagination = (queryParameters.Size != 0);

            if (!pagination && queryParameters.IsSellable == null)
            {
                items = await _itemRepository.GetItems();
                result = _mapper.Map<List<ItemDTO>>(items);
            } else
            {
                items = await _itemRepository.HandleQueryParams(queryParameters, pagination);
                result = _mapper.Map<List<ItemDTO>>(items);
            }

            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetItemById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ItemDTO> GetItemById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = _itemRepository.GetItemById(id);

            if (item == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<ItemDTO>(item);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateItem(ItemCreationDTO itemCreationDTO)
        {
            var item = _mapper.Map<Item>(itemCreationDTO);

            if (string.IsNullOrEmpty(item.Name)
                || string.IsNullOrEmpty(item.Description)
                || string.IsNullOrEmpty(item.PhotoURL)
                || item.Price <= 0
                || item.UserId <= 0)
            {
                return BadRequest();
            }

            try
            {
                _itemRepository.AddItem(item);
                await _itemRepository.SaveAsync();

                // due to LazyLoading the User property will remain null until it's explicitly accessed or loaded
                await _itemRepository.LoadUserExplicitly(item);
                var result = _mapper.Map<ItemDTO>(item);

                return StatusCode(StatusCodes.Status201Created, result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> BuyItem(int id, [FromBody] int userId)
        {
            if (id <= 0 || userId <= 0)
            {
                return BadRequest("Invalid user or item id!");
            }

            var item = _itemRepository.GetItemById(id);
            var user = _userRepository.GetUserById(userId);
            var seller = _userRepository.GetUserById(item.UserId);

            if (item == null || user == null)
            {
                return NotFound("User or item does not exist!");
            }

            if (!item.IsSellable)
            {
                return BadRequest("Item is already sold!");
            }

            if (user.Balance < item.Price)
            {
                return BadRequest("Not enough GBD on the account to buy this item!");
            }

            try
            {
                item.IsSellable = false;
                item.BuyerId = user.Id;
                _itemRepository.UpdateItem(item);
                await _itemRepository.SaveAsync();

                user.Balance -= item.Price;
                _userRepository.UpdateUser(user);
                await _userRepository.SaveUser();

                seller.Balance += item.Price;
                _userRepository.UpdateUser(seller);
                await _userRepository.SaveUser();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
