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

namespace Crm_v10.Controllers
{
    public class GorevsController : Controller
    {
        private Crmv10DB db = new Crmv10DB();
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

                db.Gorev.Add(gorev);
                db.SaveChanges();
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
                ViewBag.DurumGosterim = new SelectList(db.Durum.Where(x => x.GosterimDurumu != "0"), "ID", "DurumAdi",gorev.DurumID);
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
                db.Entry(gorev).State = EntityState.Modified;
                db.SaveChanges();
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
                return RedirectToAction("Index");
            }
            else return RedirectToAction("LoginPage", "Home");
        }
        Crmv10DB ctx = new Crmv10DB();
        public JsonResult KoduGetir()
        {
            string veri = "";

            var Sonuc = (from p in ctx.Gorev
                         orderby p.ID
                         select p.ID).ToList();
            if(Sonuc.Count==0)
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
