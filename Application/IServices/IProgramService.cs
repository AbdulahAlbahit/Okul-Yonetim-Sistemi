using Application.CreationDto;
using Application.DetailDto;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IProgramService
    {
        Task<ProgramDataDto> GetProgramByDayAsync(Days day, int Sinif_id);

        Task<string> GetDersNameByTimeAsync(Days day, TimeOnly time);
        Task<TimeOnly> GetDateOfDersByDersName(Days Date,string name);
        Task<ProgramDataDto> AddProgramAsync(UpdateAndCreateProgramDto program, int Sinif_id);
        Task<ProgramDataDto> UpdateProgram(UpdateAndCreateProgramDto program,int Sinif_id);
        Task<ProgramDataDto> UpdateProgramAtDate(List<ProgramDto> program, Days Day, int Sinif_id);
    }
}
