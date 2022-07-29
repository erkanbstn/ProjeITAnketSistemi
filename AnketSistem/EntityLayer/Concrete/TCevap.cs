using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TCevap
    {
        [Key] // Veritabanındaki Otomatik Artan Primary Key Tanımı 
        public int CevapID { get; set; } // Cevap Tablosu ID Kolonu 
        public string CevapAd { get; set; } // Cevap Tablosu Ad Kolonu 
        public int PersonelID { get; set; } // Cevap Personel İlişkisi ID Kolonu 
        public virtual TPersonel Personel{ get; set; } // Cevap Tablosu Personel İlişkisi
        public int? SoruID { get; set; } // Cevap Soru İlişkisi ID Kolonu 
        public virtual TSoru Soru { get; set; } // Cevap Tablosu Soru İlişkisi
    }
}
