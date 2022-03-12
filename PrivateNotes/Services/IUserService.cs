
using PrivateNotes.Models;
using PrivateNotes.ViewModels;

namespace PrivateNotes.Services
{
    public interface IUserService
    {
        public int GetUserId();

        public void Add(RegisterModel model);

        public User GetRegister(RegisterModel model);
        public User CheckLogin(LoginModel model);
    }
}
