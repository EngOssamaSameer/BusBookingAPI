using BusBookink.Bl;
using BusBookink.Contexts;
using BusBookink.Models;
using BusBookink.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusBookink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class TravelerController : ControllerBase
    {
        private readonly ITravelerServices _travelerServices;

        public TravelerController(ITravelerServices travelerServices, AppDbContext appDbContext)
        {
            this._travelerServices = travelerServices;
        }
        //Get all Traveler
        [HttpGet("AllTravelers")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _travelerServices.GetAll());
        }

        //Get one Traveler By id
        [HttpGet("OneTraveler/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var result = await _travelerServices.GetById(id);
                if (result == null)
                {
                    return NotFound("Not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //delete  Traveler 
        [HttpDelete]
        public async Task<IActionResult> DeleteTraveler(int id)
        {
            try
            {
                var result = await _travelerServices.DeleteTraveler(id);
                if ( result == false)
                {
                    return NotFound($"the id : {id} not found");
                }
                return Ok("Deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //update  Traveler 
        [HttpPut]
        public async Task<IActionResult> UpdateTraveler(int id , BlTraveler blTraveler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Traveler traveler = new Traveler();
            traveler.UserName = blTraveler.UserName;
            traveler.Email = blTraveler.Email;
            try
            {
                var result = await  _travelerServices.UpdateTraveler(id, traveler);
                if(result == false)
                {
                    return NotFound($"the is : {id} not found");
                }
                return Ok("Updated successfully");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
