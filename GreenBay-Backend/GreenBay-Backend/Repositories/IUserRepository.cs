namespace GreenBay_Backend.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public Task SaveUser();
        public bool UsernameExists(string username);
        public User GetUserByUsername(string username);
    }
}
