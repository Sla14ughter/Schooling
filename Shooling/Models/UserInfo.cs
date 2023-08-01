using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shooling.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Display(Name = "Фамилия"),
            Required(ErrorMessage = "Введите фамилию"),
            RegularExpression(@"^[А-Я][а-я]+$", ErrorMessage = "Неправильно введена фамилия"),
            StringLength(50),
            MinLength(2)]
        public string Lastname { get; set; }
        [Display(Name = "Имя"),
            Required(ErrorMessage = "Введите имя"),
            RegularExpression(@"^[А-Я][а-я]+$", ErrorMessage = "Неправильно введено имя"),
            StringLength(50),
            MinLength(2)]
        public string Firstname { get; set; }
        [Display(Name = "Отчество"),
            RegularExpression(@"^[А-Я][а-я]+$", ErrorMessage = "Неправильно введено отчество"),
            StringLength(50),
            MinLength(2)]
        public string? Patronymic { get; set; }
        [Display(Name = "Email"),
            UIHint("Адрес электронной почты"),
            EmailAddress,
            Required(ErrorMessage = "Введите Email"),
            RegularExpression(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Неправильно введен email")]
        public string Email { get; set; }
        [Display(Name = "Номер телефона"),
            UIHint("Номер телефона"),
            Required(ErrorMessage = "Введите номер телефона"),
            Phone]
        public string PhoneNumber { get; set; }
        [Display(Name = "Логин"),
            UIHint("Логин"),
            Required(ErrorMessage = "Введите логин"),
            RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Неправильно введен логин"),
            StringLength(16),
            MinLength(3)]
        public string Login { get; set; }
        [Display(Name = "Пароль"),
            UIHint("Пароль"),
            Required(ErrorMessage = "Введите пароль"),
            RegularExpression(@"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s])*$", ErrorMessage = "Неправильно введён пароль"),
            Compare(nameof(ConfirmPassword), ErrorMessage ="Пароли не совпадают"),
            MinLength(8),
            StringLength(16)]
        public string Password { get; set; }
        [Display(Name = "Подтвердите пароль"), NotMapped]
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        [Display(Name = "Согласен на обработку персональных данных"),
            NotMapped,
            Required]
        public bool IsAgree { get; set; }
    }
}
