using Application.DetailDto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CreationDto
{
    public class UpdateAndCreateProgramDto
    {

        public Dictionary<Days,List<ProgramDto>> ProgramData { get; set; }

    }
}
