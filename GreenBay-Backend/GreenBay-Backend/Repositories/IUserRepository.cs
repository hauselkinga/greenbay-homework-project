namespace GreenBay_Backend.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public Task SaveUser();
    }
}
