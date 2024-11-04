using System.ComponentModel.DataAnnotations;

namespace Warehouse_Manager.Models
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Nazwa produktu jest wymagana!")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Podaj cenę produktu!")]
        public decimal Cena { get; set; }
        [Required(ErrorMessage = "Podaj ilość produktu!")]
        public int Ilosc { get; set; }
        [Required(ErrorMessage = "Nazwa kategorii produktu jest wymagana!")]
        public string Kategoria { get; set; }
    }
}
