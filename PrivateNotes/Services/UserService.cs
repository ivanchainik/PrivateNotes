using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using PrivateNotes.Models;
using PrivateNotes.ViewModels;

namespace PrivateNotes.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;

        private readonly IHttpContextAccessor _httpContext;

        public UserService(ApplicationContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public void Add(RegisterModel model)
        {
            _context.Users.Add(new User { Email = model.Email, Password = model.Password });
            _context.SaveChanges();
        }

        public User CheckLogin(LoginModel model)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            return user;
        }

        public User GetRegister(RegisterModel model)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            return user;
        }

        public int GetUserId()
        {
            string userEmail = _httpContext.HttpContext.User.Identity.Name;
            //Получает из БД пользователя по текцщему Логину
            User user = _context.Users.FirstOrDefault(p => p.Email == userEmail);
            return user != null ? user.Id : 0;
        }
    }
}
