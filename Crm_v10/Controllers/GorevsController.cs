using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crm_v10.Models;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Configuration;

namespace Crm_v10.Controllers
{
    public class GorevsController : Controller
    {
        private Crmv10DB db = new Crmv10DB();
        public static string gecerliSatisElemani = "";
        public static string gecerliSatisElemaniEmail = "";
        public static int gecerliSatisElemaniID = 0;
        public Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");

        // GET: GorevEklemes
        public ActionResult Index()
        {
            if (Session["KullaniciID"] != null)
            {
                var gorev = db.Gorev.Include(g => g.Potansiyel).Include(g => g.SatisElemanlari).Where(x => x.GosterimDurumu != "0");
                return View(gorev.ToList());

            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // GET: GorevEklemes/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Gorev gorev = db.Gorev.Find(id);
                if (gorev == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(gorev);
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // GET: GorevEklemes/Create
        public ActionResult Create()
        {
            if (Session["KullaniciID"] != null)
            {
                var ParaGosterim = new[]
               {
                 new SelectListItem(){Value = "TL", Text= "TL"},
                 new SelectListItem(){Value = "DOLAR", Text= "DOLAR"},
                 new SelectListItem(){Value = "EURO", Text= "EURO"},
               };
                var OncelikGosterim = new[]
                {
                 new SelectListItem(){Value = "Normal", Text= "Normal"},
                 new SelectListItem(){Value = "Düşük", Text= "Düşük"},
                 new SelectListItem(){Value = "Yüksek", Text= "Yüksek"},
                 new SelectListItem(){Value = "Acil", Text= "Acil"},
               };

                ViewBag.ParaBirimi = ParaGosterim;
                ViewBag.DurumGosterim = new SelectList(db.Durum.Where(x => x.GosterimDurumu != "0"), "ID", "DurumAdi");
                ViewBag.OncelikGosterim = OncelikGosterim;
                ViewBag.PotansiyelID = new SelectList(db.Potansiyel.Where(x => x.GosterimDurumu != "0"), "ID", "PotansiyelUnvani");
                ViewBag.SatisElemaniID = new SelectList(db.SatisElemanlari.Where(x => x.GosterimDurumu != "0"), "ID", "SatisElemaniAdiSoyadi");
                return View();
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: GorevEklemes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Aciklama,Tarih,PotansiyelID,SatisElemaniID,ParaBirimi,TahminiTutar,GorevNot,DurumID,Oncelik")] Gorev gorev)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    db.Gorev.Add(gorev);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.Mesaj = "Hata:" + ex;
                }
                finally
                {
                    try
                    {
                        int sonKaydedilenGorevID = gorev.ID;
                        string saticiEmail = db.SatisElemanlari.SingleOrDefault(x => x.ID == gorev.SatisElemaniID).SatisElemaniEmail;
                        MailMessage mesaj = new MailMessage();
                        mesaj.From = new MailAddress(config.AppSettings.Settings["email"].Value);
                        mesaj.To.Add(saticiEmail);
                        mesaj.Subject = "Emek Crm Görev Ataması";
                        mesaj.Body = Session["KullaniciAd"] + " adlı kullanıcı size görev ataması yapmıştır. Görev No:" + sonKaydedilenGorevID + "   Görev Açıklama:" + (gorev.Aciklama == null ? "Açıklama Yapılmamış." : gorev.Aciklama) + " Görev Not:" + gorev.GorevNot;
                        mesaj.IsBodyHtml = true; // giden mailin içeriği html olmasını istiyorsak true kalması lazım
                        SmtpClient client = new SmtpClient("smtp.yandex.com.tr", 587);
                        client.Credentials = new NetworkCredential(config.AppSettings.Settings["email"].Value, config.AppSettings.Settings["emailSifre"].Value);
                        client.EnableSsl = true;
                        client.Send(mesaj);


                    }
                    catch (Exception ex)
                    {
                        ViewBag.Mesaj = "Hata:" + ex;
                    }
                }



                return RedirectToAction("Index");
            }
            var ParaGosterim = new[]
               {
                 new SelectListItem(){Value = "TL", Text= "TL"},
                 new SelectListItem(){Value = "DOLAR", Text= "DOLAR"},
                 new SelectListItem(){Value = "EURO", Text= "EURO"},
               };

            var OncelikGosterim = new[]
                {
                 new SelectListItem(){Value = "Normal", Text= "Normal"},
                 new SelectListItem(){Value = "Düşük", Text= "Düşük"},
                 new SelectListItem(){Value = "Yüksek", Text= "Yüksek"},
                 new SelectListItem(){Value = "Acil", Text= "Acil"},
               };

            ViewBag.ParaGosterim = ParaGosterim;
            ViewBag.DurumGosterim = new SelectList(db.Durum.Where(x => x.GosterimDurumu != "0"), "ID", "DurumAdi", gorev.DurumID);
            ViewBag.OncelikGosterim = OncelikGosterim;
            ViewBag.PotansiyelID = new SelectList(db.Potansiyel.Where(x => x.GosterimDurumu != "0"), "ID", "PotansiyelUnvani", gorev.PotansiyelID);
            ViewBag.SatisElemaniID = new SelectList(db.SatisElemanlari.Where(x => x.GosterimDurumu != "0"), "ID", "SatisElemaniAdiSoyadi", gorev.SatisElemaniID);
            return View(gorev);
        }

        // GET: GorevEklemes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Gorev gorev = db.Gorev.Find(id);
                gecerliSatisElemaniID = gorev.SatisElemanlari.ID;
                gecerliSatisElemani = gorev.SatisElemanlari.SatisElemaniAdiSoyadi;
                gecerliSatisElemaniEmail = gorev.SatisElemanlari.SatisElemaniEmail;
                if (gorev == null)
                {
                    return RedirectToAction("_404", "Home");
                }

                var OncelikGosterim = new[]
               {
               new SelectListItem(){Value = "Normal", Text= "Normal",Selected=(gorev.Oncelik=="Normal" ? true : false)},
               new SelectListItem(){Value = "Düşük", Text= "Düşük",Selected=(gorev.Oncelik=="Düşük" ? true : false)},
               new SelectListItem(){Value = "Yüksek", Text= "Yüksek",Selected=(gorev.Oncelik=="Yüksek" ? true : false)},
               new SelectListItem(){Value = "Acil", Text= "Acil",Selected=(gorev.Oncelik=="Acil" ? true : false)},
               };

                var ParaGosterim = new[]
                 {
                 new SelectListItem(){Value = "TL", Text= "TL", Selected=(gorev.ParaBirimi=="TL" ? true : false)},
                 new SelectListItem(){Value = "DOLAR", Text= "DOLAR", Selected=(gorev.ParaBirimi=="DOLAR" ? true : false)},
                 new SelectListItem(){Value = "EURO", Text= "EURO", Selected=(gorev.ParaBirimi=="EURO" ? true : false)},
                };
                ViewBag.ParaGosterim = ParaGosterim;
                ViewBag.TahminiTutar = gorev.TahminiTutar;
                ViewBag.DurumGosterim = new SelectList(db.Durum.Where(x => x.GosterimDurumu != "0"), "ID", "DurumAdi", gorev.DurumID);
                ViewBag.OncelikGosterim = OncelikGosterim;
                ViewBag.PotansiyelID = new SelectList(db.Potansiyel.Where(x => x.GosterimDurumu != "0"), "ID", "PotansiyelUnvani", gorev.PotansiyelID);
                ViewBag.SatisElemaniID = new SelectList(db.SatisElemanlari.Where(x => x.GosterimDurumu != "0"), "ID", "SatisElemaniAdiSoyadi", gorev.SatisElemaniID);

                return View(gorev);
            }

            else return RedirectToAction("LoginPage", "Home");
        }


