using BlazorApp1.DTOs.DTOs;

namespace BlazorApp1.Services.Contracts
{
    public interface IOwnerManager
    {
        Task<OwnerDetail> GetCarOwner(Guid id);
        Task<List<OwnerDetail>> GetCarOwnerList(Guid? id);
        Task<bool> DeleteCarOwner(Guid id);
        Task<OwnerDetail> SaveCarOwner(OwnerDetail carOwner);
    }
}
