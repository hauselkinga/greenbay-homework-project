namespace GreenBay_UnitTest
{
    public class ItemsControllerTest
    {
        private readonly ItemsController _sut;
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IItemRepository> _itemRepoMock = new Mock<IItemRepository>();
        private readonly Mock<IUserRepository> _userRepoMock = new Mock<IUserRepository>();

        public ItemsControllerTest()
        {
            _sut = new ItemsController(_mapperMock.Object, _itemRepoMock.Object, _userRepoMock.Object);
        }

        [Fact]
        public async Task GetAllItems_ShouldReturnAllItems_WhenNoQueryParams()
        {
            // ARRANGE
            var items = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    Name = "Test",
                    Description = "Test",
                    PhotoURL = "http://test.com",
                    Price = 1,
                    IsSellable = true,
                    UserId = 1,
                    BuyerId = 0
                },
                new Item
                {
                    Id = 2,
                    Name = "Test_2",
                    Description = "Test_2",
                    PhotoURL = "http://test.com",
                    Price = 2,
                    IsSellable = true,
                    UserId = 1,
                    BuyerId = 0
                }
            };

            var itemsDTO = new List<ItemDTO>
            {
                new ItemDTO
                {
                    Id = 1,
                    Name = "Test",
                    Description = "Test",
                    PhotoURL = "http://test.com",
                    Price = 1,
                    Seller = "Test_User",
                    IsSellable = true,
                    Buyer = ""
                },
                new ItemDTO
                {
                    Id = 2,
                    Name = "Test_2",
                    Description = "Test_2",
                    PhotoURL = "http://test.com",
                    Price = 2,
                    Seller = "Test_User",
                    IsSellable = true,
                    Buyer = ""
                }
            };

            var queryParams = new ItemQueryParameters();

            _itemRepoMock.Setup(repo => repo.GetItems()).ReturnsAsync(items);
            _mapperMock.Setup(mapper => mapper.Map<List<ItemDTO>>(items)).Returns(itemsDTO);

            // ACT
            var result = await _sut.GetAllItems(queryParams);
            var resultValue = (result.Result as OkObjectResult)!.Value as List<ItemDTO>;

            // ASSERT
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(itemsDTO, resultValue);
            _itemRepoMock.Verify(x => x.GetItems(), Times.Once());
            _itemRepoMock.Verify(x => x.HandleQueryParams(queryParams, true), Times.Never());
            _mapperMock.VerifyAll();
        }
    }
}