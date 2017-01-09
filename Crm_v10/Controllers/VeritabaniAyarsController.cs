using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crm_v10.Controllers
{
    public class VeritabaniAyarsController : Controller
    {
        string mesaj = "";
        // GET: VeritabaniAyars
        public ActionResult Index()
        {
            Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            ViewBag.SunucuAd = config.AppSettings.Settings["sqlserver"].Value;
            ViewBag.VeritabaniAd = config.AppSettings.Settings["database"].Value;
            ViewBag.KullaniciAd = config.AppSettings.Settings["kullanici"].Value;
            ViewBag.Sifre = config.AppSettings.Settings["sifre"].Value;
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            
            string sunucuAdi = frm["txtsunucu"];
            string veritabaniAdi = frm["txtdatabase"];
            string kullaniciAdi = frm["txtkullanici"];
            string sifre = frm["txtsifre"];
            if (sunucuAdi.Trim().Length > 0 && veritabaniAdi.Trim().Length > 0 && kullaniciAdi.Trim().Length > 0 && sifre.Trim().Length > 0)
            {
                try
                {
                    Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
                    config.AppSettings.Settings["sqlserver"].Value =sunucuAdi;
                    config.AppSettings.Settings["database"].Value = veritabaniAdi;
                    config.AppSettings.Settings["kullanici"].Value = kullaniciAdi;
                    config.AppSettings.Settings["sifre"].Value = sifre;
                    config.Save();
                    ViewBag.SunucuAd = sunucuAdi;
                    ViewBag.VeritabaniAd = veritabaniAdi;
                    ViewBag.KullaniciAd = kullaniciAdi;
                    ViewBag.Sifre = sifre;
                    ViewBag.Mesaj = "Güncelleme İşlemi Başarılı.";
                }
                catch (Exception ex)
                {
                    ViewBag.Mesaj = "Hata:"+ ex;
                }
               
            }
            else ViewBag.Mesaj = "Lütfen Boş Bırakmayınız!!";
            return View();
        }


    }
}