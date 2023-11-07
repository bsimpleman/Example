namespace BlazorApp1.WebClient.Services.Car
{
    public interface ICarClient
    {
        Task<CarDetails> GetCarById(Guid carId);
        Task<CarPagedList> GetCars(int pageNum, string searchText, string searchCategory);
        Task<ServiceResponse<CarDetails>> SaveCar(CarDetails car);
        Task<bool> DeleteCar(Guid carId);

        Task<bool> AddCarOwner(Guid car, Guid owner);
    }
}
