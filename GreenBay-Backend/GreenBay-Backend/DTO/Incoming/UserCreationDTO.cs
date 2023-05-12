namespace GreenBay_Backend.DTO.Incoming
{
    public class UserCreationDTO
    {
        [JsonPropertyName("username")]
        [Required(ErrorMessage = "Username is required.")]
        public string UserName { get; set; } = string.Empty;
        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; } = string.Empty;
    }
}
