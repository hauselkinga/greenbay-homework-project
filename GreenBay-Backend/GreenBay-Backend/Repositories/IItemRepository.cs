namespace GreenBay_Backend.Repositories
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetItems();
        public Item GetItemById(int id);
        public void AddItem(Item item);
        public Task SaveAsync();
        public Task LoadUserExplicitly(Item item);
    }
}
