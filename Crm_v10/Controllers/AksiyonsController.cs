using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crm_v10.Models;
using System.IO;

namespace Crm_v10.Controllers
{
    public class AksiyonsController : Controller
    {
        private Crmv10DB db = new Crmv10DB();
        public static string strfile1 = "";
        public static string strfile2 = "";
        public static string strfile3 = "";
        public static string strfile4 = "";
        public static string strfile5 = "";

        // GET: Aksiyons
        public ActionResult Index()
        {
            if (Session["KullaniciID"] != null)
            {
                var aksiyon = db.Aksiyon.Include(a => a.GorevEkleme);
                return View(aksiyon.ToList());
            }

            else return RedirectToAction("LoginPage", "Home");
        }
        // GET: Aksiyons/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Aksiyon aksiyon = db.Aksiyon.Find(id);
                if (aksiyon == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                ViewBag.File1 = aksiyon.Ekler1 != "" ? aksiyon.Ekler1.ToString().Split('_')[1] : "";
                ViewBag.File2 = aksiyon.Ekler2 != "" ? aksiyon.Ekler2.ToString().Split('_')[1] : "";
                ViewBag.File3 = aksiyon.Ekler3 != "" ? aksiyon.Ekler3.ToString().Split('_')[1] : "";
                ViewBag.File4 = aksiyon.Ekler4 != "" ? aksiyon.Ekler4.ToString().Split('_')[1] : "";
                ViewBag.File5 = aksiyon.Ekler5 != "" ? aksiyon.Ekler5.ToString().Split('_')[1] : "";


                return View(aksiyon);
            }
            else return RedirectToAction("LoginPage", "Home");
        }
        // GET: Aksiyons/Create
        public ActionResult Create()
        {
            if (Session["KullaniciID"] != null)
            {
               
                var AksiyonSecim = new[]
                 {
                 new SelectListItem(){Value = "Telefon", Text= "Telefon"},
                 new SelectListItem(){Value = "Mail", Text= "Mail"},
                 new SelectListItem(){Value = "Yüzyüze Görüşme", Text= "Yüzyüze Görüşme"},
                 };

             
                ViewBag.AksiyonSecim = AksiyonSecim;
                ViewBag.GorevEklemeID =  new SelectList(db.Gorev.Where(x => x.GosterimDurumu != "0"), "Id", "BirlesikGorev");
                return View();
            }

            else return RedirectToAction("LoginPage", "Home");
        }
        // POST: Aksiyons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tarih,Saat,GorevEklemeID,AksiyonSecim,AksiyonNot,Ekler1,Ekler2,Ekler3,Ekler4,Ekler5")] Aksiyon aksiyon)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file1 = Request.Files[0];
                    var file2 = Request.Files[1];
                    var file3 = Request.Files[2];
                    var file4 = Request.Files[3];
                    var file5 = Request.Files[4];

                    if (file1 != null && file1.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file1.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Ekler/"), fileName);
                        file1.SaveAs(path);
                        aksiyon.Ekler1 = "/Content/Ekler/" + DateTime.Now.ToString() + "f1_" + fileName;
                    }
                    else aksiyon.Ekler1 = "";


                    if (file2 != null && file2.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file2.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Ekler/"), fileName);
                        file2.SaveAs(path);
                        aksiyon.Ekler2 = "/Content/Ekler/" + DateTime.Now.ToString() + "f2_" + fileName;
                    }
                    else aksiyon.Ekler2 = "";
                    if (file3 != null && file3.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file3.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Ekler/"), fileName);
                        file3.SaveAs(path);
                        aksiyon.Ekler3 = "/Content/Ekler/" + DateTime.Now.ToString() + "f3_" + fileName;
                    }
                    else aksiyon.Ekler3 = "";

                    if (file4 != null && file4.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file4.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Ekler/"), fileName);
                        file4.SaveAs(path);
                        aksiyon.Ekler4 = "/Content/Ekler/" + DateTime.Now.ToString() + "f4_" + fileName;
                    }
                   else aksiyon.Ekler4 = "";

