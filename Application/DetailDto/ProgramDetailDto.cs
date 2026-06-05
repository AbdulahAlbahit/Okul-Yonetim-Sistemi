using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.DetailDto
{
    public class ProgramDetailDto
    {
        public int Program_Id { get; set; }
        public Days Day { get; set; }
        public TimeOnly time { get; set; }
        [ForeignKey("ders")]
        public string DersName {  get; set; }
        public string HocaName {  get; set; }
        public string Sinif_No {  get; set; }
        

    }
}
