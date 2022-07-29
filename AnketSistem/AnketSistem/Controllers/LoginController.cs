using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AnketSistem.Controllers
{
    public class LoginController : Controller
    {
        AdminManager am = new AdminManager(new EFAdminDal());
        SirketManager sm = new SirketManager(new EFSirketDal());
        PersonelManager pm = new PersonelManager(new EFPersonelDal());

        // Genel Login Yönlendirme Sayfası  
        public ActionResult Index()
        {
            return View();
        }

        // Admin Login Sayfası  

        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]

        // Admin Login Sayfası POST İşlemi

        public ActionResult AdminLogin(TAdmin t)
        {
            var bilgi = am.AdminGirisYap(t.KullaniciAd, t.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KullaniciAd, false);
                Session["Role"] = "Admin";
                Session["AdminID"] = bilgi.AdminID;
                return RedirectToAction("Sirketler", "AdminPanel");
            }
            else
            {
                return View();
            }
        }
        // Şirket Login Sayfası  

        public ActionResult SirketLogin()
        {
            return View();
        }
        [HttpPost]

        // Şirket Login Sayfası POST İşlemi

        public ActionResult SirketLogin(TSirket t)
        {
            var bilgi = sm.SirketGirisYap(t.Mudur, t.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Mudur, false);
                Session["Role"] = "Mudur";
                Session["SirketID"] = bilgi.SirketID;
                return RedirectToAction("Anketler", "SirketPanel");
            }
            else
            {
                return View();
            }
        }
        // Personel Login Sayfası  

        public ActionResult PersonelLogin()
        {
            return View();
        }
        [HttpPost]
        // Personel Login Sayfası POST İşlemi

        public ActionResult PersonelLogin(TPersonel t)
        {
            var bilgi = pm.PersonelGirisYap(t.PersonelAd, t.Sifre);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.PersonelAd, false);
                Session["Role"] = "Personel";
                Session["PersonelID"] = bilgi.PersonelID;
                return RedirectToAction("Anketler", "PersonelPanel");
            }
            else
            {
                return View();
            }
        }
        // Sistemden Çıkış ve Authentication Sonu
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}