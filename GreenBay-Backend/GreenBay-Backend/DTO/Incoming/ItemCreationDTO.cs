namespace GreenBay_Backend.DTO.Incoming
{
    public class ItemCreationDTO
    {
        [Required]
        [StringLength(maximumLength: 128, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 2048)]
        public string PhotoURL { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; }
        [Required]
        public string Seller { get; set; } = string.Empty;
    }
}
