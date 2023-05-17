﻿namespace GreenBay_Backend.Repositories
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetItems();
        public Item GetItemById(int id);
    }
}