using System.ComponentModel.DataAnnotations;

namespace Warehouse_Manager.Models
{
    public class WorkerDTO
    {
        [Required(ErrorMessage = "Imię pracownika jest wymagane!")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Nazwisko pracownika jest wymagane!")]
        public string Nazwisko { get; set; }
        [Required(ErrorMessage = "Login dla pracownika jest wymagane!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Hasło dla pracownika jest wymagane!")]
        public string Haslo { get; set; }
    }
}
