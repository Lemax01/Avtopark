﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Avtopark
{
    public partial class Users
    {

        public int IdPolz { get; set; }
        public string Login { get; set; }
        public string Parol { get; set; }
        public bool IsAdmin { get; set; } 
    }
}