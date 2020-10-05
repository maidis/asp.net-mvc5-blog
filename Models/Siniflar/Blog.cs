using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelTripProje.Models.Siniflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        // https://docs.microsoft.com/en-us/previous-versions/aspnet/hh882339(v=vs.110)?redirectedfrom=MSDN
        [AllowHtml]
        public string Aciklama { get; set; }
        public string BlogImage { get; set; }
        public int Goruntulenme { get; set; }
        public ICollection<Yorumlar> Yorumlars { get; set; }
    }
}