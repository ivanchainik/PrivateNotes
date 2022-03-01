using System.Linq;
using WebAppSavePrivateNotes.Models;

namespace WebAppSavePrivateNotes.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly ApplicationContext _context;

        public UserManagerService(ApplicationContext context)
        {
            _context = context;
        }
        public int GetUserId(string userEmail)
        {
            //Получает из БД пользователя по текцщему Логину
            User user = _context.Users.FirstOrDefault(p => p.Email == userEmail);
            return user != null ? user.Id : -1;
        }
    }
}