        // POST: GorevEklemes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Aciklama,Tarih,PotansiyelID,SatisElemaniID,ParaBirimi,TahminiTutar,GorevNot,DurumID,Oncelik")] Gorev gorev)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(gorev).State = EntityState.Modified;
                    db.SaveChanges();
                    if (gecerliSatisElemaniID == gorev.SatisElemaniID) // Satış Elemanı Değiştirilmedi Kayıt Güncellendi. Satış Elemanına Güncelleme Mesajı Gidecek
                    {

                        MailMessage GuncelemeMesaj = new MailMessage();
                        GuncelemeMesaj.From = new MailAddress(config.AppSettings.Settings["email"].Value);
                        GuncelemeMesaj.To.Add(gecerliSatisElemaniEmail);
                        GuncelemeMesaj.Subject = "Emek Crm Görev Güncelleme";
                        GuncelemeMesaj.Body = Session["KullaniciAd"] + " adlı kullanıcı size görev atamasında güncelleme yaptı. Görev No:" + gorev.ID + "   Görev Açıklama:" + (gorev.Aciklama == null ? "Açıklama Yapılmamış." : gorev.Aciklama) + " Görev Not:" + gorev.GorevNot;
                        GuncelemeMesaj.IsBodyHtml = true; // giden mailin içeriği html olmasını istiyorsak true kalması lazım
                        SmtpClient GuncellemeClient = new SmtpClient("smtp.yandex.com.tr", 587);
                        GuncellemeClient.Credentials = new NetworkCredential(config.AppSettings.Settings["email"].Value, config.AppSettings.Settings["emailSifre"].Value);
                        GuncellemeClient.EnableSsl = true;
                        GuncellemeClient.Send(GuncelemeMesaj);
                    }
                    else // Satış Elemanı Seçimi Değiştirildi. Kayıt Güncellendi. Önceki Satış Elemanının Görev İptal Oldu. İptal mili ve yeni görev maili gönderilecek.
                    {
                        try
                        {
                            //--------GÖREV İPTAL MALİ-------------------------

                            MailMessage GorevIptalMesaj = new MailMessage();
                            GorevIptalMesaj.From = new MailAddress(config.AppSettings.Settings["email"].Value);
                            GorevIptalMesaj.To.Add(gecerliSatisElemaniEmail);
                            GorevIptalMesaj.Subject = "Emek Crm Görev İptali";
                            GorevIptalMesaj.Body = Session["KullaniciAd"] + " adlı kullanıcı size görev atamasında iptal işlemi gerçekleşti. Görev No:" + gorev.ID + "   Görev Açıklama:" + (gorev.Aciklama == null ? "Açıklama Yapılmamış." : gorev.Aciklama) + " Görev Not:" + gorev.GorevNot;
                            GorevIptalMesaj.IsBodyHtml = true; // giden mailin içeriği html olmasını istiyorsak true kalması lazım
                            SmtpClient GorevIptalClient = new SmtpClient("smtp.yandex.com.tr", 587);
                            GorevIptalClient.Credentials = new NetworkCredential("sema@makrosoftbilisim.com", "sema12");
                            GorevIptalClient.EnableSsl = true;
                            GorevIptalClient.Send(GorevIptalMesaj);

                            //-----------YENİ SATIS ELEMANI GÖREV ATAMASI----------------------------
                            string saticiEmail = db.SatisElemanlari.SingleOrDefault(x => x.ID == gorev.SatisElemaniID).SatisElemaniEmail;
                            MailMessage YeniGorevMesaj = new MailMessage();
                            YeniGorevMesaj.From = new MailAddress(config.AppSettings.Settings["email"].Value);
                            YeniGorevMesaj.To.Add(saticiEmail);
                            YeniGorevMesaj.Subject = "Emek Crm Görev Ataması";
                            YeniGorevMesaj.Body = Session["KullaniciAd"] + " adlı kullanıcı size görev ataması yapmıştır. Görev No:" + gorev.ID + "   Görev Açıklama:" + (gorev.Aciklama == null ? "Açıklama Yapılmamış." : gorev.Aciklama) + " Görev Not:" + gorev.GorevNot;
                            YeniGorevMesaj.IsBodyHtml = true; // giden mailin içeriği html olmasını istiyorsak true kalması lazım
                            SmtpClient YeniGorevClient = new SmtpClient("smtp.yandex.com.tr", 587);
                            YeniGorevClient.Credentials = new NetworkCredential(config.AppSettings.Settings["email"].Value, config.AppSettings.Settings["emailSifre"].Value);
                            YeniGorevClient.EnableSsl = true;
                            YeniGorevClient.Send(YeniGorevMesaj);
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Mesaj = "Hata:" + ex;
                        }


                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Mesaj = "Hata :" + ex;

                }
                return RedirectToAction("Index");
            }
            var ParaGosterim = new[]
             {
                 new SelectListItem(){Value = "TL", Text= "TL"},
                 new SelectListItem(){Value = "DOLAR", Text= "DOLAR"},
                 new SelectListItem(){Value = "EURO", Text= "EURO"},
               };
            var OncelikGosterim = new[]
                {
                 new SelectListItem(){Value = "Normal", Text= "Normal"},
                 new SelectListItem(){Value = "Düşük", Text= "Düşük"},
                 new SelectListItem(){Value = "Yüksek", Text= "Yüksek"},
                 new SelectListItem(){Value = "Acil", Text= "Acil"},
               };

