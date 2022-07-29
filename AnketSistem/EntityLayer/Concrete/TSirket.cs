using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TSirket
    {
        [Key] // Veritabanındaki Otomatik Artan Primary Key Tanımı 
        public int SirketID { get; set; } // Sirket Tablosu ID Kolonu 
        public string SirketAd { get; set; } // Sirket Tablosu Ad Kolonu 
        public string Mudur { get; set; } // Sirket Tablosu Müdür Kolonu 
        public string Sifre { get; set; } // Sirket Tablosu Şifre Kolonu 
        public ICollection<TPersonel> Personel { get; set; } // Sirket Tablosu Personel İlişkisi 
        public ICollection<TAnket> Anket { get; set; } // Sirket Tablosu Anket İlişkisi 

    }
}
