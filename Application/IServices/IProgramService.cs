using Application.CreationDto;
using Application.DetailDto;
using Application.UpdateDto;
using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IProgramService
    {
        Task<ProgramDataDto> GetProgramBySinifIdAsync(int sinifId);
        Task<ProgramDataDto> ReplaceWeeklyProgramAsync(int sinifId, UpdateAndCreateProgramDto programDto);
        Task<ProgramDataDto> ReplaceDailyProgramAsync(int sinifId, Days day, List<ProgramDto> dailyProgram);
        Task<ProgramDetailDto> UpdateSingleProgramAsync(int programId, UpdateSingleProgramDto updateDto);
        Task<bool> DeleteSingleProgramAsync(int programId);
        Task<bool> DeleteAllProgramsBySinifIdAsync(int sinifId);
    }
}
