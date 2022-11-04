using ClinicAppointment.API.Models;
using ClinicAppointment.Core.Aggregates;
using ClinicAppointment.Core.Common;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicAppointment.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IRepository<Schedule> _scheduleRepository;
        public AppointmentController(IRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpPost("api/schedule/{ScheduleId}/appointments")]
        [SwaggerOperation(
        Summary = "Creates a new Appointment",
        Description = "Creates a new Appointment",
        OperationId = "appointments.create",
        Tags = new[] { "AppointmentEndpoints" })
        ]
        public  Task<ActionResult<AppointmentDto>> CreateAppointment(AppointmentRequest request)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
