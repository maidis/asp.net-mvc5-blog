using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.Take(3).ToList();
            return View(by);
        }

        
        public ActionResult BlogDetay(int id)
        {
            //var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();

            /*
             Blog yazılarının görüntülenme sayısını göstermek için basit bir yöntem. Daha sonra
             session tabanlı bir çözüme geçmek daha iyi olacaktır.

             https://stackoverflow.com/questions/40047670/count-pageviews-in-mvc-and-log-in-database
             */
            if (by.Deger1 != null)
            {
                var view = by.Deger1.FirstOrDefault();
                view.Goruntulenme++;
                c.SaveChanges();
            }


            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        } 

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}
