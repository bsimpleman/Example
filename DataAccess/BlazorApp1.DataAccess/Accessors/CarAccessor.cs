using BlazorApp1.DataAccess.Contracts;
using EF = BlazorApp1.Data.Models;
using DTO = BlazorApp1.DTOs.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.DTOs.DTOs;
using System.Collections.Generic;
using BlazorApp1.Data.Models;
using System.Diagnostics.Metrics;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorApp1.DataAccess.Accessors
{
    public partial class CarAccessor : ICarAccessor
    {
        private readonly PracticeDBContext _context;
        public CarAccessor(PracticeDBContext context)
        {
            _context = context;
        }

        public async Task<DTO.CarDetails> GetCarById(Guid carId)
        {
            var car = await _context.Cars
                .Where(x => x.CarId == carId)
                .SingleOrDefaultAsync();

            return car.Map<DTO.CarDetails>();
        }

        public async Task<CarPagedList> GetCars(int pageNum, string searchText, string searchCategory)
        {
            CarPagedList cars = new CarPagedList();

            int recordCount = 0;
            cars.searchCategory = searchCategory;
            cars.searchText = searchText;
            cars.pgNum = pageNum;

            if (searchText == null && searchCategory == null)
            {
                recordCount = _context.Cars.Count();

                cars.Cars = await _context.Cars
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ProjectTo<DTO.CarDetails>()
                    .ToListAsync();
            }
            else if (searchCategory == "Make")
            {
                recordCount = _context.Cars
                    .Where(x => x.Make == searchText).Count();

                cars.Cars = await _context.Cars
                   .Where(x => x.Make == searchText)
                   .Skip(10 * (pageNum - 1))
                   .Take(10)
                   .ProjectTo<DTO.CarDetails>()
                   .ToListAsync();
            }
            else if(searchCategory == "Model")
            {
                recordCount = _context.Cars
                    .Where(x => x.Model == searchText).Count();

                cars.Cars = await _context.Cars
                    .Where(x => x.Model == searchText)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ProjectTo<DTO.CarDetails>()
                    .ToListAsync();
            }
            else if (searchCategory == "LastName")
            {
                recordCount = _context.Cars
                    .Include(x => x.CarOwners)
                    .Where(x => x.CarOwners.First().AnOwnerNavigation.OwnerLname == searchText)
                    .Count();

                cars.Cars = await _context.Cars
                    .Include(x => x.CarOwners)
                    .Where(x => x.CarOwners.First().AnOwnerNavigation.OwnerLname == searchText)
                    .Skip(10 * (pageNum - 1))
                    .Take(10)
                    .ProjectTo<DTO.CarDetails>()
                    .ToListAsync();
            }

            cars.HasPrev = pageNum > 10;
            cars.HasNext = pageNum < ((int)Math.Ceiling(recordCount / (double)10));

            int recCnt = pageNum * 10;

            if (recCnt > recordCount)
            {
                recCnt = recordCount;
            }

            cars.RecCnt = recCnt + " of " + recordCount + " Cars";

            return cars;
        }

        public async Task<ServiceResponse<DTO.CarDetails>> SaveCar(DTO.CarDetails car)
        {
            ServiceResponse<DTO.CarDetails> TheResponses = new ServiceResponse<DTO.CarDetails>();
            
            var aCar = car.Map<EF.Car>();

            var duplicate = await Exists(aCar.CarId);

            try
            {
                if (duplicate)
                {
                    _context.Update(aCar);
                    await _context.SaveChangesAsync(); 
                }
                else
                {
                    _context.Cars.Add(aCar);
                    await _context.SaveChangesAsync();
                }

                TheResponses.ReturnType = aCar.Map<DTO.CarDetails>();
                //TheResponses.Message = "Save Worked";
                //TheResponses.Worked = true;

                return TheResponses; 
            }
            catch (Exception ex)
            {
                TheResponses.ReturnType = aCar.Map<DTO.CarDetails>();
                TheResponses.Message = "There was an error. Please try again later.";
                TheResponses.Worked = false;

                return TheResponses;
            }
        }

        public async Task<bool> DeleteCar(Guid carId)
        {
            if (await Exists(carId))
            {
                var car = await _context.Cars.Where(x => x.CarId == carId).SingleOrDefaultAsync();
                try
                {
                    _context.Remove(car);
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

        public async Task<bool> AddCarOwner(Guid car, Guid owner)
        {
            var carOwner = new EF.CarOwner();
            carOwner.Car = car;
            carOwner.AnOwner = owner;
            carOwner.OwnStart = DateTime.Now;

            try
            {
                _context.Add(carOwner);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (SqlException e)
            { 
                return false; 
            }
        }

        private async Task<bool> Exists(Guid id)
        {
            var duplicate = await _context.Cars
                .Where(x => x.CarId == id)
                .AnyAsync();

            return duplicate;
        }
    }
}
