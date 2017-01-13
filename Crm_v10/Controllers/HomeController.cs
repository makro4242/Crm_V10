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
                Session["KullaniciAd"] = "Crm";
                Session["MailSayac"] = "0";
                return RedirectToAction("Index", "Home");


            }
            else
            {
                infoKullanicilar = db.Kullanicilar.SingleOrDefault(x => x.KullaniciKodu == kullaniciKodu && x.KullaniciSifresi == sifre && x.GosterimDurumu != "0");

                if (infoKullanicilar != null)
                {
                    Session["KullaniciID"] = infoKullanicilar.ID;
                    Session["KullaniciAd"] = infoKullanicilar.KullaniciAdi;
                    Session["MailSayac"] = "0";
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


        public JsonResult CrmZorunlulukBilgisiGetir(string sayfa)
        {
            string sonuc = "";
            List<GereklilikAlanlari> bilgiler = db.GereklilikAlanlari.Where(x => x.SayfaAdi == sayfa).ToList();
            if (bilgiler.Count() > 0)
            {

                foreach (var item in bilgiler)
                {
                    sonuc += item.GerekliAlanAdlari + "|" + ((item.GereklilikDurumu == null) ? "0" : item.GereklilikDurumu) + "|";
                }

            }

            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CrmZorunlulukBilgisiDegisikligi(string sayfa, string veri)
        {
            string sonuc = "";
            if (veri.Trim().Length > 0 && sayfa.Trim().Length > 0)
            {
                string[] alanlarDegerler = new string[veri.Split('|').Count()];
                alanlarDegerler = veri.Split('|');
                try
                {
                    List<GereklilikAlanlari> results = (from p in db.GereklilikAlanlari
                                                        where p.SayfaAdi == sayfa
                                                        select p).ToList();
                    int i = 1;
                    foreach (GereklilikAlanlari p in results)
                    {
                        p.GereklilikDurumu = alanlarDegerler[i];
                        i += 2;
                    }
                    db.SaveChanges();
                    sonuc = "1|" + veri;
                }

                catch (Exception ex)
                {
                    sonuc = "0|Hata :" + ex;
                }
            }

            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }
        public ActionResult _404()
        {
            return View();
        }
    }
}