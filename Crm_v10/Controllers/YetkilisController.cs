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
    public class YetkilisController : Controller
    {
        private Crmv10DB db = new Crmv10DB();
        // GET: Yetkilis
        public ActionResult Index()
        {
            if (Session["KullaniciID"] != null)
            {
                return View(db.Yetkili.Where(x=>x.GosterimDurumu!="0").ToList());
            }

            else return RedirectToAction("LoginPage", "Home");
           
        }

        // GET: Yetkilis/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Yetkili yetkili = db.Yetkili.Find(id);
                if (yetkili == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(yetkili);
            }

            else return RedirectToAction("LoginPage", "Home");
          
        }

        // GET: Yetkilis/Create
        public ActionResult Create()
        {

            if (Session["KullaniciID"] != null)
            {
               
                return View();
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: Yetkilis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,YetkiliKodu,YetkiliAd,YetkiliSoyad,YetkiliGSM1,YetkiliGSM2,YetkiliMail1,YetkiliMail2,YetkiliDogumTarihi")] Yetkili yetkili)
        {
            if (ModelState.IsValid)
            {
                db.Yetkili.Add(yetkili);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yetkili);
        }

        // GET: Yetkilis/Edit/5
        public ActionResult Edit(int? id)
        {

            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Yetkili yetkili = db.Yetkili.Find(id);
                if (yetkili == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                ViewBag.Tel1 = yetkili.YetkiliGSM1;
                ViewBag.Tel2 = yetkili.YetkiliGSM2;
                return View(yetkili);
            }

            else return RedirectToAction("LoginPage", "Home");
           
        }

        // POST: Yetkilis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,YetkiliKodu,YetkiliAd,YetkiliSoyad,YetkiliGSM1,YetkiliGSM2,YetkiliMail1,YetkiliMail2,YetkiliDogumTarihi")] Yetkili yetkili)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yetkili).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yetkili);
        }

        // GET: Yetkilis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Yetkili yetkili = db.Yetkili.Find(id);
                if (yetkili == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(yetkili);
            }

            else return RedirectToAction("LoginPage", "Home");
           
        }

        // POST: Yetkilis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["KullaniciID"] != null)
            {
                Yetkili yetkili = db.Yetkili.Find(id);
                yetkili.GosterimDurumu = "0";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else return RedirectToAction("LoginPage", "Home");
           
        }


        Crmv10DB ctx = new Crmv10DB();
        public JsonResult KoduGetir(string kod)
        {
            string veri = "";
            string sayisalDeger = "";
            bool sifirdanFarkli = false;
            var Sonuc = (from p in ctx.Yetkili
                         where p.GosterimDurumu != "0" && p.YetkiliKodu.StartsWith(kod)
                         orderby p.YetkiliKodu
                         select p.YetkiliKodu).ToList();
            veri = Sonuc[Sonuc.Count - 1];
            //sayisalDeger = veri.Replace(kod, "");
            int sayac = 0;
            string sifirlariTut = "";
            for (int i = 0; i < veri.Length; i++)
            {
                for (int j = 0; j < kod.Length; j++)
                {
                    if (sayac != kod.Length)
                    {
                        if (veri[i] == kod[j])
                        {
                            sayac += 1;
                            i += 1;
                        }
                    }
                }
                if (sifirdanFarkli == false)
                {
                    if (veri[i] == '0')
                    {
                        sifirlariTut += veri[i];
                    }
                    else
                    {
                        sayisalDeger += veri[i];
                        sifirdanFarkli = true;
                    }
                }
                else sayisalDeger += veri[i];
            }
            veri = kod + sifirlariTut + (Convert.ToInt32(sayisalDeger) + 1);
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
