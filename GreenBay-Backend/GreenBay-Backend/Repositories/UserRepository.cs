namespace GreenBay_Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public Task SaveUser()
        {
            return _context.SaveChangesAsync();
        }
    }
}
