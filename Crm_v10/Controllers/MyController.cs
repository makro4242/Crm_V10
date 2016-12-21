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
    public class MyController : Controller
    {
        Crmv10DB ctx = new Crmv10DB();
        // GET: My
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult KoduGetir(string kod)
        {
            string veri = "";
            string sayisalDeger = "";
            bool sifirdanFarkli = false;
            var Sonuc = (from p in ctx.Yetkili
                        where p.YetkiliKodu.StartsWith(kod) orderby p.YetkiliKodu 
                        select   p.YetkiliKodu) .ToList();
            veri = Sonuc[Sonuc.Count - 1];
            sayisalDeger = veri.Replace(kod, "");
            string sifirlariTut = "";
            for (int i=0;i<sayisalDeger.Length;i++)
            {
                if(sifirdanFarkli==false)
                {
                    if (sayisalDeger[i] == '0')
                    {
                        sifirlariTut += sayisalDeger[i];
                    }
                    else sifirdanFarkli = true;
                }           
            }
            veri = kod +sifirlariTut+ (Convert.ToInt32(sayisalDeger)+1);
            return Json(veri, JsonRequestBehavior.AllowGet);
        }

    }
}