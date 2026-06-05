using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DetailDto
{
    public class ProgramDataDto
    {
        public Dictionary<Days, List<ProgramDetailDto>> ProgramDetailData { get; set; } = new Dictionary<Days, List<ProgramDetailDto>>();
    }
}
