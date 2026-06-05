//using Application.CreationDto;
//using Application.DetailDto;
//using Application.IServices;
//using AutoMapper;
//using Domain.Entity;
//using Domain.Interface;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using System.Text;

//namespace Application.Services
//{
//    public class ProgramService(IProgramRepo ProRepo, IMapper mapper, IDersRepo DersRepo
//        , IPersonelRepo PerRepo, ISinifRepo SinifRepo) : IProgramService
//    {
//        public async Task<ProgramDataDto> AddProgramAsync(UpdateAndCreateProgramDto program, int Sinif_id)
//        {
//            if (program.ProgramData.Values == null || !program.ProgramData.Values.Any())
//                return new ProgramDataDto();

//            var ProgramList = new List<Program>();

//            foreach (var item in program.ProgramData)
//            {
//                var day = item.Key;
//                foreach (var elem in item.Value)
//                {
//                    var obj = new Program
//                    {
//                        Day = day,
//                        ders_Id = elem.ders_Id,
//                        time = elem.time,
//                        Per_id = elem.Hoca_Id,
//                        Sinif_id = Sinif_id
//                    };
//                    ProgramList.Add(obj);

//                }
//            }

//            var AddedList = await ProRepo.AddProgramAsync(ProgramList);

//            var DersIds = AddedList.Select(a => a.ders_Id).Distinct().ToList();
//         //   var Hoca_idler = AddedList.Select(a => a.Per_id).Distinct().ToList();


//            var Sinif = await SinifRepo.GetSinifById(Sinif_id);
//            var dersler = await DersRepo.GetDerslerByIdsAsync(DersIds);
//            var hocalar = await PerRepo.GetHocalarByDersIdAsync(DersIds);



           
//        //    var FinalSonuc=new ProgramDataDto();
//               var DataForUser = new ProgramDataDto();
//            foreach (var item in AddedList)
//            {
//                var detail = mapper.Map<ProgramDetailDto>(item);

//                var hoca = hocalar.FirstOrDefault(a => a.PerId == item.Per_id);
//                var Ders = dersler.FirstOrDefault(a => a.Ders_Id == item.ders_Id);



//                if (Ders != null && hoca != null && Sinif != null)
//                {
//                    detail.DersName = Ders.DersAdi;
//                    detail.HocaName = hoca.Name;
//                    detail.Sinif_No = Sinif.SinifNo;

//                }
//                if (!DataForUser.ProgramDetailData.ContainsKey(item.Day))
//                {
//                    var DetailList = new List<ProgramDetailDto>();
//                    DetailList.Add(detail);
//                    DataForUser.ProgramDetailData.Add(item.Day, DetailList);
//                  //  DetailList.Clear();
//                }
//                else
//                    DataForUser.ProgramDetailData[detail.Day].Add(detail) ;

              
//            }

//            return DataForUser;
//        }
    
        

        

//        public async Task<TimeOnly> GetDateOfDersByDersName(Days day, string name)
//        {
//            var program = await ProRepo.GetDateOfDersByDersName(day, name);
//            if (program == new TimeOnly(00, 00, 00))
//                return new TimeOnly(00, 00, 00);

//            return program;

//        }

//        public async Task<string> GetDersNameByTimeAsync(Days day, TimeOnly time)
//        {
//            var DersName = await ProRepo.GetDersNameByTimeAsync(day, time);
//            if (string.IsNullOrEmpty(DersName))
//                return null;

//            return DersName;
//        }

//        public async Task<ProgramDataDto> GetProgramByDayAsync(Days day,int SinifId)
//        {
//            var DayProgram = await ProRepo.GetProgramByDayAsync(day,SinifId);
//            if (DayProgram == null || !DayProgram.Any())
//            {
//                return new ProgramDataDto();
//            }

//            var DersIds = DayProgram.Select(a => a.ders_Id).Distinct().ToList();
//          //  var hocaIds=DayProgram.Select(a=>a.Per_id).Distinct().ToList(); 


//            var dersler = await DersRepo.GetDerslerByIdsAsync(DersIds);
//            var hocalar=await PerRepo.GetHocalarByDersIdAsync(DersIds);
//            var sinif = await SinifRepo.GetSinifById(SinifId);
//            // var dictDersler = dersler.ToDictionary(a => a.Ders_Id);
//            var list = new List<ProgramDetailDto>();
//            foreach (var item in DayProgram)
//            {
                
//                var detail = mapper.Map<ProgramDetailDto>(item);
//                var hoca = hocalar.FirstOrDefault(a => a.PerId == item.Per_id);
//                var ders = dersler.FirstOrDefault(a => a.Ders_Id == item.ders_Id);

//                if (hoca != null && ders != null && sinif != null)
//                {
//                    detail.DersName = ders.DersAdi;
//                    detail.HocaName = hoca.Name;
//                    detail.Sinif_No = sinif.SinifNo;
                   
//                }
//                list.Add(detail);

//            }
//            var result = new ProgramDataDto();
//            result.ProgramDetailData.Add(day, list);


//            return result; ;

//          //  return new List<ProgramDetailDto>();

//        }

