using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin_webbds.Models
{
    public class BatDongSanVM
    {
        public int MaBatDongSan { get; set; }
        public string TieuDe { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    }
}