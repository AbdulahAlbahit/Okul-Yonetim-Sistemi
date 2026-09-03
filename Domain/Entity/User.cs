using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public  class User
    {
        [Key]
        public int Id { get; set; }
        public string GirisNo { get; set; }
        public string PasswordHash { get; set; }
        public Role Role { get; set; }
        public bool IsFirstLogin { get; set; } = true;

        [ForeignKey("Ogrenci")]
        public int? Ogrenci_id {  get; set; }
        public Ogrenci Ogrenci { get; set; }
        [ForeignKey("Personel")]
        public int? personel_id {  get; set; }
        public Personel Personel { get; set; }  




    }
}
