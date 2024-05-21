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
    //[Authorize(Roles ="User")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoServices _userInfoServices;

        public UserInfoController(IUserInfoServices userInfoServices)
        {
            this._userInfoServices = userInfoServices;
        }
        //get all Appointments
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

             return Ok( await _userInfoServices.GetAllAppointments());
        }

        // get one by id
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _userInfoServices.GetById(id);
                if(result == null)
                {
                    return NotFound($"the id : {id} not found");
                }
                return Ok(result);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //new Request 
        [HttpPost("NewRequest")]
        public async Task<IActionResult> NewRequest(BlRequest blRequest)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            Request request = new Request();
            request.TravelerId = blRequest.TravelerId;
            request.AppoinmentId = blRequest.AppoinmentId;

            try
            {
                var result = await _userInfoServices.NewRequest(request);
                if(result == null)
                {
                    return BadRequest("Something worning try again");
                }
                return Ok("Request send successfully");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // show history of request related by user  eamil
        [HttpGet("ShowHistory")]
        public async Task<IActionResult> ShowHistory(int id)
        {
            try
            {
                return Ok(await _userInfoServices.GetAllRequests(id));

            }catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }
        }

    }
}
