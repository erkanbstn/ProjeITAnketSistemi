using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TSoru
    {
        [Key] // Veritabanındaki Otomatik Artan Primary Key Tanımı 
        public int SoruID { get; set; } // Soru Tablosu ID Kolonu 
        public string SoruAd { get; set; } // Soru Tablosu Ad Kolonu 
        public int? AnketID { get; set; } // Soru Anket İlişkisi ID Kolonu 
        public string SoruTip { get; set; } // Soru Tablosu Tip Kolonu 
        public virtual TAnket Anket { get; set; } // Soru Anket İlişkisi
        public List<TCevap> Cevap { get; set; } // Soru Cevap İlişkisi 
        public List<TOpsiyon> Opsiyon { get; set; } // Soru Opsiyon İlişkisi 
    }
}
