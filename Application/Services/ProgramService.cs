using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using Application.UpdateDto;
using AutoMapper;
using Domain.Entity;
using Domain.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProgramService(IProgramRepo programRepo, IMapper mapper) : IProgramService
    {
        public async Task<ProgramDataDto> GetProgramBySinifIdAsync(int sinifId)
        {
            var programs = await programRepo.GetProgramBySinifIdAsync(sinifId);
            return MapToProgramDataDto(programs);
        }

        public async Task<ProgramDataDto> ReplaceWeeklyProgramAsync(int sinifId, UpdateAndCreateProgramDto programDto)
        {
            // 1. Delete all existing records for the week
            await programRepo.DeleteProgramsBySinifIdAsync(sinifId);

            // 2. Add the new ones
            var newPrograms = new List<Program>();

            foreach (var dailyEntry in programDto.ProgramData)
            {
                var day = dailyEntry.Key;
                foreach (var dto in dailyEntry.Value)
                {
                    newPrograms.Add(new Program
                    {
                        Sinif_id = sinifId,
                        Day = day,
                        time = dto.time,
                        ders_Id = dto.ders_Id,
                        Per_id = dto.Hoca_Id
                    });
                }
            }

            await programRepo.AddProgramsAsync(newPrograms);

            // Return fresh data
            return await GetProgramBySinifIdAsync(sinifId);
        }

        public async Task<ProgramDataDto> ReplaceDailyProgramAsync(int sinifId, Days day, List<ProgramDto> dailyProgram)
        {
            // 1. Delete all existing records for that specific DAY
            await programRepo.DeleteProgramsBySinifIdAndDayAsync(sinifId, day);

            // 2. Add the new ones for that day
            var newPrograms = new List<Program>();
            if (dailyProgram != null)
            {
                foreach (var dto in dailyProgram)
                {
                    newPrograms.Add(new Program
                    {
                        Sinif_id = sinifId,
                        Day = day,
                        time = dto.time,
                        ders_Id = dto.ders_Id,
                        Per_id = dto.Hoca_Id
                    });
                }
                await programRepo.AddProgramsAsync(newPrograms);
            }

            // Return fresh data
            return await GetProgramBySinifIdAsync(sinifId);
        }

        public async Task<ProgramDetailDto> UpdateSingleProgramAsync(int programId, UpdateSingleProgramDto updateDto)
        {
            // Update a single cell (e.g. changing just the time or the teacher)
            var program = await programRepo.GetProgramByIdAsync(programId);
            if (program == null) return null;

            program.time = updateDto.time;
            program.ders_Id = updateDto.ders_Id;
            program.Per_id = updateDto.Hoca_Id;

            await programRepo.UpdateProgramAsync(program);

            // Refetch to get includes (like ders name and personel name)
            var updatedProgram = await programRepo.GetProgramByIdAsync(programId);
            return mapper.Map<ProgramDetailDto>(updatedProgram);
        }

        public async Task<bool> DeleteSingleProgramAsync(int programId)
        {
            return await programRepo.DeleteProgramAsync(programId);
        }

        public async Task<bool> DeleteAllProgramsBySinifIdAsync(int sinifId)
        {
            return await programRepo.DeleteProgramsBySinifIdAsync(sinifId);
        }

        // Helper Method to convert List of Programs to Dictionary grouped by Day
        private ProgramDataDto MapToProgramDataDto(List<Program> programs)
        {
            var result = new ProgramDataDto();
            
            if (programs == null || !programs.Any()) 
                return result;

            var groupedByDay = programs
                .OrderBy(p => p.Day)
                .ThenBy(p => p.time)
                .GroupBy(p => p.Day);

            foreach (var group in groupedByDay)
            {
                var mappedList = mapper.Map<List<ProgramDetailDto>>(group.ToList());
                
                // Manual mapping for included navigation properties since AutoMapper might not catch them perfectly
                // depending on the profile. Let's make sure strings are filled.
                for (int i = 0; i < group.Count(); i++)
                {
                    var entity = group.ElementAt(i);
                    var dto = mappedList[i];
                    
                    if (entity.ders != null) dto.DersName = entity.ders.DersAdi;
                    if (entity.Personel != null) dto.HocaName = entity.Personel.Name;
                    if (entity.Sinif != null) dto.Sinif_No = entity.Sinif.SinifNo;
                }

                result.ProgramDetailData.Add(group.Key, mappedList);
            }

            return result;
        }
    }
}
