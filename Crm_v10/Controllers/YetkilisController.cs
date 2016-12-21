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
                return View(db.Yetkili.ToList());
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
                db.Yetkili.Remove(yetkili);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else return RedirectToAction("LoginPage", "Home");
           
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
