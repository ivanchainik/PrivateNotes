using System.ComponentModel.DataAnnotations;

namespace WebAppSavePrivateNotes.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress(ErrorMessage ="Некоректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        public string ConfirmPassword { get; set; }
    }
}
