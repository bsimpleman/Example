namespace BlazorApp1.WebClient.Services.CarOwner
{
    public interface IOwnerClient
    {
        Task<OwnerDetail> GetCarOwner(Guid id);
        Task<List<OwnerDetail>> GetCarOwnerList(Guid? id);
        Task<bool> DeleteCarOwner(Guid id);
        Task<OwnerDetail> SaveCarOwner(OwnerDetail carOwner);
    }
}
