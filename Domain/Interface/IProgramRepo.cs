using Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IProgramRepo
    {
        Task<Program> GetProgramByIdAsync(int programId);
        Task<List<Program>> GetProgramBySinifIdAsync(int sinifId);
        Task<List<Program>> GetProgramBySinifIdAndDayAsync(int sinifId, Days day);
        
        Task<List<Program>> AddProgramsAsync(List<Program> programs);
        Task<Program> UpdateProgramAsync(Program program);
        
        Task<bool> DeleteProgramAsync(int programId);
        Task<bool> DeleteProgramsBySinifIdAsync(int sinifId);
        Task<bool> DeleteProgramsBySinifIdAndDayAsync(int sinifId, Days day);
    }
}
