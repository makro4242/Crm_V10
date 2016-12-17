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
        private CrmV10Model db = new CrmV10Model();

        // GET: Yetkilis
        public ActionResult Index()
        {
            return View(db.Yetkili.ToList());
        }

        // GET: Yetkilis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yetkili yetkili = db.Yetkili.Find(id);
            if (yetkili == null)
            {
                return HttpNotFound();
            }
            return View(yetkili);
        }

        // GET: Yetkilis/Create
        public ActionResult Create()
        {
            return View();
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yetkili yetkili = db.Yetkili.Find(id);
            if (yetkili == null)
            {
                return HttpNotFound();
            }
            return View(yetkili);
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yetkili yetkili = db.Yetkili.Find(id);
            if (yetkili == null)
            {
                return HttpNotFound();
            }
            return View(yetkili);
        }

        // POST: Yetkilis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yetkili yetkili = db.Yetkili.Find(id);
            db.Yetkili.Remove(yetkili);
            db.SaveChanges();
            return RedirectToAction("Index");
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
