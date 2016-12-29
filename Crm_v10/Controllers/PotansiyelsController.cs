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
        private Crmv10DB db = new Crmv10DB();
       
        // GET: Potansiyels
        public ActionResult Index()
        {
            if (Session["KullaniciID"] != null)
            {
                return View(db.Potansiyel.Where(x=>x.GosterimDurumu!="0").ToList());
            }

            else return RedirectToAction("LoginPage", "Home");

           
        }

        // GET: Potansiyels/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Potansiyel potansiyel = db.Potansiyel.Find(id);
                if (potansiyel == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(potansiyel);
            }

            else return RedirectToAction("LoginPage", "Home");


           
        }

        // GET: Potansiyels/Create
        public ActionResult Create()
        {
            if (Session["KullaniciID"] != null)
            {

                ViewBag.Yetkili = new SelectList(db.Yetkili.Where(x=>x.GosterimDurumu!="0"), "Id", "FullName");
                ViewBag.Ulke = new SelectList(db.Ulkeler, "Id", "UlkeAdi");
                ViewBag.Il = new SelectList(db.Iller, "Id", "IlAdi");
                ViewBag.SatisElemani = new SelectList(db.SatisElemanlari.Where(x => x.GosterimDurumu != "0"), "Id", "SatisElemaniAdiSoyadi");
                return View();
            }

            else return RedirectToAction("LoginPage", "Home");




        }

        // POST: Potansiyels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PotansiyelKodu,PotansiyelUnvani,PotansiyelAdresi,PotansiyelAdresiUINKodu,PotansiyelYetkiliID,PotansiyelAdresGpsEnlem,PotansiyelAdresGpsBoylam,PotansiyelUlkeKodu,PotansiyelIl,PotansiyelIlce,PotansiyelVergiDairesi,PotansiyelVergiNumarasi,PotansiyelWebAdresi,PotansiyelIstigalBilgisi,PotansiyelNot,PotansiyelSatisElemani")] Potansiyel potansiyel)
        {
            if (ModelState.IsValid)
            {
                db.Potansiyel.Add(potansiyel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Yetkili = new SelectList(db.Yetkili.Where(x => x.GosterimDurumu != "0"), "Id", "FullName");
            ViewBag.Ulke = new SelectList(db.Ulkeler, "Id", "UlkeAdi");
            ViewBag.Il = new SelectList(db.Iller, "Id", "IlAdi");
            ViewBag.SatisElemani = new SelectList(db.SatisElemanlari.Where(x => x.GosterimDurumu != "0"), "Id", "SatisElemaniAdiSoyadi");
            return View(potansiyel);
        }

        // GET: Potansiyels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Potansiyel potansiyel = db.Potansiyel.Find(id);
                if (potansiyel == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                ViewBag.Yetkili = new SelectList(db.Yetkili.Where(x => x.GosterimDurumu != "0"), "Id", "FullName");
                ViewBag.Ulke = new SelectList(db.Ulkeler, "Id", "UlkeAdi");
                ViewBag.Il = new SelectList(db.Iller, "Id", "IlAdi");
                ViewBag.SatisElemani = new SelectList(db.SatisElemanlari.Where(x => x.GosterimDurumu != "0"), "Id", "SatisElemaniAdiSoyadi");
                return View(potansiyel);
            }

            else return RedirectToAction("LoginPage", "Home");



          
        }

        // POST: Potansiyels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PotansiyelKodu,PotansiyelUnvani,PotansiyelAdresi,PotansiyelAdresiUINKodu,PotansiyelYetkiliID,PotansiyelAdresGpsEnlem,PotansiyelAdresGpsBoylam,PotansiyelUlkeKodu,PotansiyelIl,PotansiyelIlce,PotansiyelVergiDairesi,PotansiyelVergiNumarasi,PotansiyelWebAdresi,PotansiyelIstigalBilgisi,PotansiyelNot,PotansiyelSatisElemani")] Potansiyel potansiyel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(potansiyel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Yetkili = new SelectList(db.Yetkili.Where(x => x.GosterimDurumu != "0"), "Id", "FullName");
            ViewBag.Ulke = new SelectList(db.Ulkeler, "Id", "UlkeAdi");
            ViewBag.Il = new SelectList(db.Iller, "Id", "IlAdi");
            ViewBag.SatisElemani = new SelectList(db.SatisElemanlari.Where(x => x.GosterimDurumu != "0"), "Id", "SatisElemaniAdiSoyadi");
            return View(potansiyel);
        }

        // GET: Potansiyels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Potansiyel potansiyel = db.Potansiyel.Find(id);
                if (potansiyel == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                return View(potansiyel);
            }

            else return RedirectToAction("LoginPage", "Home");         
        }

        // POST: Potansiyels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["KullaniciID"] != null)
            {
                Potansiyel potansiyel = db.Potansiyel.Find(id);
                potansiyel.GosterimDurumu = "0";
                //db.Potansiyel.Remove(potansiyel);
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
            var Sonuc = (from p in ctx.Potansiyel
                         where p.PotansiyelKodu.StartsWith(kod)
                         orderby p.PotansiyelKodu
                         select p.PotansiyelKodu).ToList();
            veri = Sonuc[Sonuc.Count - 1];
            //sayisalDeger = veri.Replace(kod, "");
            int sayac = 0;
            string sifirlariTut = "";
            for (int i = 0; i < veri.Length; i++)
            {
                for(int j=0;j<kod.Length;j++)
                {
                    if(sayac!=kod.Length)
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
