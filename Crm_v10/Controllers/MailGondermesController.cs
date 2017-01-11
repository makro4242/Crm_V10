using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crm_v10.Controllers
{
    public class MailGondermesController : Controller
    {
        // GET: MailGonderme
        public ActionResult Index()
        {
            if (Session["KullaniciID"] != null)
            {
                if (Session["KullaniciID"].ToString() == "0")
                {
                    Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
                    ViewBag.Email = config.AppSettings.Settings["email"].Value;
                    ViewBag.Sifre = config.AppSettings.Settings["emailSifre"].Value;
                    return View();
                }
                else return RedirectToAction("Index", "Home");
            }
            else return RedirectToAction("LoginPage", "Home");
        }

        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {

            string email = frm["txtemail"];
            string sifre = frm["txtsifre"];
            if (email.Trim().Length > 0 && sifre.Trim().Length > 0)
            {
                try
                {
                    Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
                    config.AppSettings.Settings["email"].Value = email;
                    config.AppSettings.Settings["emailSifre"].Value = sifre;
                    config.Save();
                    ViewBag.Email = email;
                    ViewBag.Sifre = sifre;
                    ViewBag.Mesaj = "Güncelleme İşlemi Başarılı.";
                }
                catch (Exception ex)
                {
                    ViewBag.Mesaj = "Hata:" + ex;
                }

            }
            else ViewBag.Mesaj = "Lütfen Boş Bırakmayınız!!";
            return View();
        }
    }
}