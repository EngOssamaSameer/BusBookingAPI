using BusBookink.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusBookink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RequestController : ControllerBase
    {
        private readonly IRequestServices _requestServices;

        public RequestController(IRequestServices requestServices)
        {
            this._requestServices = requestServices;
        }
        //Get all Request
        [HttpGet("AllRequest")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _requestServices.GetAll());
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get one Request By id
        [HttpGet("OneRequest/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                if(await _requestServices.GetById(id) == null)
                {
                    return NotFound($"the Id : {id} not found" );
                }
                return Ok(await _requestServices.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //update  Request accept/decline
        [HttpPut]
        public async Task<IActionResult> UpdateRequest(int id ,bool Status)
        {
            try
            {
                return Ok(await _requestServices.UpdateRequest(id,Status));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
