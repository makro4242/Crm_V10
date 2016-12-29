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
        private Crmv10DB db = new Crmv10DB();

        // GET: SatisElemanlaris
        public ActionResult Index()
        {
            if (Session["KullaniciID"] != null)
            {
                return View(db.SatisElemanlari.Where(x=>x.GosterimDurumu!="0").ToList());
            }

            else return RedirectToAction("LoginPage", "Home");
           
        }

        // GET: SatisElemanlaris/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                SatisElemanlari satisElemanlari = db.SatisElemanlari.Find(id);
                if (satisElemanlari == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(satisElemanlari);

            }

            else return RedirectToAction("LoginPage", "Home");
   }

        // GET: SatisElemanlaris/Create
        public ActionResult Create()
        {
            if (Session["KullaniciID"] != null)
            {
                return View();
            }

            else return RedirectToAction("LoginPage", "Home");
          
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
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                SatisElemanlari satisElemanlari = db.SatisElemanlari.Find(id);
                if (satisElemanlari == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(satisElemanlari);
            }

            else return RedirectToAction("LoginPage", "Home");
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
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                SatisElemanlari satisElemanlari = db.SatisElemanlari.Find(id);
                if (satisElemanlari == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(satisElemanlari);
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: SatisElemanlaris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["KullaniciID"] != null)
            {
                SatisElemanlari satisElemanlari = db.SatisElemanlari.Find(id);
                satisElemanlari.GosterimDurumu = "0";
                //db.SatisElemanlari.Remove(satisElemanlari);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else return RedirectToAction("LoginPage", "Home");
        }
        Crmv10DB ctx = new Crmv10DB();
        public JsonResult KoduGetir(string kod)
        {
            string veri = "";
            var Sonuc = (from p in ctx.SatisElemanlari
                         orderby p.SatisElemaniKodu
                         select p.SatisElemaniKodu).ToList();
            if (Sonuc.Count == 0)
            {
                veri = "1";
            }
            else veri = ((Sonuc[Sonuc.Count - 1]) + 1).ToString();
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
