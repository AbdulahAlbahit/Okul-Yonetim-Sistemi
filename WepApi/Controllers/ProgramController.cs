using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using Application.UpdateDto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramController(IProgramService service) : ControllerBase
    {
        // 1. Oku: Tüm haftayı getir
        [HttpGet("by-sinif/{sinifId:int}")]
        public async Task<ActionResult<ProgramDataDto>> GetProgramBySinifId(int sinifId)
        {
            if (sinifId <= 0) return BadRequest("Geçersiz Sınıf ID");

            var programData = await service.GetProgramBySinifIdAsync(sinifId);
            return programData;
        }

        // 2. Çoklu Yazma: Tüm haftayı baştan yarat (Eskileri siler)
        [HttpPost("by-sinif/{sinifId:int}")]
        public async Task<ActionResult<ProgramDataDto>> ReplaceWeeklyProgram(int sinifId, [FromBody] UpdateAndCreateProgramDto program)
        {
            if (!ModelState.IsValid || sinifId <= 0 || program == null)
                return BadRequest(ModelState);

            var result = await service.ReplaceWeeklyProgramAsync(sinifId, program);
            return result;
        }

        // 3. Bölgesel Yazma: Sadece 1 Günü baştan yarat (Diğer günlere dokunmaz)
        [HttpPut("by-sinif/{sinifId:int}/day/{day}")]
        public async Task<ActionResult<ProgramDataDto>> ReplaceDailyProgram(int sinifId, Days day, [FromBody] List<ProgramDto> dailyProgram)
        {
            if (!ModelState.IsValid || sinifId <= 0)
                return BadRequest(ModelState);

            var result = await service.ReplaceDailyProgramAsync(sinifId, day, dailyProgram);
            return result;
        }

        // 4. Nokta Atışı Yazma: Sadece 1 Dersi (hücreyi) güncelle
        [HttpPut("{programId:int}")]
        public async Task<ActionResult<ProgramDetailDto>> UpdateSingleProgram(int programId, [FromBody] UpdateSingleProgramDto updateDto)
        {
            if (!ModelState.IsValid || programId <= 0)
                return BadRequest(ModelState);

            var updatedProgram = await service.UpdateSingleProgramAsync(programId, updateDto);
            if (updatedProgram == null)
                return NotFound("Güncellenecek ders (program kaydı) bulunamadı.");

            return updatedProgram;
        }

        // 5. Nokta Atışı Silme: Sadece 1 Dersi (hücreyi) sil
        [HttpDelete("{programId:int}")]
        public async Task<ActionResult> DeleteSingleProgram(int programId)
        {
            if (programId <= 0) return BadRequest("Geçersiz Program ID");

            var result = await service.DeleteSingleProgramAsync(programId);
            if (!result) return NotFound("Silinecek ders bulunamadı.");

            return NoContent();
        }

        // 6. Toplu Silme: Sınıfın tüm haftalık programını sil
        [HttpDelete("by-sinif/{sinifId:int}")]
        public async Task<ActionResult> DeleteAllProgramsBySinifId(int sinifId)
        {
            if (sinifId <= 0) return BadRequest("Geçersiz Sınıf ID");

            var result = await service.DeleteAllProgramsBySinifIdAsync(sinifId);
            if (!result) return BadRequest("Program silinirken bir hata oluştu.");

            return NoContent();
        }
    }
}
