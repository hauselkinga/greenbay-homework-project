namespace GreenBay_Backend.DTO.Incoming
{
    public class UserCreationDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
