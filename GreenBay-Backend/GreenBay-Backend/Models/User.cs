namespace GreenBay_Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Balance { get; set; } = 0;
    }
}
