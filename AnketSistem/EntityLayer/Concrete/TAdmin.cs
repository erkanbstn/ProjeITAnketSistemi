using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TAdmin
    {
        [Key] // Veritabanındaki Otomatik Artan Primary Key Tanımı 
        public int AdminID { get; set; }  // Admin Tablosu ID Kolonu 
        public string KullaniciAd { get; set; } // Admin Tablosu Kullanıcı Adı Kolonu 
        public string Sifre { get; set; } // Admin Tablosu Şifre Kolonu 
    }
}
