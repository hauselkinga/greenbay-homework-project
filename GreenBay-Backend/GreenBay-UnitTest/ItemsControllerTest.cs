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
        public void Test1()
        {

        }
    }
}