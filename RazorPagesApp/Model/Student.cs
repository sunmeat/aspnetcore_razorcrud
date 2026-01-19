using System.ComponentModel.DataAnnotations;

namespace RazorPagesApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле повинно бути заповнене")]
        [Display(Name = "Ім'я студента")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле повинно бути заповнене")]
        [Display(Name = "Прізвище студента")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Поле повинно бути заповнене")]
        [Display(Name = "Вік")]
        [Range(15, 60, ErrorMessage = "Недопустимий вік")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Поле повинно бути заповнене")]
        [Range(0.0, 12.0, ErrorMessage = "Недопустимий середній бал")]
        [Display(Name = "Середній бал")]
        public double GPA { get; set; }
    }
}