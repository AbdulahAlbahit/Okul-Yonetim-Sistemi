using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entity
{
    public class Program
    {
        [Key]
        public int Program_Id { get; set; }
        public DateOnly date {  get; set; }
        public TimeOnly time {  get; set; }
        [ForeignKey("ders")]
        public int ders_Id {  get; set; }
        public Ders ders { get; set; }

    }
}