//        public async Task<ProgramDataDto> UpdateProgram(UpdateAndCreateProgramDto program,int Sinif_id)
//        {


          
//            if (program.ProgramData.Values == null || !program.ProgramData.Values.Any())
//                return new ProgramDataDto();

//            var mostDelete = new List<Program>();
//            var AllProgram = await ProRepo.GetProgramAsync(Sinif_id);
//            int m = 0;
//            foreach (var item in program.ProgramData)
//            {
//                var key=item.Key;
//                for (int i = 0; i < item.Value.Count; i++)
//                {

//                    mapper.Map( item.Value[i], AllProgram[m]);
//                    AllProgram[m].Per_id = item.Value[i].Hoca_Id;
//                   // AllProgram[i].Day = key;
//                  //  AllProgram[i].Sinif_id = Sinif_id;
//                m++;

//                }
//                for(int n=m; n < AllProgram.Count; n++)
//                {
//                    if (AllProgram[n].Day==key)
//                        mostDelete.Add(AllProgram[n]);
//                }
//               await ProRepo.DeleteListProgramAsync(mostDelete);
//                mostDelete.Clear();
//            }


//            var UpdatedProgram = await ProRepo.UpdateProgram(AllProgram);


//            var DersIds = UpdatedProgram.Select(a => a.ders_Id).Distinct().ToList();
//            //   var Hoca_idler = AddedList.Select(a => a.Per_id).Distinct().ToList();


//            var Sinif = await SinifRepo.GetSinifById(Sinif_id);
//            var dersler = await DersRepo.GetDerslerByIdsAsync(DersIds);
//            var hocalar = await PerRepo.GetHocalarByDersIdAsync(DersIds);




//            //    var FinalSonuc=new ProgramDataDto();
//            //ProgramDetailDto detail;
//            var DataForUser = new ProgramDataDto();
//            foreach (var item in UpdatedProgram)
//            {
//              var   detail = mapper.Map<ProgramDetailDto>(item);

//                var hoca = hocalar.FirstOrDefault(a => a.PerId == item.Per_id);
//                var Ders = dersler.FirstOrDefault(a => a.Ders_Id == item.ders_Id);



//                if (Ders != null && hoca != null && Sinif != null)
//                {
//                    detail.DersName = Ders.DersAdi;
//                    detail.HocaName = hoca.Name;
//                    detail.Sinif_No = Sinif.SinifNo;

//                }
//                if (!DataForUser.ProgramDetailData.ContainsKey(item.Day))
//                {
//                    var DetailList = new List<ProgramDetailDto>();
//                    DetailList.Add(detail);
//                    DataForUser.ProgramDetailData.Add(item.Day, DetailList);
//                    //  DetailList.Clear();
//                }
//                else
//                    DataForUser.ProgramDetailData[detail.Day].Add(detail);


//            }

//            return DataForUser;

//        }

//        public async Task<ProgramDataDto> UpdateProgramAtDate(List<ProgramDto> program, Days Day, int Sinif_id)
//        {

//            if (program == null || !program.Any())
//                return new ProgramDataDto(); ;

//            var existingProgram = await ProRepo.GetProgramByDayAsync(Day, Sinif_id);

//            if (existingProgram == null || !existingProgram.Any())
//                return new ProgramDataDto(); ;



//            var ProgramList = new List<ProgramDetailDto>();
//            var result = new ProgramDataDto();


//            for (int i = 0; i < program.Count; i++)
//            {
//                mapper.Map(program[i], existingProgram[i]);
//                existingProgram[i].Per_id = program[i].Hoca_Id;

//            }




//            var mostDeleteObj = new List<Program>();
//            if (program.Count < existingProgram.Count)
//            {
//                for (int i = program.Count; i < existingProgram.Count; i++)
//                {
//                    mostDeleteObj.Add(existingProgram[i]);
//                }

//            }




//             var UpdatedProgramList = await ProRepo.UpdateProgramAtDate(existingProgram);

//             await ProRepo.DeleteListProgramAsync(mostDeleteObj);

//            var LastUpdate = await ProRepo.GetProgramByDayAsync(Day, Sinif_id);

//                var dersIds = LastUpdate.Select(a => a.ders_Id).Distinct().ToList();


//                var dersler = await DersRepo.GetDerslerByIdsAsync(dersIds);
//                var hocalar = await PerRepo.GetHocalarByDersIdAsync(dersIds);
//                var sinif = await SinifRepo.GetSinifById(Sinif_id);


//                foreach (var item in LastUpdate)
//                {

//                    var detail = mapper.Map<ProgramDetailDto>(item);
//                    var hoca = hocalar.FirstOrDefault(a => a.PerId == item.Per_id);
//                    var ders = dersler.FirstOrDefault(a => a.Ders_Id == item.ders_Id);

//                    if (hoca != null && ders != null && sinif != null)
//                    {
//                        detail.DersName = ders.DersAdi;
//                        detail.HocaName = hoca.Name;
//                        detail.Sinif_No = sinif.SinifNo;

//                    }
//                    ProgramList.Add(detail);
//                }

//                result.ProgramDetailData.Add(Day, ProgramList);


//                return result;
//            }

        
//    }
//}
