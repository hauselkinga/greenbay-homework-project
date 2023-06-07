namespace GreenBay_Backend.Helpers
{
    public class UserHelper : IUserHelper
    {
        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("username", user.UserName),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("GreenBayToken")!));

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

        public int GetIdFromToken(StringValues bearerToken)
        {
            string token = bearerToken.ToString().Substring(7);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            return Int32.Parse(jwtSecurityToken.Claims.First(claim => claim.Type == "id").Value);
        }
    }
}
