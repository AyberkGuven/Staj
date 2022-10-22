using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.ViewModel
{
    public class BizimViewModel
    {
        public int Id { get; set; }
        public string tupId { get; set; }
        public string coreId { get; set; }
        public int coreSirasi { get; set; }
        public string dcKabloId { get; set; }
        public string sokakAdiId { get; set; }
        public string binaAdi { get; set; }
        public string Blok { get; set; }
        public string aktifKullanici { get; set; }
        public string sipliterAdiId { get; set; }
        public string coreKdSayisi { get; set; }
    }
}