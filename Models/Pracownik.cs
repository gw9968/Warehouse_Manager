namespace Warehouse_Manager.Models
{
    public class Pracownik
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public bool Zalogowany {  get; set; }

        public ICollection<Log> Logi { get; set; }
    }
}
