namespace GreenBay_Backend.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 64, MinimumLength = 3)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 256, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public int Balance { get; set; } = 0;
        public virtual List<Item> Items { get; set; } = new List<Item>();
    }
}
