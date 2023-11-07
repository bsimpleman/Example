using System.Net.Http.Json;

namespace BlazorApp1.WebClient.Services.CarOwner
{
    public partial class OwnerClient : IOwnerClient
    {
        private readonly HttpClient _http;
        public OwnerClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> DeleteCarOwner(Guid id)
        {
            var result = await _http.DeleteAsync($"/api/Owner/{id}");
            return await result.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<OwnerDetail> GetCarOwner(Guid id)
        {
            var result = await _http.GetFromJsonAsync<OwnerDetail>($"/api/Owner/{id}");
            return result;
        }

        public async Task<List<OwnerDetail>> GetCarOwnerList(Guid? carId)
        {
            var result = new List<OwnerDetail>();

            if(carId == null)
            {
                result = await _http.GetFromJsonAsync<List<OwnerDetail>>($"/api/Owner/GetOwners");
            }
            else
            {
                result = await _http.GetFromJsonAsync<List<OwnerDetail>>($"/api/Owner/GetOwners/{carId}");
            }
            
            return result;
        }

        public async Task<OwnerDetail> SaveCarOwner(OwnerDetail carOwner)
        {
            var result = await _http.PostAsJsonAsync<OwnerDetail>("/api/Owner", carOwner);
            return await result.Content.ReadFromJsonAsync<OwnerDetail>();
        }
    }
}
