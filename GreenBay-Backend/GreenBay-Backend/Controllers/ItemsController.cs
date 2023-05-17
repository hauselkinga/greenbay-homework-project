namespace GreenBay_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public ItemsController(IMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ItemDTO>>> GetAllItems()
        {
            var items = await _itemRepository.GetItems();
            var result = _mapper.Map<List<ItemDTO>>(items);

            return Ok(result);
        }

        [HttpGet("{id}", Name="GetItemById")]
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
    }
}
