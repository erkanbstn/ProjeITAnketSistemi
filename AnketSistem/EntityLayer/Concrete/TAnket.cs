using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TAnket
    {
        [Key] // Veritabanındaki Otomatik Artan Primary Key Tanımı 
        public int AnketID { get; set; } // Anket Tablosu ID Kolonu 
        public string AnketAd { get; set; } // Anket Tablosu Ad Kolonu 
        public string AnketTip { get; set; } // Anket Tablosu Tip Kolonu 
        public int SirketID { get; set; } // Anket Şirket İlişkisi ID Kolonu 
        public virtual TSirket Sirket { get; set; } // Anket Tablosu Şirket İlişkisi
        public List<TSoru> Soru { get; set; }  // Soru Tablosu Anket İlişkisi ID Kolonu 
        public List<TYorum> Yorum { get; set; } // Yorum Tablosu Anket İlişkisi ID Kolonu 

    }
}
