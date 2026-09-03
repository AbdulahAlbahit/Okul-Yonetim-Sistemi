using Application.DetailDto;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.CreationDto;
using Application.UpdateDto;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PersonelController(IPersonelService service):ControllerBase
    {

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "Mudur")]
        public async Task<ActionResult<PersonelDetailDto>>  AddPersonleAsync(CreatedPersonelDto personel)
        {
            if(personel == null|| !ModelState.IsValid) 
                return BadRequest(ModelState);
          
            var per=await service.AddPersonelAsync(personel);

            return per;

        }




        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<PersonelDetailDto>>> GetAllPersonelsAsync()
        {
            var personels=await service.GetAllPersonelsAsync();
            if(personels!=null)
                return personels;

            return NotFound("Personel bulunmadi");
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PersonelDetailDto>> GetPersonelByIdAsync(int id)
        {
            var personel=await service.GetPersonelByIdAsync(id);


            if (personel != null)
                return personel;

            return NotFound("Bu id ile bulunan bir personel yok");

        }


        [HttpPut]
        [Route("")]
        [Authorize(Roles = "Mudur")]
        public async Task<ActionResult<PersonelDetailDto>> UpdatePersonelAsync(UpdatePersonelDto personel, int id)
        {

            if (personel == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var per = await service.UpdatePersonelAsync(personel, id);
            if (per == null)
                return NotFound();

            return per;

        }

        [HttpDelete]
        [Route("")]
        [Authorize(Roles = "Mudur")]
        public async Task<ActionResult<bool>> DeletePersonelAsync(int id)
        {
            var Deleted = await service.DeletePersonelByIdAsync(id);
            if (Deleted)
                return Ok(true);


            return NotFound(false);
        }





    }
}
