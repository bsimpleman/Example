using BlazorApp1.DataAccess.Contracts;
using BlazorApp1.DTOs.DTOs;
using BlazorApp1.Services.Contracts;

namespace BlazorApp1.Services.Managers
{
    public partial class CarManager : ICarManager
    {
        private readonly ICarAccessor _carAccessor;
        public CarManager(ICarAccessor carAccessor)
        {
            _carAccessor = carAccessor;
        }

        public async Task<CarDetails> GetCarById(Guid carId)
        {
            var result = await _carAccessor.GetCarById(carId);
            //go do business logic
            return result;
        }

        public async Task<CarPagedList> GetCars(int pageNum, string searchText, string searchCategory)
        {
            var result = await _carAccessor.GetCars(pageNum, searchText, searchCategory);
            return result;
        }

        public async Task<ServiceResponse<CarDetails>> SaveCar(CarDetails car)
        {
            var result = await _carAccessor.SaveCar(car);
            return result;
        }

        public async Task<bool> DeleteCar(Guid carId)
        {
            var result = await _carAccessor.DeleteCar(carId);
            return result;
        }

        public async Task<bool> AddCarOwner(Guid car, Guid owner)
        {
            var result = await _carAccessor.AddCarOwner(car, owner);
            return result;
        }
    }
}
