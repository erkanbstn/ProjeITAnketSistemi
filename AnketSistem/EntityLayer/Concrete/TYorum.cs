using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TYorum
    {
        [Key] // Veritabanındaki Otomatik Artan Primary Key Tanımı 
        public int YorumID { get; set; } // Yorum Tablosu ID Kolonu 
        public string YorumAd { get; set; } // Yorum Tablosu Ad Kolonu 
        public int PersonelID { get; set; }  // Yorum Personel İlişkisi ID Kolonu 
        public virtual TPersonel Personel { get; set; }  // Yorum Personel İlişkisi 
        public int? AnketID { get; set; } // Yorum Anket İlişkisi ID Kolonu 
        public virtual TAnket Anket { get; set; }  // Yorum Anket İlişkisi 
    }
}
