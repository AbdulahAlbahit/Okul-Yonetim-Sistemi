using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using Application.UpdateDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OgrenciSinavController(IOgrenciSinavService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<OgrenciSinavDetailDto>>> GetAll()
        {
            var list = await service.GetAllOgrenciSinavAsync();
            return list;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OgrenciSinavDetailDto>> GetById(int id)
        {
            var sinav = await service.GetOgrenciSinavByIdAsync(id);
            if (sinav == null)
                return NotFound("Bu id ile öğrenci sınav (not) kaydı bulunamadı.");
            return sinav;
        }

        [HttpGet("by-sinav/{sinavId:int}")]
        public async Task<ActionResult<List<OgrenciSinavDetailDto>>> GetBySinav(int sinavId)
        {
            var list = await service.GetOgrenciSinavlarBySinavIdAsync(sinavId);
            return list;
        }

        [HttpGet("by-ogrenci/{ogrenciId:int}")]
        public async Task<ActionResult<List<OgrenciSinavDetailDto>>> GetByOgrenci(int ogrenciId)
        {
            var list = await service.GetOgrenciSinavlarByOgrenciIdAsync(ogrenciId);
            return list;
        }

        [HttpGet("durum/{ogrenciId:int}/ders/{dersId:int}")]
        public async Task<ActionResult<OgrenciDersSonucDto>> GetDurum(int ogrenciId, int dersId)
        {
            var sonuc = await service.CalculatePassStatusAsync(ogrenciId, dersId);
            
            if (sonuc == null)
                return NotFound("Bu öğrenciye ait bu ders için herhangi bir sınav kaydı bulunamadı.");

            return sonuc;
        }

        [HttpPost]
        [Authorize(Roles = "Ogretmen")]
        public async Task<ActionResult<OgrenciSinavDetailDto>> Create([FromBody] CreateOgrenciSinavDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await service.AddOgrenciSinavAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Ogrenci_Sinav_Id }, created);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Ogretmen")]
        public async Task<ActionResult<OgrenciSinavDetailDto>> Update(int id, [FromBody] UpdateOgrenciSinavDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await service.UpdateOgrenciSinavAsync(id, updateDto);
            if (updated == null)
                return NotFound("Güncellenecek öğrenci sınav (not) kaydı bulunamadı.");

            return updated;
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Ogretmen")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteOgrenciSinavAsync(id);
            if (!result)
                return NotFound("Silinecek öğrenci sınav (not) kaydı bulunamadı.");

            return NoContent();
        }
    }
}
