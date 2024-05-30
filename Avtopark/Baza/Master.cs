using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Avtopark
{
    public partial class Master
    {
        public Master()
        {
            GryzovoiAvto = new HashSet<GryzovoiAvto>();
            LegkovoiAvto = new HashSet<LegkovoiAvto>();
        }

        public int IdMas { get; set; }
        public string Familia { get; set; }
        public string Imia { get; set; }
        public string Otchestvo { get; set; }
        public string KontNomer { get; set; }
        public string Doljnost { get; set; }
        public string Specialetet { get; set; }
        public decimal Zp { get; set; }
        public int? IdL { get; set; }
        public int? IdG { get; set; }

        public virtual ICollection<GryzovoiAvto> GryzovoiAvto { get; set; }
        public virtual ICollection<LegkovoiAvto> LegkovoiAvto { get; set; }
    }
}
