
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public class OgrenciSinav
    {
        [Key]
        public int Ogrenci_Sinav_Id {  get; set; }
        [ForeignKey("Ogrenci")]
        public int Ogrenci_id {  get; set; }
        public Ogrenci Ogrenci {  get; set; }
        [ForeignKey("Sinav")]
        public int Sinav_id {  get; set; }
        public Sinav Sinav { get; set; }
    
    }
}
