using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DetailDto
{
    public class PersonelDetailDto
    {
        public int PerId { get; set; }
        
        public string Name { get; set; }
        public string? Gender { get; set; }
        public string? email { get; set; }
        public int? age { get; set; }
        public JobTitle jobTitle { get; set; }
        public string UzmanAlani { get; set; }

    }
}
