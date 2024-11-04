using System.ComponentModel.DataAnnotations;

namespace Warehouse_Manager.Models
{
    public class Produkt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana KURNAAA.")] 
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
        public string Kategoria { get; set; }

        // Nawigacja do powiązanych logów
        public ICollection<Log> Logi { get; set; }
    }
}
