using BlazorApp1.DataAccess.Contracts;
using EF = BlazorApp1.Data.Models;
using DTO = BlazorApp1.DTOs.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Data.Models;
using BlazorApp1.DTOs.DTOs;

namespace BlazorApp1.DataAccess.Accessors
{
    public partial class OwnerAccessor : IOwnerAccessor
    {
        private readonly PracticeDBContext _context;

        public OwnerAccessor(PracticeDBContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteCarOwner(Guid id)
        {
            var carOwner = await _context.Owners
                .Where(x => x.OwnerId == id)
                .SingleOrDefaultAsync();

            if (carOwner is not null)
            {
                try
                {
                    _context.Remove(carOwner);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (SqlException e)
                {
                    return false;
                }
            }

            return false;
        }

        public async Task<DTO.OwnerDetail> GetCarOwner(Guid id)
        {
            var carOwner = await _context.Owners.Where(x => x.OwnerId == id).SingleOrDefaultAsync();

            return carOwner.Map<DTO.OwnerDetail>();
        }

        public async Task<List<DTO.OwnerDetail>> GetCarOwnerList(Guid? carId)
        {
            var carOwners = new List<DTO.OwnerDetail>();
            
            if(carId == null)
            {
                carOwners = await _context.Owners
                    .ProjectTo<DTO.OwnerDetail>()
                    .ToListAsync();
            }
            else
            {
                carOwners = await _context.CarOwners
                    .Where(x => x.Car == carId)
                    .Include(x => x.AnOwnerNavigation)
                    .Select(x => x.AnOwnerNavigation)
                    .ProjectTo<DTO.OwnerDetail>()
                    .ToListAsync();
            }

            return carOwners;
        }

        public async Task<OwnerDetail> SaveCarOwner(DTO.OwnerDetail carOwner)
        {
            var owner = carOwner.Map<EF.Owner>();

            try
            {
                if (await Exists(owner.OwnerId))
                {
                    _context.Add(owner);
                    await _context.SaveChangesAsync();
                    return owner.Map<DTO.OwnerDetail>();
                }
                else
                {
                    _context.Owners.Update(owner);
                    await _context.SaveChangesAsync();
                    return owner.Map<DTO.OwnerDetail>();
                }
            }
            catch (SqlException e)
            {
                return owner.Map<DTO.OwnerDetail>();
            }

        }

        private async Task<bool> Exists(Guid id)
        {
            var duplicate = await _context.Owners
                .Where(x => x.OwnerId == id)
                .SingleOrDefaultAsync();

            return (duplicate is not null) ? false : true;
        }
    }
}
