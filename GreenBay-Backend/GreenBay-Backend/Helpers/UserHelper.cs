namespace GreenBay_Backend.Helpers
{
    public class UserHelper : IUserHelper
    {
        public readonly IConfiguration _configuration;
        public UserHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("username", user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public string HashPassword(string password)
        {
            SHA256 sha256 = SHA256.Create();
            var passwordBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = sha256.ComputeHash(passwordBytes);
            var hexPassword = Convert.ToHexString(hashedPassword);
            return hexPassword;
        }
    }
}
