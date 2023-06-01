namespace GreenBay_IntegrationTest
{
    public class ItemsControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public ItemsControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateItem_UserUnauthorized()
        {
            var item = new ItemCreationDTO
            {
                Name = "Test",
                Description = "Test",
                PhotoURL = "http://test.com",
                Price = 1,
                UserId = 1
            };

            var json = JsonSerializer.Serialize(item);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/items", httpContent);

            Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
            var content = response.Content.ReadAsStringAsync();
            Assert.True(content.Result.Length == 0);
        }
    }
}