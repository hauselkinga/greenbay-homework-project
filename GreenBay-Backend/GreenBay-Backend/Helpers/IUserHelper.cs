namespace GreenBay_Backend.Helpers
{
    public interface IUserHelper
    {
        public string HashPassword(string password);
        public string CreateToken(User user);
        public int GetIdFromToken(StringValues bearerToken);
    }
}