                    if (file5 != null && file5.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file5.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Ekler/"), fileName);
                        file5.SaveAs(path);
                        aksiyon.Ekler5 = "/Content/Ekler/"+DateTime.Now.ToString() + "f5_" + fileName;
                    }
                    else aksiyon.Ekler5 = "";

                }
                
                db.Aksiyon.Add(aksiyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            var AksiyonSecim = new[]
             {
                 new SelectListItem(){Value = "Telefon", Text= "Telefon"},
                 new SelectListItem(){Value = "Mail", Text= "Mail"},
                 new SelectListItem(){Value = "Yüzyüze Görüşme", Text= "Yüzyüze Görüşme"},
                 };

           
            ViewBag.AksiyonSecim = AksiyonSecim;
            ViewBag.GorevEklemeID = new SelectList(db.Gorev.Where(x => x.GosterimDurumu != "0"), "Id", "BirlesikGorev");
            return View(aksiyon);
        }

        // GET: Aksiyons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["KullaniciID"] != null)
            {
                if (id == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                Aksiyon aksiyon = db.Aksiyon.Find(id);
                if (aksiyon == null)
                {
                    return RedirectToAction("_404", "Home");
                }
                strfile1 = aksiyon.Ekler1.ToString();
                strfile2 = aksiyon.Ekler2.ToString();
                strfile3 = aksiyon.Ekler3.ToString();
                strfile4 = aksiyon.Ekler4.ToString();
                strfile5 = aksiyon.Ekler5.ToString();

               
                var AksiyonSecim = new[]
                 {
                  new SelectListItem(){Value = "Telefon", Text= "Telefon"},
                  new SelectListItem(){Value = "Mail", Text= "Mail"},
                  new SelectListItem(){Value = "Yüzyüze Görüşme", Text= "Yüzyüze Görüşme"},
                 };
              
                ViewBag.Saat = aksiyon.Saat;
                ViewBag.AksiyonSecim = AksiyonSecim;
                ViewBag.GorevEklemeID = new SelectList(db.Gorev, "Id", "BirlesikGorev");
                return View(aksiyon);
            }

            else return RedirectToAction("LoginPage", "Home");
        }
        // POST: Aksiyons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tarih,Saat,GorevEklemeID,AksiyonSecim,AksiyonNot,Ekler1,Ekler2,Ekler3,Ekler4,Ekler5")] Aksiyon aksiyon)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file1 = Request.Files[0];
                    var file2 = Request.Files[1];
                    var file3 = Request.Files[2];
                    var file4 = Request.Files[3];
                    var file5 = Request.Files[4];

                    if (file1 != null && file1.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file1.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Ekler/"), fileName);
                        file1.SaveAs(path);
                        aksiyon.Ekler1 = "/Content/Ekler/" + DateTime.Now.ToString() + "f1_" + fileName;
                    }
                    else aksiyon.Ekler1 = strfile1;

                    if (file2 != null && file2.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file2.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Ekler/"), fileName);
                        file2.SaveAs(path);
                        aksiyon.Ekler2 = "/Content/Ekler/" + DateTime.Now.ToString() + "f2_" + fileName;
                    }
                    else aksiyon.Ekler2 = strfile2;

                    if (file3 != null && file3.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file3.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Ekler/"), fileName);
                        file3.SaveAs(path);
                        aksiyon.Ekler3 = "/Content/Ekler/" + DateTime.Now.ToString() + "f3_" + fileName;
                    }
                    else aksiyon.Ekler3 = strfile3;

                    if (file4 != null && file4.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file4.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Ekler/"), fileName);
                        file4.SaveAs(path);
                        aksiyon.Ekler4 = "/Content/Ekler/" + DateTime.Now.ToString() + "f4_" + fileName;
                    }
                    else aksiyon.Ekler4 = strfile4;

                    if (file5 != null && file5.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file5.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Ekler/"), fileName);
                        file5.SaveAs(path);
                        aksiyon.Ekler5 = "/Content/Ekler/" + DateTime.Now.ToString() + "f5_" + fileName;
                    }
                    else aksiyon.Ekler5 = strfile5;

                }

                //aksiyon.Tarih = DateTime.Now;
                db.Entry(aksiyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            var AksiyonSecim = new[]
             {
                 new SelectListItem(){Value = "Telefon", Text= "Telefon"},
                 new SelectListItem(){Value = "Mail", Text= "Mail"},
                 new SelectListItem(){Value = "Yüzyüze Görüşme", Text= "Yüzyüze Görüşme"},
                 };
           
            ViewBag.AksiyonSecim = AksiyonSecim;
            ViewBag.GorevEklemeID = new SelectList(db.Gorev.Where(x => x.GosterimDurumu != "0"), "Id", "BirlesikGorev");
            return View(aksiyon);
        }

        // GET: Aksiyons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("_404", "Home");
            }
            Aksiyon aksiyon = db.Aksiyon.Find(id);
            if (aksiyon == null)
            {
                return RedirectToAction("_404", "Home");
            }
            ViewBag.File1 = aksiyon.Ekler1 != "" ? aksiyon.Ekler1.ToString().Split('_')[1] : "";
            ViewBag.File2 = aksiyon.Ekler2 != "" ? aksiyon.Ekler2.ToString().Split('_')[1] : "";
            ViewBag.File3 = aksiyon.Ekler3 != "" ? aksiyon.Ekler3.ToString().Split('_')[1] : "";
            ViewBag.File4 = aksiyon.Ekler4 != "" ? aksiyon.Ekler4.ToString().Split('_')[1] : "";
            ViewBag.File5 = aksiyon.Ekler5 != "" ? aksiyon.Ekler5.ToString().Split('_')[1] : "";
            return View(aksiyon);
        }

        // POST: Aksiyons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["KullaniciID"] != null)
            {

                Aksiyon aksiyon = db.Aksiyon.Find(id);
                db.Aksiyon.Remove(aksiyon);
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
