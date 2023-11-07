using BlazorApp1.DTOs.DTOs;

namespace BlazorApp1.Services.Contracts
{
    public interface ICarManager
    {
        Task<CarDetails> GetCarById(Guid carId);
        Task<CarPagedList> GetCars(int pageNum, string searchText, string searchCategory);
        Task<ServiceResponse<CarDetails>> SaveCar(CarDetails car);
        Task<bool> DeleteCar(Guid carId);

        Task<bool> AddCarOwner(Guid car, Guid owner);
    }
}
