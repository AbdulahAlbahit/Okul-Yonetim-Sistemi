using Application.CreationDto;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.DetailDto;

namespace WepApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SinifController(ISinifService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<System.Collections.Generic.List<Application.DetailDto.SinifDetailDto>>> GetAll()
        {
            var sinifs = await service.GetAllSinifsAsync();
            return System.Linq.Enumerable.ToList(sinifs);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Application.DetailDto.SinifDetailDto>> GetById(int id)
        {
            var sinif = await service.GetSinifByIdAsync(id);
            if (sinif == null || sinif.Sinif_Id == 0)
                return NotFound("Sınıf bulunamadı.");
            return sinif;
        }

        [HttpGet("by-no/{sinifNo}")]
        public async Task<ActionResult<SinifDetailDto>> GetBySinifNo(string sinifNo)
        {
            var sinif = await service.GetSinifBySinifNoAsync(sinifNo);
            if (sinif == null || sinif.Sinif_Id == 0)
                return NotFound("Sınıf bulunamadı.");
            return sinif;
        }

        [HttpPost]
        public async Task<ActionResult<SinifDetailDto>> Create([FromBody] CreateAndUpdateSinifDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdSinif = await service.AddSinifAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSinif.Sinif_Id }, createdSinif);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SinifDetailDto>> Update(int id, [FromBody] CreateAndUpdateSinifDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedSinif = await service.UpdateSinifAsync(id, updateDto);
            if (updatedSinif == null)
                return NotFound("Güncellenecek sınıf bulunamadı.");

            return updatedSinif;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteSinifAsync(id);
            if (!result)
                return NotFound("Silinecek sınıf bulunamadı.");

            return NoContent();
        }
    }
}
