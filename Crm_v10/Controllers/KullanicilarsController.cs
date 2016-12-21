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
    public class KullanicilarsController : Controller
    {
        private Crmv10DB db = new Crmv10DB();
       
        // GET: Kullanicilars
        public ActionResult Index()
        {
            if (Session["KullaniciID"] != null)
            {
                if(Session["KullaniciID"].ToString()=="0")
                {
                    return View(db.Kullanicilar.ToList());
                }
                else return RedirectToAction("Index", "Home");

            }

            else return RedirectToAction("LoginPage", "Home");

        }
        // GET: Kullanicilars/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (Session["KullaniciID"].ToString() == "0")
                {
                    if (id == null)
                    {
                        return RedirectToAction("_404", "Home");
                    }
                    Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
                    if (kullanicilar == null)
                    {
                        return RedirectToAction("_404", "Home");
                    }
                    return View(kullanicilar);
                }
                else return RedirectToAction("Index", "Home");
            }

            else return RedirectToAction("LoginPage", "Home");

           
        }

        // GET: Kullanicilars/Create
        public ActionResult Create()
        {

            if (Session["KullaniciID"] != null)
            {
                if (Session["KullaniciID"].ToString() == "0")
                {
                    return View();
                }
                else return RedirectToAction("Index", "Home");
            }

            else return RedirectToAction("LoginPage", "Home");
        }

        // POST: Kullanicilars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KullaniciKodu,KullaniciAdi,KullaniciSifresi")] Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                db.Kullanicilar.Add(kullanicilar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kullanicilar);
        }

        // GET: Kullanicilars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
               
                    if (id == null)
                    {
                        return RedirectToAction("_404", "Home");
                    }
                    Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
                    if (kullanicilar == null)
                    {
                        return RedirectToAction("_404", "Home");
                    }
                    return View(kullanicilar);
            }

            else return RedirectToAction("LoginPage", "Home");

           
        }

        // POST: Kullanicilars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KullaniciKodu,KullaniciAdi,KullaniciSifresi")] Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanicilar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanicilar);
        }

        // GET: Kullanicilars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (Session["KullaniciID"].ToString() == "0")
                {
                    if (id == null)
                    {
                        return RedirectToAction("_404", "Home"); ;
                    }
                    Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
                    if (kullanicilar == null)
                    {
                        return RedirectToAction("_404", "Home");
                    }
                    return View(kullanicilar);
                }
                else return RedirectToAction("Index", "Home");
            }

            else return RedirectToAction("LoginPage", "Home");

          
        }

        // POST: Kullanicilars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanicilar kullanicilar = db.Kullanicilar.Find(id);
            db.Kullanicilar.Remove(kullanicilar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        Crmv10DB ctx = new Crmv10DB();
        public JsonResult KoduGetir(string kod)
        {
            string veri = "";
            string sayisalDeger = "";
            bool sifirdanFarkli = false;
            var Sonuc = (from p in ctx.Kullanicilar
                         where p.KullaniciKodu.StartsWith(kod)
                         orderby p.KullaniciKodu
                         select p.KullaniciKodu).ToList();
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
