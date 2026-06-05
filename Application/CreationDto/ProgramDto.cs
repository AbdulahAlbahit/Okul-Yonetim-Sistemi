using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Application.CreationDto
{
    public class ProgramDto
    {
       
        [Required(ErrorMessage = "Saat Gerekli")]

        public TimeOnly time { get; set; }
  
        public int ders_Id { get; set; }
        public int Hoca_Id {  get; set; }
      //  public int Sinif_id {  get; set; }

    }
}
