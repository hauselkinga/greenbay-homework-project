namespace GreenBay_Backend.Models
{
    public class Item
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 128, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 2048)]
        public string PhotoURL { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; } = 0;
        [Required]
        public bool IsSellable { get; set; } = true;
        [Required]
        public int UserId { get; set; }
        public int BuyerId { get; set; }
        [Required]
        public virtual User ?User { get; set; }
        public virtual User ?Buyer { get; set; }
    }
}
