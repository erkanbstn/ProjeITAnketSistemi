using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TOpsiyon
    {
        [Key] // Veritabanındaki Otomatik Artan Primary Key Tanımı 
        public int OpsiyonID { get; set; } // Opsiyon Tablosu ID Kolonu 
        public string Opsiyon { get; set; } // Opsiyon Tablosu Ad Kolonu 
        public int SoruID { get; set; } // Opsiyon Soru İlişkisi ID Kolonu 
        public virtual TSoru Soru { get; set; } // Opsiyon Tablosu Soru İlişkisi
    }
}
