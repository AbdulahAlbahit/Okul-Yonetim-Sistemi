using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeliController(IVeliService service) : ControllerBase
    {

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<VeliDetailDto>> AddVeliAsync(UpdateAndCreateVeli veli)
        {

            if(veli==null|| !ModelState.IsValid)
                return BadRequest(ModelState);

            var DetailVeli=await service.AddVeli(veli);

            return Ok(DetailVeli);


        }



        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<VeliDetailDto>>> GetVeliById()
        {
            var list=await service.GetAllVeliAsync();

            if (list == null)
                return NotFound("hic bir veli kaydi bulunmadi");
            return Ok(list);    

        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VeliDetailDto>> GetAllVeliAsync(int id)
        {
            var veli = await service.GetVeliById(id);

            if (veli == null)
                return NotFound("hic bir veli kaydi bulunmadi");
            return Ok(veli);

        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<VeliDetailDto>> UpdateVeliAsync(UpdateAndCreateVeli veli ,int id)
        {
            var UpdatedVeli = await service.UpdateVeli(veli ,id);

            if (UpdatedVeli == null)
                return NotFound("veli bulunmadi");

            return Ok(UpdatedVeli);

        }


        [HttpDelete]
        [Route("")]
        public async Task<ActionResult<bool>> DeleteVeli(int id)
        {
            var Deleted = await service.DeleteVeli(id);

            if (Deleted)
                NoContent();

            return BadRequest(false);
                

        }



    }
}
