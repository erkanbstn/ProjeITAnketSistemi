using AnketSistem.Models;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnketSistem.Controllers
{
    public class SirketPanelController : Controller
    {

        // Manager Sınıflarından Nesne Türetilmesi

        PersonelManager pm = new PersonelManager(new EFPersonelDal());
        AnketManager am = new AnketManager(new EFAnketDal());
        SirketManager sm = new SirketManager(new EFSirketDal());
        SoruManager som = new SoruManager(new EFSoruDal());
        YorumManager ym = new YorumManager(new EFYorumDal());
        CevapManager cm = new CevapManager(new EFCevapDal());
        OpsiyonManager om = new OpsiyonManager(new EFOpsiyonDal());

        // Şirket Paneli Dashboard Sayfası
        public ActionResult DashBoard()
        {
            int id = Convert.ToInt32(Session["SirketID"]);
            ViewBag.personel = pm.ToplamSirketPersonel(id);
            ViewBag.anket = am.ToplamSirketAnket(id);
            ViewBag.soru = som.ToplamSirketSoru(id);
            ViewBag.yorum = ym.ToplamSirketYorum(id);
            return View(am.SirketAnketSonListele(id));
        }
        // Şirkete Ait Anketlerin Listelendiği View
        public ActionResult Anketler()
        {
            int id = Convert.ToInt32(Session["SirketID"]);
            return View(am.SirketAnketListele(id));
        }
        // Şirkete Ait Personellerin Listelendiği View
        public ActionResult Personeller()
        {
            int id = Convert.ToInt32(Session["SirketID"]);
            return View(pm.SirketPersonelListele(id));
        }
        // Personel Ekleme İşlemi View (Insert)
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        // Personel Ekleme İşlemi POST (Insert)
        public ActionResult PersonelEkle(TPersonel t)
        {
            // Otomatik Şifre Oluşumu
            int id = Convert.ToInt32(Session["SirketID"]);
            t.SirketID = id;
            t.Sifre = $"{t.PersonelAd.Substring(0, 2)}{DateTime.Now.Month}";
            pm.NesneEkle(t);
            return RedirectToAction("Personeller");
        }
        // Personel Silme İşlemi  (Delete)

        public ActionResult PersonelSil(int id)
        {
            pm.NesneSil(pm.NesneBul(id));
            return RedirectToAction("Personeller");
        }
        // Personel Güncelleme İşlemi View (Update)

        public ActionResult PersonelDuzenle(int id)
        {
            return View(pm.NesneBul(id));
        }
        [HttpPost]
        // Personel Güncelleme İşlemi POST (Update)

        public ActionResult PersonelDuzenle(TPersonel t)
        {
            pm.NesneDuzenle(t);
            return RedirectToAction("Personeller");
        }
        // Anket Ekleme İşlemi View (Insert)
        public ActionResult AnketEkle()
        {
            int id = Convert.ToInt32(Session["SirketID"]);
            ViewBag.sirketid = id;
            return View();
        }
        [HttpPost]
        // Anket Ekleme İşlemi POST (Insert)

        public ActionResult AnketEkle(TAnket t)
        {
            am.NesneEkle(t);
            return RedirectToAction("Anketler");
        }
        // Ankete Ait Soruları Ekleme İşlemi View (Insert)

        public ActionResult AnketSoruEkle(int id)
        {
            ViewBag.anket = id;
            return View();
        }
        [HttpPost]
        // Ankete Ait Soruları Ekleme İşlemi POST (Insert)

        public ActionResult AnketSoruEkle(TSoru t, string SoruTipleri)
        {
            t.SoruTip = SoruTipleri;
            som.NesneEkle(t);
            return RedirectToAction("Anketler");
        }
        // Ankete Ait Soruları Görüntüleme İşlemi View (Read)

        public ActionResult AnketSoruGoruntule(int id)
        {
            Aktarim.AnketSoruID = id;
            return View(som.AnketSoruListele(id));
        }
        // Anket Düzenleme İşlemi View (Update)

        public ActionResult AnketDuzenle(int id)
        {
            int sirketid = Convert.ToInt32(Session["SirketID"]);
            ViewBag.sirketid = sirketid;
            return View(am.NesneBul(id));
        }
        [HttpPost]
        // Anket Düzenleme İşlemi POST (Update)

        public ActionResult AnketDuzenle(TAnket t)
        {
            am.NesneDuzenle(t);
            return RedirectToAction("Anketler");
        }
        // Anket Silme İşlemi  (Delete)
        public ActionResult AnketSil(int id)
        {
            am.NesneSil(am.NesneBul(id));
            return RedirectToAction("Anketler");
        }
        // Ankete Ait Soruları Silme İşlemi  (Delete)

        public ActionResult SoruSil(int id)
        {
            som.NesneSil(som.NesneBul(id));
            return RedirectToAction("AnketSoruGoruntule", new { id = Aktarim.AnketSoruID });
        }
        // Ankete Ait Soruları Düzenleme İşlemi  (Update)

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
        // Ankete Ait Sonuçları Görüntüleme İşlemi  (Read)

        public ActionResult SonucGoruntule(int id)
        {
            var x = am.NesneBul(id);
            ViewBag.anket = x.AnketID;
            ViewBag.anketad = x.AnketAd;
            ViewBag.sirket = x.SirketID;
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
        // Anket Yorumları Listeleme İşlemi (Insert)
        public ActionResult YorumGoruntule(int id)
        {
            ViewBag.anket = id;
            return View(ym.GenelListele());
        }
        // Şirkete Ait Kullanıcı Bilgilerini Düzenleme İşlemi View (Update)

        public ActionResult Profilim()
        {
            int pid = Convert.ToInt32(Session["SirketID"]);
            return View(sm.NesneBul(pid));
        }
        [HttpPost]
        // Şirkete Ait Kullanıcı Bilgilerini Düzenleme İşlemi POST (Update)

        public ActionResult Profilim(TSirket t)
        {
            int pid = Convert.ToInt32(Session["SirketID"]);
            sm.NesneDuzenle(t);
            return View(sm.NesneBul(pid));
        }
    }
}