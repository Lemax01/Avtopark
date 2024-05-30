using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Avtopark
{
    public partial class VoditelGryzovoiAvto
    {
        public int IdGv { get; set; }
        public string Familia { get; set; }
        public string Imia { get; set; }
        public string Otchestvo { get; set; }
        public decimal Zp { get; set; }
        public string Stag { get; set; }
        public string DataRojdeniy { get; set; }
        public string KontNomer { get; set; }

        public virtual GryzovoiAvto IdGvNavigation { get; set; }
    }
}
