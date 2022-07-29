using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TPersonel
    {
        [Key] // Veritabanındaki Otomatik Artan Primary Key Tanımı 
        public int PersonelID { get; set; } // Personel Tablosu ID Kolonu 
        public string PersonelAd { get; set; } // Personel Tablosu Ad Kolonu 
        public string Sifre { get; set; } // Personel Tablosu Şifre Kolonu 
        public int SirketID { get; set; } // Personel Şirket İlişkisi ID Kolonu 
        public virtual TSirket Sirket { get; set; } // Personel Tablosu Şirket İlişkisi
        public ICollection<TCevap> Cevap { get; set; } // Personel Tablosu Cevap İlişkisi 
        public ICollection<TYorum> Yorum { get; set; } // Personel Tablosu Yorum İlişkisi 
    }
}
