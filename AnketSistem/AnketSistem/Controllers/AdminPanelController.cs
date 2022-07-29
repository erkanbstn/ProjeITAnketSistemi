using AnketSistem.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnketSistem.Controllers
{
    public class AdminPanelController : Controller
    {
        // Manager Sınıflarından Nesne Türetilmesi
        AnketManager am = new AnketManager(new EFAnketDal());
        AdminManager aam = new AdminManager(new EFAdminDal());
        SirketManager sm = new SirketManager(new EFSirketDal());
        OpsiyonManager om = new OpsiyonManager(new EFOpsiyonDal());
        PersonelManager pm = new PersonelManager(new EFPersonelDal());
        CevapManager cm = new CevapManager(new EFCevapDal());
        YorumManager ym = new YorumManager(new EFYorumDal());
        // ŞİRKET İŞLEMLERİ

        // Şirket Listeleme İşlemi (Read)
        public ActionResult Sirketler()
        {
            return View(sm.GenelListele());
        }
        // Şirket Ekleme İşlemi View (Insert)
        public ActionResult SirketEkle()
        {
            return View();
        }
        // Şirket Ekleme İşlemi POST (Insert) 
        [HttpPost]
        public ActionResult SirketEkle(TSirket t)
        {
            // Otomatik Şifre Oluşumu
            t.Sifre = $"{t.Mudur.Substring(0, 2)}{DateTime.Now.Month}";
            sm.NesneEkle(t);
            return RedirectToAction("Sirketler");
        }
        // Şirket Silme İşlemi (Delete)
        public ActionResult SirketSil(int id)
        {
            sm.NesneSil(sm.NesneBul(id));
            return RedirectToAction("Sirketler");
        }
        // Şirket Düzenleme İşlemi View (Update)
        public ActionResult SirketDuzenle(int id)
        {
            return View(sm.NesneBul(id));
        }
        [HttpPost]
        // Şirket Düzenleme İşlemi POST (Update)
        public ActionResult SirketDuzenle(TSirket t)
        {
            sm.NesneDuzenle(t);
            return RedirectToAction("Sirketler");
        }


        // PERSONEL İŞLEMLERİ 


        // Personel Listeleme İşlemi (Read)
        public ActionResult Personeller()
        {
            return View(pm.GenelListele());
        }

        // Personel Ekleme İşlemi View (Insert)
        public ActionResult PersonelEkle()
        {
            ViewBag.sirket = sm.DropSirket();
            return View();
        }
        [HttpPost]
        // Personel Ekleme İşlemi POST (Insert)
        public ActionResult PersonelEkle(TPersonel t)
        {
            // Otomatik Şifre Oluşumu

            t.Sifre = $"{t.PersonelAd.Substring(0, 2)}{DateTime.Now.Month}";
            pm.NesneEkle(t);
            return RedirectToAction("Personeller");
        }
        // Personel Silme İşlemi (Delete)

        public ActionResult PersonelSil(int id)
        {
            pm.NesneSil(pm.NesneBul(id));
            return RedirectToAction("Personeller");
        }
        // Personel Düzenleme İşlemi View (Insert)
        public ActionResult PersonelDuzenle(int id)
        {
            ViewBag.sirket = sm.DropSirket();
            return View(pm.NesneBul(id));
        }
        [HttpPost]
        // Personel Düzenleme İşlemi POST (Insert)
        public ActionResult PersonelDuzenle(TPersonel t)
        {
            pm.NesneDuzenle(t);
            return RedirectToAction("Personeller");
        }


        // ANKET İŞLEMLERİ


        // Anket Listeleme İşlemi (Read)
        public ActionResult Anketler()
        {
            return View(am.GenelListele());
        }
        // Anket Ekleme İşlemi View (Insert)

        public ActionResult AnketEkle()
        {
            ViewBag.sirket = sm.DropSirket();
            return View();
        }
        [HttpPost]
        // Anket Ekleme İşlemi POST (Insert)

        public ActionResult AnketEkle(TAnket t)
        {
            am.NesneEkle(t);
            return RedirectToAction("Anketler");
        }
        // Anket Silme İşlemi  (Delete)

        public ActionResult AnketSil(int id)
        {
            am.NesneSil(am.NesneBul(id));
            return RedirectToAction("Anketler");
        }
        // Anket Düzenleme İşlemi View (Update)

        public ActionResult AnketDuzenle(int id)
        {
            ViewBag.sirket = sm.DropSirket();
            return View(am.NesneBul(id));
        }
        [HttpPost]
        // Anket Düzenleme İşlemi POST (Update)

        public ActionResult AnketDuzenle(TAnket t)
        {
            am.NesneDuzenle(t);
            return RedirectToAction("Anketler");
        }

        // ANKET SORU İŞLEMLERİ

        SoruManager som = new SoruManager(new EFSoruDal());

        // Anket Soru Ekleme İşlemi View (Insert)

        public ActionResult AnketSoruEkle(int id)
        {
            ViewBag.anket = id;
            return View();
        }
        [HttpPost]
        // Anket Soru Ekleme İşlemi POST (Insert)

        public ActionResult AnketSoruEkle(TSoru t, string SoruTipleri)
        {
            t.SoruTip = SoruTipleri;
            som.NesneEkle(t);
            return RedirectToAction("Anketler");
        }
        // Anket Soru Listeleme İşlemi (Read)

        public ActionResult AnketSoruGoruntule(int id)
        {
            Aktarim.AnketSoruID = id;
            return View(som.AnketSoruListele(id));
        }
        // Anket Soru Silme İşlemi (Delete)

        public ActionResult SoruSil(int id)
        {
            som.NesneSil(som.NesneBul(id));
            return RedirectToAction("AnketSoruGoruntule", new { id = Aktarim.AnketSoruID });
        }
        // Anket Soru Düzenleme İşlemi View (Update)

        public ActionResult SoruDuzenle(int id)
        {
            ViewBag.anket = Aktarim.AnketSoruID;
            return View(som.NesneBul(id));
        }
        [HttpPost]
        // Anket Soru Düzenleme İşlemi POST (Update)

        public ActionResult SoruDuzenle(TSoru t)
        {
            som.NesneDuzenle(t);
            return RedirectToAction("AnketSoruGoruntule", new { id = Aktarim.AnketSoruID });
        }

        // Anket Sonuçları Listeleme İşlemi (Read)
        public ActionResult SonucGoruntule(int id)
        {
            var x = am.NesneBul(id);
            ViewBag.anket = x.AnketID;
            ViewBag.anketad = x.AnketAd;
            return View(cm.GenelListele());
        }


        // Seçimli Sorular İçin Opsiyon Ekleme İşlemi View (Insert)
        public ActionResult SoruOpsiyonBelirle(int id)
        {
            ViewBag.soru = id;
            return View();
        }
        [HttpPost]
        // Seçimli Sorular İçin Opsiyon Ekleme İşlemi POST (Insert)

        public ActionResult SoruOpsiyonBelirle(TOpsiyon t)
        {
            om.NesneEkle(t);
            return RedirectToAction("AnketSoruGoruntule", new { id = Aktarim.AnketSoruID });
        }

        // Seçimli Sorular İçin Opsiyon Listeleme İşlemi (Read)
        public ActionResult SoruOpsiyonlari(int id)
        {
            Aktarim.OpsiyonSoruID = id;
            return View(om.SoruOpsiyonListele(id));
        }

        // Seçimli Sorular İçin Opsiyon Silme İşlemi (Delete)

        public ActionResult SoruOpsiyonSil(int id)
        {
            om.NesneSil(om.NesneBul(id));
            return RedirectToAction("SoruOpsiyonlari", new { id = Aktarim.OpsiyonSoruID });
        }

        // Seçimli Sorular İçin Opsiyon Düzenleme İşlemi View (Update)

        public ActionResult SoruOpsiyonDuzenle(int id)
        {
            return View(om.NesneBul(id));
        }
        [HttpPost]
        // Seçimli Sorular İçin Opsiyon Düzenleme İşlemi POST (Update)
        public ActionResult SoruOpsiyonDuzenle(TOpsiyon t)
        {
            om.NesneDuzenle(t);
            return RedirectToAction("SoruOpsiyonlari", new { id = Aktarim.OpsiyonSoruID });
        }

        // Anket Yorumları Listeleme İşlemi (Read)
        public ActionResult YorumGoruntule(int id)
        {
            ViewBag.anket = id;
            return View(ym.GenelListele());
        }
        // Admin Profil Bilgileri Listeleme İşlemi (Read)

        public ActionResult Profilim()
        {
            int pid = Convert.ToInt32(Session["AdminID"]);
            return View(aam.NesneBul(pid));
        }
        [HttpPost]
        // Admin Profil Bilgileri Düzenleme İşlemi POST (Update)

        public ActionResult Profilim(TAdmin t)
        {
            int pid = Convert.ToInt32(Session["AdminID"]);
            aam.NesneDuzenle(t);
            return View(aam.NesneBul(pid));
        }
    }
}