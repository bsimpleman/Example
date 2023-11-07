using BlazorApp1.DataAccess.Contracts;
using BlazorApp1.DTOs.DTOs;
using BlazorApp1.Services.Contracts;

namespace BlazorApp1.Services.Managers
{
    public partial class OwnerManager : IOwnerManager
    {
        private readonly IOwnerAccessor _carOwnerAccessor;
        public OwnerManager(IOwnerAccessor carOwnerAccessor)
        {
            _carOwnerAccessor = carOwnerAccessor;
        }
        public async Task<OwnerDetail> GetCarOwner(Guid id)
        {
            var result = await _carOwnerAccessor.GetCarOwner(id);
            return result;
        }

        public async Task<List<OwnerDetail>> GetCarOwnerList(Guid? id)
        {
            var result = await _carOwnerAccessor.GetCarOwnerList(id);
            return result;
        }

        public async Task<OwnerDetail> SaveCarOwner(OwnerDetail carOwner)
        {
            var result = await _carOwnerAccessor.SaveCarOwner(carOwner);
            return result;
        }

        public async Task<bool> DeleteCarOwner(Guid id)
        {
            var result = await _carOwnerAccessor.DeleteCarOwner(id);
            return result;
        }
    }
}
