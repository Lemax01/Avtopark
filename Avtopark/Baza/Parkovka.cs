using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Avtopark
{
    public partial class Parkovka
    {
        public Parkovka()
        {
            GryzovoiAvto = new HashSet<GryzovoiAvto>();
            LegkovoiAvto = new HashSet<LegkovoiAvto>();
        }

        public int IdPar { get; set; }
        public string Nazvanie { get; set; }
        public string Gorod { get; set; }
        public string Ylica { get; set; }
        public string Dom { get; set; }
        public string ChisloAvto { get; set; }
        public string KontNomer { get; set; }
        public string KontLico { get; set; }
        public int? IdL { get; set; }
        public int? IdG { get; set; }

        public virtual ICollection<GryzovoiAvto> GryzovoiAvto { get; set; }
        public virtual ICollection<LegkovoiAvto> LegkovoiAvto { get; set; }
    }
}
