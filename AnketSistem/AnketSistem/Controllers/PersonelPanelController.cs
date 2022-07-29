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
    public class PersonelPanelController : Controller
    {
        // Manager Sınıflarından Nesne Türetilmesi

        AnketManager am = new AnketManager(new EFAnketDal());
        PersonelManager pm = new PersonelManager(new EFPersonelDal());
        SoruManager sm = new SoruManager(new EFSoruDal());
        CevapManager cm = new CevapManager(new EFCevapDal());
        YorumManager ym = new YorumManager(new EFYorumDal());

        // Anketlerin Listelenmesi (Read)
        public ActionResult Anketler()
        {
            int id = Convert.ToInt32(Session["PersonelID"]);
            var sirket = pm.NesneBul(id);
            ViewBag.sirket = sirket.Sirket.SirketAd;
            return View(am.SirketAnketListele(sirket.SirketID));
        }
        // Anket Sorularının Cevaplanıp Veritabanına Gönderilmesi View (Insert)
        public ActionResult AnketCevapla(int id)
        {
            var anket = am.NesneBul(id);
            ViewBag.anket = anket.AnketAd;
            Aktarim.AnketinID = anket.AnketID;
            SoruOpsiyonViewModel sorular = new SoruOpsiyonViewModel();
            sorular.Sorular = sm.AnketSoruListele(id);

            Context c = new Context();
            sorular.Opsiyonlar = c.Opsiyons.Where(b => b.Soru.AnketID == id).ToList();
            return View(sorular);
        }
        [HttpPost]
        // Anket Sorularının Cevaplanıp Veritabanına Gönderilmesi POST (Insert)

        public ActionResult AnketCevapla(TYorum y, TCevap t, string[] accevap, int[] acsoru, string[] radcevap, int[] SoruID, string[] checkcevap)
        {
            int pid = Convert.ToInt32(Session["PersonelID"]);
            if (radcevap != null)
            {
                for (int i = 0; i < radcevap.Length; i++)
                {
                    string[] radcevaplar = radcevap[i].ToString().Split(',');
                    t.PersonelID = pid;
                    for (int d = 0; d < radcevaplar.Length; d++)
                    {
                        t.CevapAd = radcevaplar[0];
                        t.SoruID = Convert.ToInt32(radcevaplar[1].ToString());
                    }
                    cm.NesneEkle(t);
                }
            }

            if (checkcevap != null)
            {
                for (int i = 0; i < checkcevap.Length; i++)
                {
                    string[] checkcevaplar = checkcevap[i].ToString().Split(',');
                    t.PersonelID = pid;
                    for (int d = 0; d < checkcevaplar.Length; d++)
                    {
                        t.CevapAd = checkcevaplar[0];
                        t.SoruID = Convert.ToInt32(checkcevaplar[1].ToString());
                    }
                    cm.NesneEkle(t);
                }
            }
            if (accevap != null)
            {
                for (int i = 0; i < accevap.Length; i++)
                {
                    t.PersonelID = pid;
                    t.CevapAd = accevap[i];
                    t.SoruID = acsoru[i];
                    cm.NesneEkle(t);
                }
            }
            y.AnketID = Aktarim.AnketinID;
            y.PersonelID = pid;
            ym.NesneEkle(y);
            return RedirectToAction("Anketler");
        }
        // Personele Ait Kullanıcı Bilgilerini Düzenleme İşlemi View (Update)

        public ActionResult Profilim()
        {
            int pid = Convert.ToInt32(Session["PersonelID"]);
            return View(pm.NesneBul(pid));
        }
        [HttpPost]
        // Personele Ait Kullanıcı Bilgilerini Düzenleme İşlemi POST (Update)

        public ActionResult Profilim(TPersonel t)
        {
            int pid = Convert.ToInt32(Session["PersonelID"]);
            pm.NesneDuzenle(t);
            return View(pm.NesneBul(pid));
        }
    }
}