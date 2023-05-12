namespace GreenBay_Backend.DTO.Incoming
{
    public class UserCreationDTO
    {
        [JsonPropertyName("username")]
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(3, ErrorMessage = "The username must be at least 3 characters long")]
        [MaxLength(64, ErrorMessage = "The username must be maximum 64 characters long")]
        public string UserName { get; set; } = string.Empty;
        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters long")]
        [MaxLength(256)]
        public string Password { get; set; } = string.Empty;
    }
}
