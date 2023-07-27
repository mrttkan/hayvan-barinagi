    namespace HayvanBarinagi.Models
    {
        public class SahiplendirmeBasvurulari
        {
            public int Id { get; set; }
            public int HayvanId { get; set; }
            public Hayvan Hayvan { get; set; }
            public string BasvuranKisi { get; set; }
            public DateTime BasvuruTarihi { get; set; } = DateTime.Now;
            public string Durum { get; set; } 
        }

    }
