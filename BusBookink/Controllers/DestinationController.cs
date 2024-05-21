using BusBookink.Bl;
using BusBookink.Contexts;
using BusBookink.Models;
using BusBookink.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BusBookink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DestinationController : ControllerBase
    {
        // Propertys
        private AppDbContext _appDbContext { get; }

        private readonly IDestinationServices _destinationServices;

        public DestinationController(IDestinationServices destinationServices, AppDbContext appDbContext)
        {
            this._destinationServices = destinationServices;
            this._appDbContext = appDbContext;
        }
        //Get all Destination
        [HttpGet("AllDestination")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _destinationServices.GetAll());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get one Destination By id
        
        [HttpGet("OneDestination/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = _appDbContext.TbDestination.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                return NotFound($"the id : {id} not foun");
            }
            var AppointmentRelated = _appDbContext.TbAppointments.Where(a=>a.DestinationId == id).ToList();
            if (AppointmentRelated.Any())
            {
                result.TbAppointments = AppointmentRelated;
            }
            return Ok(result);
        }

        //Add new  Destination 
        [HttpPost]
        public async Task<IActionResult> AddNewDestination(BlDestination blDestination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Destination destination = new Destination();
            destination.Name = blDestination.Name;  
            try
            {
                await _destinationServices.AddNewDestination(destination);
                return Ok("Added successfully");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //delete  Destination 
        [HttpDelete]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            try
            {
                bool result = await _destinationServices.Delete(id);
                if(result == false)
                {
                    return NotFound($"the id : {id} not found");
                }
                return Ok("Deleted Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //update  Destination 
        [HttpPut]
        public async Task<IActionResult> UpdateDestination(int id , BlDestination blDestination)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Destination destination = new Destination();
            destination.Name = blDestination.Name;
            try
            {
                bool result = await _destinationServices.UpdateDestination(id, destination);
                if (result == false )
                {
                    return NotFound($"the id : {id} not found");
                }
                return Ok("Updated successfully");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
