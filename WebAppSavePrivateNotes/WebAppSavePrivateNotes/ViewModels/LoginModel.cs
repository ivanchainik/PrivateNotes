using System.ComponentModel.DataAnnotations;

namespace WebAppSavePrivateNotes.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не верный Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Не верный пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
