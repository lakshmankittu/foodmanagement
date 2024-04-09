using FoodManagement.FoodDBContext;
using FoodManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace FoodManagement.Services
{
    public class UserService
    {
        private readonly DataDbConext _context;
        private readonly IConfiguration _configuration;

        public UserService(DataDbConext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
        public async Task<bool> IsUserExisit(string id)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (existingUser != null) return true;
            return false;
        }

        public async Task<User> RegisterAsync(string name, string email, string password, string address)
        {

            User? existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (existingUser != null)
            {
                return null;
            }

            User newUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Email = email.ToLower(),
                Password = password,
                Address = address,
                IsAdmin = false
            };
            Console.WriteLine(newUser);
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

       
    }
}
