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
    public class PotansiyelsController : Controller
    {
        private CrmV10Model db = new CrmV10Model();

        // GET: Potansiyels
        public ActionResult Index()
        {
            return View(db.Potansiyel.ToList());
        }

        // GET: Potansiyels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potansiyel potansiyel = db.Potansiyel.Find(id);
            if (potansiyel == null)
            {
                return HttpNotFound();
            }
            return View(potansiyel);
        }

        // GET: Potansiyels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Potansiyels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PotansiyelKodu,PotansiyelUnvani,PotansiyelAdresi,PotansiyelAdresiUINKodu,PotansiyelAdresGpsEnlem,PotansiyelAdresGpsBoylam,PotansiyelUlkeKodu,PotansiyelIl,PotansiyelIlce,PotansiyelVergiDairesi,PotansiyelVergiNumarasi,PotansiyelWebAdresi,PotansiyelIstigalBilgisi,PotansiyelNot,PotansiyelSatisElemani")] Potansiyel potansiyel)
        {
            if (ModelState.IsValid)
            {
                db.Potansiyel.Add(potansiyel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(potansiyel);
        }

        // GET: Potansiyels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potansiyel potansiyel = db.Potansiyel.Find(id);
            if (potansiyel == null)
            {
                return HttpNotFound();
            }
            return View(potansiyel);
        }

        // POST: Potansiyels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PotansiyelKodu,PotansiyelUnvani,PotansiyelAdresi,PotansiyelAdresiUINKodu,PotansiyelAdresGpsEnlem,PotansiyelAdresGpsBoylam,PotansiyelUlkeKodu,PotansiyelIl,PotansiyelIlce,PotansiyelVergiDairesi,PotansiyelVergiNumarasi,PotansiyelWebAdresi,PotansiyelIstigalBilgisi,PotansiyelNot,PotansiyelSatisElemani")] Potansiyel potansiyel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potansiyel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(potansiyel);
        }

        // GET: Potansiyels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Potansiyel potansiyel = db.Potansiyel.Find(id);
            if (potansiyel == null)
            {
                return HttpNotFound();
            }
            return View(potansiyel);
        }

        // POST: Potansiyels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Potansiyel potansiyel = db.Potansiyel.Find(id);
            db.Potansiyel.Remove(potansiyel);
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
