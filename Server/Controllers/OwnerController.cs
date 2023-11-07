using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp1.DTOs.DTOs;
using BlazorApp1.Services.Contracts;

namespace BlazorApp1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerManager _carOwnerManager;
        public OwnerController(IOwnerManager carOwnerManager)
        {
            _carOwnerManager = carOwnerManager;
        }

        [HttpGet]
        public async Task<ActionResult<OwnerDetail>> GetCarOwner(Guid id)
        {
            var result = _carOwnerManager.GetCarOwner(id);

            if (result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetOwners/{carId?}")]
        public async Task<ActionResult<List<OwnerDetail>>> GetCarOwners(Guid? carId)
        {
            var result = await _carOwnerManager.GetCarOwnerList(carId);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<OwnerDetail>> SaveCarOwner(OwnerDetail owner)
        {
            if (ModelState.IsValid)
            {
                var result = await _carOwnerManager.SaveCarOwner(owner);
                return result;
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCarOwner(Guid id)
        {
            var result = await _carOwnerManager.DeleteCarOwner(id);
            return result;
        }
    }
}
