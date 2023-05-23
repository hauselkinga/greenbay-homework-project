namespace GreenBay_Backend.DTO.Outgoing
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty; 
        public string PhotoURL { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Seller { get; set; } = string.Empty;
        public bool IsSellable { get; set; }
        public string Buyer { get; set; } = string.Empty;

    }
}
