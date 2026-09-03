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
    public class SinavController(ISinavService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<System.Collections.Generic.List<SinavDetailDto>>> GetAll()
        {
            var list = await service.GetAllSinavAsync();
            return list;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SinavDetailDto>> GetById(int id)
        {
            var sinav = await service.GetSinavByIdAsync(id);
            if (sinav == null)
                return NotFound("Bu id ile sınav bulunamadı.");
            return sinav;
        }

        [HttpGet("by-ders/{dersId:int}")]
        public async Task<ActionResult<System.Collections.Generic.List<SinavDetailDto>>> GetByDers(int dersId)
        {
            var list = await service.GetSinavlarByDersIdAsync(dersId);
            return list;
        }

        [HttpGet("by-hoca/{hocaId:int}")]
        public async Task<ActionResult<System.Collections.Generic.List<SinavDetailDto>>> GetByHoca(int hocaId)
        {
            var list = await service.GetSinavlarByHocaIdAsync(hocaId);
            return list;
        }

        private bool IsAuthorizedTeacher(int hocaId)
        {
            var personelIdClaim = User.FindFirst("PersonelId")?.Value;
            if (string.IsNullOrEmpty(personelIdClaim) || !int.TryParse(personelIdClaim, out int loggedInHocaId))
                return false;

            return loggedInHocaId == hocaId;
        }

        [HttpPost]
        [Authorize(Roles = "Ogretmen")]
        public async Task<ActionResult<SinavDetailDto>> Create([FromBody] CreateSinavDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!IsAuthorizedTeacher(createDto.Hoca_Id))
                return Forbid("Sadece kendi adınıza sınav oluşturabilirsiniz. Müdürler sınav oluşturamaz.");

            var created = await service.AddSinavAsync(createDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Sinav_Id }, created);
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Ogretmen")]
        public async Task<ActionResult<SinavDetailDto>> Update(int id, [FromBody] UpdateSinavDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingSinav = await service.GetSinavByIdAsync(id);
            if (existingSinav == null) return NotFound();

            if (!IsAuthorizedTeacher(existingSinav.Hoca_Id))
                return Forbid("Sadece kendi sınavlarınızı güncelleyebilirsiniz.");

            var updated = await service.UpdateSinavAsync(id, updateDto);
            if (updated == null)
                return NotFound("Güncellenecek sınav bulunamadı.");

            return updated;
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Ogretmen")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingSinav = await service.GetSinavByIdAsync(id);
            if (existingSinav == null) return NotFound();

            if (!IsAuthorizedTeacher(existingSinav.Hoca_Id))
                return Forbid("Sadece kendi sınavlarınızı silebilirsiniz.");

            var result = await service.DeleteSinavAsync(id);
            if (!result)
                return NotFound("Silinecek sınav bulunamadı.");

            return NoContent();
        }
    }
}
