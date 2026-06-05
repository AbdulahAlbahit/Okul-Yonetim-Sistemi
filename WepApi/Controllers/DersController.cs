using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WepApi.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class DersController(IDersService service):ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<DersDetailDto>>> GetAllDersAsync()
        {
            var list = await service.GetAllDersAsync();
            if (list == null)
                return NotFound("Ders bulunmadi");

            return Ok(list);

        }



        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DersDetailDto>> GetDersByIdAsync(int id)
        {
            var ders=await service.GetDersByIdAsync(id);

            if (ders == null)
                return NotFound("bu id ye sahip ders bulunmadi");

            return Ok(ders);

        }


        [HttpGet]
        [Route("GetByName{name}")]
        public async Task<ActionResult<DersDetailDto>> GetDersByNameAsync(string name)
        {
            var ders=await service.GetDersByName(name);
            if (ders == null)
                return NotFound("Ders bulunmadi");


            return Ok(ders);

        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> AddDersAsync(CreateAndUpdateDersDto ders)
        {
            if (ders == null || !ModelState.IsValid)
                return BadRequest(ModelState);

          var Detail=   await service.AddDersAsync(ders);
            return Ok(Detail);
            
        }


        [HttpPut]
        [Route("")]
        public async Task<ActionResult<DersDetailDto>> UpdateDers(CreateAndUpdateDersDto ders,int id)
        {
            if (ders == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var Detail=await service.UpdateDersAsync(ders, id);

            return Ok(Detail);
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<bool>> DeleteDersAsync(int id)
        {
          var Deleted=await service.DeleteDersAsync(id);
            if (Deleted)
                return Ok(Deleted);

            return BadRequest(Deleted);


        }

        

    }
}
