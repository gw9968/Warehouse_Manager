namespace Warehouse_Manager.Models
{
    public class Log
    {
        public int Id { get; set; }
        public int PracownikId { get; set; }
        public int ProduktId { get; set; }
        public string ?Akcja { get; set; }
        public DateTime CzasAkcji { get; set; }

        // Nawigacja do powiązanych obiektów
        public Pracownik Pracownik { get; set; }
        public Produkt Produkt { get; set; }
    }
}
