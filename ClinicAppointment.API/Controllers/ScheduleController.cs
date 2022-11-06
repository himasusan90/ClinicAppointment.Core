using ClinicAppointment.API.Models;
using ClinicAppointment.Core.Aggregates;
using ClinicAppointment.Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicAppointment.API.Controllers
{
    public class ScheduleController: ControllerBase
    {
        private readonly IScheduleRepository _repository;
        ScheduleController(IScheduleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        [SwaggerOperation(
        Summary = "Get a Schedule by Id",
        Description = "Gets a Schedule by Id",
        OperationId = "schedules.GetById",
        Tags = new[] { "ScheduleEndpoints" })
        ]
        public async Task<IActionResult> GetSchedule(int id)
        {
            var schedule = await _repository.GetByIdAsync(id);

            if (schedule == null)
                return NotFound();

            var scheduleDto = new ScheduleDto();
            scheduleDto.Id = schedule.Id;
            scheduleDto.Date = schedule.Date;
            foreach (var appt in schedule.Appointments)
            {
                scheduleDto.AppointmentIds.Add(appt.Id);
            }

            return Ok(scheduleDto);
        }

        [HttpPost]
        [Route("Add")]
        [SwaggerOperation(
        Summary = "Creates a new Schedule",
        Description = "Creates a new Schedule",
        OperationId = "schedules.create",
        Tags = new[] { "ScheduleEndpoints" })
    ]
        public async Task<IActionResult> Add([FromBody]ScheduleRequest request)
        {
            //can use automapper
            var schedule = new Schedule();
            schedule.Date= request.Date;
            _repository.Add(schedule);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [SwaggerOperation(
         Summary = "Deletes a Schedule",
         Description = "Deletes a Schedule",
         OperationId = "schedules.delete",
         Tags = new[] { "ScheduleEndpoints" })
        ]
        public async Task<IActionResult> Delete(int id)
        {
            var schedule =  await _repository.GetByIdAsync(id);

            if (schedule is null)
                return NotFound();

            _repository.Remove(schedule);

            return Ok();
        }


        [HttpPost]
        [Route("api/schedule/{ScheduleId}/appointments")]
        [SwaggerOperation(
        Summary = "Creates a new Appointment",
        Description = "Creates a new Appointment",
        OperationId = "appointments.create",
        Tags = new[] { "AppointmentEndpoints" })
        ]
        public async Task<IActionResult> AddAppointment([FromBody] AppointmentRequest request)
        {
            //can use automapper
            var schedule = await _repository.GetByIdAsync(request.ScheduleId);

            if (schedule == null)
                return NotFound();
            var newAppointment = new Appointment(new System.Guid(), request.Title, request.Description, request.PatientId,
                request.DoctorId, request.StartTime, request.EndDTime, request.ScheduleId);
            schedule.AddNewAppointment(newAppointment);
            _repository.Update(schedule);

            return Ok();
        }

        [HttpGet]
        [Route("api/schedule/{ScheduleId}/appointments/{AppointmentId}")]
        [SwaggerOperation(
        Summary = "Get an Appointment by Id",
        Description = "Gets an Appointment by Id",
        OperationId = "appointments.GetById",
        Tags = new[] { "AppointmentEndpoints" })
    ]
        public async Task<IActionResult> GetAppointmentByScheduleId([FromRoute] GetByIdAppointmentRequest request)
        {
            var schedule = await _repository.GetByIdAsync(request.ScheduleId);

            if (schedule == null)
                return NotFound();
            var appointment = schedule.Appointments.FirstOrDefault(a => a.Id == request.AppointmentId);

            var appointmentDto = new AppointmentDto();
            appointmentDto.ScheduleId = appointment.ScheduleId;
            appointmentDto.AppointmentId = appointment.Id;
            appointmentDto.PatientId = appointment.PatientId;
            appointmentDto.DoctorId=appointment.DoctorId;
            appointmentDto.StartTime=appointment.StartTime;
            appointmentDto.EndTime=appointment.EndTime;
            appointmentDto.Title = appointment.Title;
            appointmentDto.Description = appointment.Description;

            return Ok(appointmentDto);
        }

        [HttpDelete("api/schedule/{ScheduleId}/appointments/{AppointmentId}")]
        [SwaggerOperation(
        Summary = "Deletes an Appointment",
        Description = "Deletes an Appointment",
        OperationId = "appointments.delete",
        Tags = new[] { "AppointmentEndpoints" })
    ]
        public async Task<IActionResult> Delete([FromRoute] DeleteAppointmentRequest request)
        {
            var schedule = await _repository.GetByIdAsync(request.ScheduleId);

            if (schedule == null)
                return NotFound();
            var apptToDelete = schedule.Appointments.FirstOrDefault(a => a.Id == request.AppointmentId);
            schedule.DeleteAppointment(apptToDelete);

            _repository.Update(schedule);

            return Ok();
        }
    }
}
