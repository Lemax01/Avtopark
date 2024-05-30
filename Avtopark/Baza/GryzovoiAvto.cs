using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Avtopark
{
    public partial class GryzovoiAvto
    {
        public int IdG { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string ChisloOsei { get; set; }
        public string Gryzopodemnost { get; set; }
        public string GosNomer { get; set; }
        public string ObiemKyzova { get; set; }
        public string MochnostDvigatelay { get; set; }
        public string RashodTopliva { get; set; }
        public int? IdMas { get; set; }
        public int? IdPar { get; set; }

        public virtual Master IdMasNavigation { get; set; }
        public virtual Parkovka IdParNavigation { get; set; }
        public virtual VoditelGryzovoiAvto VoditelGryzovoiAvto { get; set; }
    }
}
