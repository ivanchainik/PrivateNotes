
using PrivateNotes.Models;
using PrivateNotes.ViewModels;

namespace PrivateNotes.Services
{
    public interface IUserService
    {
        public int GetUserId(string userEmail);

        public void Add(RegisterModel model);

        public User GetRegister(RegisterModel model);
        public User GetLogin(LoginModel model);
    }
}
