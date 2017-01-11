using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crm_v10.Models;

namespace Crm_v10.Controllers
{
    public class MailYedeklemeLogsController : Controller
    {
        private Crmv10DB db = new Crmv10DB();

        // GET: MailYedeklemeLogs
        public ActionResult Index()
        {
            var mailYedeklemeLog = db.MailYedeklemeLog.Include(m => m.Kullanicilar);
            return View(mailYedeklemeLog.ToList());
        }
        public JsonResult Create(string veri)
        {
            string sonuc = ""; //1 olumlu
            try
            {
                int kullaniciID = Convert.ToInt32(Session["KullaniciID"]);
                MailYedeklemeLog mailYedekLogInfo = new MailYedeklemeLog();
                mailYedekLogInfo.KullaniciID = kullaniciID;
                mailYedekLogInfo.Saat = DateTime.Now.ToLongTimeString();
                mailYedekLogInfo.Tarih = DateTime.Now;
                mailYedekLogInfo.Cevap = veri;
                db.MailYedeklemeLog.Add(mailYedekLogInfo);
                db.SaveChanges();
                sonuc = "1";
            }
            catch (Exception ex)
            {
                sonuc = "Hata :" + ex;
            }
            return Json(sonuc, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Kontrol() // Kullanıcı bugun mail yedeklemesi sorusuna cevap vermiş mi 
        {  string veri = "";
            int kullaniciID = Convert.ToInt32(Session["KullaniciID"]);
            var tarih = DateTime.Now.ToString("dd/MM/yyyy")+ " 00:00:00";
            List<MailYedeklemeLog> mailYedeklemeLog = db.MailYedeklemeLog.ToList();
            var sonuc = mailYedeklemeLog.Where(x => x.KullaniciID == kullaniciID && x.Tarih.ToString()==tarih);
            if (sonuc.Count()>0)
            {
                veri = "1";
                Session["MailSayac"] = "1";
            }
            else veri = "0";
            return Json(veri, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
