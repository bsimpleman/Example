using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.DTOs.DTOs;
using BlazorApp1.Services.Contracts;

namespace BlazorApp1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarManager _carManager;

        public CarController(ICarManager carManager)
        {
            _carManager = carManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDetails>> GetCar(Guid id)
        {
            var result = await _carManager.GetCarById(id);

            if (result is not null)
            {
                return result;
            }

            return BadRequest();
        }

        [HttpGet("GetCars/{pageNum}/{searchText?}/{searchCategory?}")]
        public async Task<ActionResult<CarPagedList>> GetCars(int pageNum, string? searchText, string? searchCategory)
        {
            var result = await _carManager.GetCars(pageNum, searchText, searchCategory);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CarDetails>>> SaveCar(CarDetails car)
        {
            if (ModelState.IsValid)
            {
                var result = await _carManager.SaveCar(car);
                return result;
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCar(Guid id)
        {
            var result = await _carManager.DeleteCar(id);
            return result;
        }

        [HttpGet("AddCarOwner/{car}/{owner}")]
        public async Task<ActionResult<bool>> AddCarOwner(Guid car, Guid owner)
        {
            var result = await _carManager.AddCarOwner(car, owner);
            return result;
        }
    }
}
