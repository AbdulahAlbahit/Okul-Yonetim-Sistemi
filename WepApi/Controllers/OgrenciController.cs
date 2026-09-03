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
    public class OgrenciController(IOgrenciService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<System.Collections.Generic.List<OgrenciDetailDto>>> GetAll()
        {
            var list = await service.GetAllOgrenciAsync();
            return list;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OgrenciDetailDto>> GetById(int id)
        {
            var ogrenci = await service.GetOgrenciByIdAsync(id);
            if (ogrenci == null)
                return NotFound("Bu id ile öğrenci bulunamadı.");
            return ogrenci;
        }

        [HttpGet("by-no/{ogrenciNo}")]
        public async Task<ActionResult<OgrenciDetailDto>> GetByNo(string ogrenciNo)
        {
            var ogrenci = await service.GetOgrenciByNoAsync(ogrenciNo);
            if (ogrenci == null)
                return NotFound("Bu numaraya ait öğrenci bulunamadı.");
            return ogrenci;
        }

        [HttpGet("by-sinif/{sinifId:int}")]
        public async Task<ActionResult<System.Collections.Generic.List<OgrenciDetailDto>>> GetBySinif(int sinifId)
        {
            var list = await service.GetOgrencilerBySinifIdAsync(sinifId);
            return list;
        }

        [HttpPost]
        [Authorize(Roles = "MudurYardimcisi,Mudur")]
        public async Task<ActionResult<OgrenciDetailDto>> Create([FromBody] CreateOgrenciDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await service.AddOgrenciAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "MudurYardimcisi,Mudur")]
        public async Task<ActionResult<OgrenciDetailDto>> Update(int id, [FromBody] UpdateOgrenciDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await service.UpdateOgrenciAsync(id, updateDto);
            if (updated == null)
                return NotFound("Güncellenecek öğrenci bulunamadı.");

            return updated;
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "MudurYardimcisi,Mudur")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteOgrenciAsync(id);
            if (!result)
                return NotFound("Silinecek öğrenci bulunamadı.");

            return NoContent();
        }
    }
}
