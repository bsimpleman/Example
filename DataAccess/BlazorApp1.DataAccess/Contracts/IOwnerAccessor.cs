using BlazorApp1.DTOs.DTOs;
using DTO = BlazorApp1.DTOs.DTOs;

namespace BlazorApp1.DataAccess.Contracts
{
    public interface IOwnerAccessor
    {
        Task<DTO.OwnerDetail> GetCarOwner(Guid id);
        Task<List<DTO.OwnerDetail>> GetCarOwnerList(Guid? id);
        Task<bool> DeleteCarOwner(Guid id);
        Task<OwnerDetail> SaveCarOwner(DTO.OwnerDetail carOwner);
    }
}
