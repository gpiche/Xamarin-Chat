using System;
using System.Linq;
using IdentityServer.Models;

namespace IdentityServer.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ICryptoService _cryptoService;

        public AuthRepository(ApplicationDbContext context, ICryptoService cryptoService)
        {
            _context = context;
            _cryptoService = cryptoService;

            
        }

        public void Add(User newUser)
        {
            var user = GetUserByUsername(newUser.Email);
            if (user != null)
            {
                //todo throw an exception
            }

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public User GetUserById(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public User GetUserByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => String.Equals(u.Email, username));
            return user;
        }


        public bool ValidatePassword(string username, string plainTextPassword)
        {
            var user = _context.Users.FirstOrDefault(u => String.Equals(u.Email, username));
            if (user != null && String.Equals(_cryptoService.HashSha512(plainTextPassword, user.Salt), user.Password) ) return true;
            return false;
        }
    }
}
