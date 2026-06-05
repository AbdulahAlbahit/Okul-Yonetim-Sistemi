using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DetailDto
{
    public class DersDetailDto
    {
        public int Ders_Id { get; set; }
        public string DersAdi { get; set; }
        public int? Kredi { get; set; }
        public List<HocaBilgi> hocaBilgis { get; set; } = new List<HocaBilgi>();





    }
}
