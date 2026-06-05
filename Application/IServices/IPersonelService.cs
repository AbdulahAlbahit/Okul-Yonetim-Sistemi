
using Application.CreationDto;
using Application.DetailDto;
using Application.UpdateDto;

namespace Application.IServices
{
    public interface IPersonelService

    {

     Task<List<PersonelDetailDto>> GetAllPersonelsAsync();

    Task<PersonelDetailDto> AddPersonelAsync(CreatedPersonelDto createdPersonel);
    Task<PersonelDetailDto> GetPersonelByIdAsync(int id);
    Task<PersonelDetailDto> UpdatePersonelAsync(UpdatePersonelDto personel, int PersonelId);
    Task<bool> DeletePersonelByIdAsync(int Id);


}
}