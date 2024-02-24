using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin_webbds.Models
{
    public class BatDongSanSearchViewModel
    {
        public string Keyword { get; set; }
        public bool? TrangThai { get; set; }
        public decimal? GiaMin { get; set; }
        public decimal? GiaMax { get; set; }
    }
}