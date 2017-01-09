using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crm_v10.Models;


namespace Crm_v10.Controllers
{
    public class HomeController : Controller
    {
        private static Crmv10DB db = new Crmv10DB();
        static Kullanicilar infoKullanicilar = new Kullanicilar();
        public ActionResult Index()
        {
            if (Session["KullaniciID"] != null)
            {
                return View();
            }
            else return View("LoginPage");
        }
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(string kullaniciKodu, string sifre)
        {

            if (kullaniciKodu == "Crm" && sifre == "Makrosoft")
            {

                Session["KullaniciID"] = 0;
                Session["KullaniciAd"] ="Crm";
                return RedirectToAction("Index", "Home");


            }
            else
            {
                infoKullanicilar = db.Kullanicilar.SingleOrDefault(x => x.KullaniciKodu == kullaniciKodu && x.KullaniciSifresi == sifre && x.GosterimDurumu!="0");

                if (infoKullanicilar != null)
                {
                    Session["KullaniciID"] = infoKullanicilar.ID;
                    Session["KullaniciAd"] = infoKullanicilar.KullaniciAdi;
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.Mesaj = "Giriş Bilgileri Hatalı";
                    return View();
                }
            }
        }
        public ActionResult CikisYap()
        {
            Session.RemoveAll();
            return RedirectToAction("LoginPage", "Home");
        }

        public ActionResult _404()
        {
            return View();
        }        
    }
}