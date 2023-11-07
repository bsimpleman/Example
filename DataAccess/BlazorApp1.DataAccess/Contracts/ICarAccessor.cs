using BlazorApp1.DTOs.DTOs;
using DTO = BlazorApp1.DTOs.DTOs;

namespace BlazorApp1.DataAccess.Contracts
{
    public interface ICarAccessor
    {
        Task<DTO.CarDetails> GetCarById(Guid carId);
        Task<CarPagedList> GetCars(int pageNum, string searchText, string searchCategory);
        Task<DTO.ServiceResponse<DTO.CarDetails>> SaveCar(DTO.CarDetails car);
        Task<bool> DeleteCar(Guid carId);

        Task<bool> AddCarOwner(Guid car, Guid owner);
    }
}
