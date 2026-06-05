//using Application.CreationDto;
//using Application.DetailDto;
//using Application.IServices;
//using Domain.Entity;
//using Microsoft.AspNetCore.Mvc;
//namespace WepApi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class ProgramController(IProgramService service):ControllerBase
//    {

//        [HttpPost]
//        [Route("")]
//        public async Task<ActionResult<ProgramDataDto>>
//            AddProgram(UpdateAndCreateProgramDto program,int Sinif_id)
//        {
//            if (program == null|| !ModelState.IsValid) 
//                return BadRequest(ModelState);
             

//            var programDetailDto = await service.AddProgramAsync(program,Sinif_id);

//            return programDetailDto;


//        }

//        [HttpGet]
//        [Route("")]
//        public async Task<ActionResult<ProgramDataDto>> GetProgramByDay(Days day, int Sinif_id)
//        {
          
//              if( Sinif_id<0)
//                  return BadRequest();
              
//              var Program=await service.GetProgramByDayAsync(day, Sinif_id);
//            if (Program == null)
//                return NotFound();


//            return Program;
//        }

//        [HttpPut]
//        [Route("")]
//        public async Task<ActionResult<ProgramDataDto>> UpdateProgramAtDay(List<ProgramDto> program, Days Day, int Sinif_id)
//        {
//            if(program == null|| !ModelState.IsValid || Sinif_id < 0)
//            {
//                 return BadRequest(ModelState);
//            }

//            var result = await service.UpdateProgramAtDate(program, Day, Sinif_id);

//            if(result==null)
//            {
//                return BadRequest("islem de hata var");

//            }

//            return result;


//        }

//        [HttpPut]
//        [Route("UpdateAllProgram")]
//        public async Task<ActionResult<ProgramDataDto>> UpdateProgram(UpdateAndCreateProgramDto program, int Sinif_id)
//        {
//            if (program == null || !ModelState.IsValid || Sinif_id < 0)
//            {
//                return BadRequest(ModelState);
//            }

//            var result = await service.UpdateProgram(program, Sinif_id);

//            if (result == null)
//            {
//                return BadRequest("islem de hata var");

//            }

//            return result;


//        }



//    }
//}
