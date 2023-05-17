﻿namespace GreenBay_Backend.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<List<Item>> GetItems()
        {
            var items = _context.Items.ToListAsync();
            return items;
        }

        public Item GetItemById(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            return item!;
        }

        public void AddItem(Item item)
        {
            _context.Items.Add(item);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task LoadUserExplicitly(Item item)
        {
            return _context.Entry(item)
                .Reference(i => i.User)
                .LoadAsync();
        }
    }
}
