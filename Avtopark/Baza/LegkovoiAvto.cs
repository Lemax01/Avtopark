using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Avtopark
{
    public partial class LegkovoiAvto
    {
        public int IdL { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string TipKyzova { get; set; }
        public string ChisloPassajirov { get; set; }
        public string GosNomer { get; set; }
        public string MochnostDvigatelay { get; set; }
        public string RashodTopliva { get; set; }
        public int? IdPar { get; set; }
        public int? IdMas { get; set; }

        public virtual VoditelLegkovoiAvto IdLNavigation { get; set; }
        public virtual Master IdMasNavigation { get; set; }
        public virtual Parkovka IdParNavigation { get; set; }
    }
}
