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
    public class SatisElemanlarisController : Controller
    {
        private CrmV10 db = new CrmV10();

        // GET: SatisElemanlaris
        public ActionResult Index()
        {
            return View(db.SatisElemanlari.ToList());
        }

        // GET: SatisElemanlaris/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisElemanlari satisElemanlari = db.SatisElemanlari.Find(id);
            if (satisElemanlari == null)
            {
                return HttpNotFound();
            }
            return View(satisElemanlari);
        }

        // GET: SatisElemanlaris/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SatisElemanlaris/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SatisElemaniKodu,SatisElemaniAdiSoyadi")] SatisElemanlari satisElemanlari)
        {
            if (ModelState.IsValid)
            {
                db.SatisElemanlari.Add(satisElemanlari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(satisElemanlari);
        }

        // GET: SatisElemanlaris/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisElemanlari satisElemanlari = db.SatisElemanlari.Find(id);
            if (satisElemanlari == null)
            {
                return HttpNotFound();
            }
            return View(satisElemanlari);
        }

        // POST: SatisElemanlaris/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SatisElemaniKodu,SatisElemaniAdiSoyadi")] SatisElemanlari satisElemanlari)
        {
            if (ModelState.IsValid)
            {
                db.Entry(satisElemanlari).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(satisElemanlari);
        }

        // GET: SatisElemanlaris/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SatisElemanlari satisElemanlari = db.SatisElemanlari.Find(id);
            if (satisElemanlari == null)
            {
                return HttpNotFound();
            }
            return View(satisElemanlari);
        }

        // POST: SatisElemanlaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SatisElemanlari satisElemanlari = db.SatisElemanlari.Find(id);
            db.SatisElemanlari.Remove(satisElemanlari);
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
