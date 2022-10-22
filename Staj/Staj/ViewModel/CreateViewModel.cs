using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Staj.ViewModel
{
    public class CreateViewModel
    {
        public byte tupId { get; set; }
        public byte coreId { get; set; }
        public int coreSirasi { get; set; }
        public byte dcKabloId { get; set; }
        public byte sokakAdiId { get; set; }
        public string binaAdi { get; set; }
        public string Blok { get; set; }
        public string aktifKullanici { get; set; }
        public byte sipliterAdiId { get; set; }
        public string coreKdSayisi { get; set; }
    }
}