            ViewBag.ParaGosterim = ParaGosterim;
            ViewBag.DurumGosterim = new SelectList(db.Durum.Where(x => x.GosterimDurumu != "0"), "ID", "DurumAdi", gorev.DurumID);
            ViewBag.OncelikGosterim = OncelikGosterim;
            ViewBag.PotansiyelID = new SelectList(db.Potansiyel.Where(x => x.GosterimDurumu != "0"), "ID", "PotansiyelUnvani", gorev.PotansiyelID);
            ViewBag.SatisElemaniID = new SelectList(db.SatisElemanlari.Where(x => x.GosterimDurumu != "0"), "ID", "SatisElemaniAdiSoyadi", gorev.SatisElemaniID);
            return View(gorev);
        }

        // GET: GorevEklemes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Gorev gorev = db.Gorev.Find(id);
                if (gorev == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(gorev);
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: GorevEklemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["KullaniciID"] != null)
            {
                Gorev gorev = db.Gorev.Find(id);
                gorev.GosterimDurumu = "0";
                //db.Gorev.Remove(gorev);
                db.SaveChanges();

                //--------GÖREV İPTAL MALİ-------------------------
                try
                {
                    gecerliSatisElemaniEmail = gorev.SatisElemanlari.SatisElemaniEmail;
                    MailMessage GorevIptalMesaj = new MailMessage();
                    GorevIptalMesaj.From = new MailAddress(config.AppSettings.Settings["email"].Value);
                    GorevIptalMesaj.To.Add(gecerliSatisElemaniEmail);
                    GorevIptalMesaj.Subject = "Emek Crm Görev İptali";
                    GorevIptalMesaj.Body = Session["KullaniciAd"] + " adlı kullanıcı size görev atamasında iptal işlemi gerçekleşti. Görev No:" + gorev.ID + "   Görev Açıklama:" + (gorev.Aciklama == null ? "Açıklama Yapılmamış." : gorev.Aciklama) + " Görev Not:" + gorev.GorevNot;
                    GorevIptalMesaj.IsBodyHtml = true; // giden mailin içeriği html olmasını istiyorsak true kalması lazım
                    SmtpClient GorevIptalClient = new SmtpClient("smtp.yandex.com.tr", 587);
                    GorevIptalClient.Credentials = new NetworkCredential(config.AppSettings.Settings["email"].Value, config.AppSettings.Settings["emailSifre"].Value);
                    GorevIptalClient.EnableSsl = true;
                    GorevIptalClient.Send(GorevIptalMesaj);

                }
                catch (Exception ex)
                {
                    ViewBag.Mesaj = "Hata:" + ex;
                }

                return RedirectToAction("Index");
            }
            else return RedirectToAction("LoginPage", "Home");
        }
        Crmv10DB ctx = new Crmv10DB();
        public JsonResult KoduGetir() // Görev kodunun otomatik son olan kayıta 1 ekleyip donduruyor
        {
            string veri = "";
            var id = db.Gorev.Max(p => p.ID);

            if (id == 0)
            {
                veri = "1";
            }
            else veri = (id + 1).ToString();


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
