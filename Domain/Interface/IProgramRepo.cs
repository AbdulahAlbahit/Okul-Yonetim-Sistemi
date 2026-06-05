using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interface
{
public interface IProgramRepo
    {
        Task<List<Program>> GetProgramAsync(int Sinif_id);
        Task<List<Program>> GetProgramByDayAsync(Days day,int SinifId);

        Task<string> GetDersNameByTimeAsync(Days day, TimeOnly time);
        Task<TimeOnly> GetDateOfDersByDersName(Days day,string name);

        Task<List<Program>> AddProgramAsync(List<Program> program);
        Task<List<Program>> UpdateProgram(List<Program> program);
        Task<Program> UpdateProgramAtDate(Program program, Days Day);
        Task<List<Program>> UpdateProgramAtDate(List<Program> program);
        Task<bool> DeleteListProgramAsync(List<Program> programs); 
        

    }
}
