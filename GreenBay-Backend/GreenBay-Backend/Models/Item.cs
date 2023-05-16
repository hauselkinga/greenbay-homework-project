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
        public string PhotoURL { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; } = 0;
        [Required]
        public virtual User User { get; set; } = new User();
    }
}
