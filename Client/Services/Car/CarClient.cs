using System.Net.Http.Json;

namespace BlazorApp1.WebClient.Services.Car
{
    public partial class CarClient : ICarClient
    {
        private readonly HttpClient _http;
        public CarClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<CarDetails> GetCarById(Guid carId)
        {
            var result = await _http.GetFromJsonAsync<CarDetails>($"/api/Car/{carId}");
            return result;
        }

        public async Task<CarPagedList> GetCars(int pageNum, string searchText, string searchCategory)
        {
            var result = new CarPagedList();

            if (searchText is not null && searchCategory is not null)
            {
                result = await _http.GetFromJsonAsync<CarPagedList>
                    ($"api/Car/GetCars/{pageNum}/{searchText}/{searchCategory}");
            }
            else
            {
                result = await _http.GetFromJsonAsync<CarPagedList>
                    ($"api/Car/GetCars/{pageNum}");
            }

            return result;
        }

        public async Task<ServiceResponse<CarDetails>> SaveCar(CarDetails car)
        {
            var result = await _http.PostAsJsonAsync($"api/Car/",car);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<CarDetails>>();
        }

        public async Task<bool> DeleteCar(Guid carId)
        {
            var result = await _http.DeleteAsync($"api/Car/{carId}");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> AddCarOwner(Guid car, Guid owner)
        {
            var result = await _http.GetFromJsonAsync<bool>($"/api/Car/AddCarOwner/{car}/{owner}");
            return result;
        }
    }
}
