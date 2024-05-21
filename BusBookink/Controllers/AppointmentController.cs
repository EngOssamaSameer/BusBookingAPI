using BusBookink.Bl;
using BusBookink.Models;
using BusBookink.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusBookink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentServices _appointmentServices;

        public AppointmentController(IAppointmentServices appointmentServices)
        {
            this._appointmentServices = appointmentServices;
        }
        //Get all Appointments
        [HttpGet("AllAppoinments")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _appointmentServices.GetAll());
            }catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        //Get one Appointment By id
        [HttpGet("OneAppoinment/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                return Ok(await _appointmentServices.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Add new  Appointment 
        [HttpPost]
        public async Task<IActionResult> AddNewAppointment(BlAppointment blAppointment)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            try
            {
                Appointment appointment = new Appointment();
                appointment.MaxNumberOfTravellers = blAppointment.MaxNumberOfTravellers;
                appointment.Title = blAppointment.Title;
                appointment.DestinationId = blAppointment.DestinationId;
                appointment.AppoinmentDate = blAppointment.AppoinmentDate;

                return Ok(await _appointmentServices.AddNewAppointment(appointment));
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //delete  Appointment 
        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                if(await _appointmentServices.Delete(id))
                {
                    return Ok("Deleted Successfully");
                }
                return BadRequest("Something Worning try Again");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //update  Appointment 
        [HttpPut]
        public async Task<IActionResult> UpdateAppointment(int id ,BlAppointment blAppointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Appointment appointment = new Appointment();
                appointment.MaxNumberOfTravellers = blAppointment.MaxNumberOfTravellers;
                appointment.Title = blAppointment.Title;
                appointment.DestinationId = blAppointment.DestinationId;
                appointment.AppoinmentDate = blAppointment.AppoinmentDate;

                if (await _appointmentServices.UpdateAppointment(id ,appointment))
                {
                    return Ok("Updated Successfully");
                }
                return BadRequest("Something Worning try Again");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
