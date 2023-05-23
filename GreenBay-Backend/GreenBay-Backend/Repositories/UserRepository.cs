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

        public bool UsernameExists(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName== username);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public User GetUserByUsername(string username)
        {
            var userFromDb = _context.Users.FirstOrDefault(u => u.UserName == username);

            return userFromDb!;
        }

        public User GetUserById(int id)
        {
            var userFromDb = _context.Users.FirstOrDefault(u => u.Id == id);

            return userFromDb!;
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}
