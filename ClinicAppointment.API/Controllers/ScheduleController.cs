using ClinicAppointment.API.Models;
using ClinicAppointment.Core.Aggregates;
using ClinicAppointment.Core.Common;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace ClinicAppointment.API.Controllers
{
    public class ScheduleController
    {
        private readonly IRepository<Schedule> _repository;
        ScheduleController(IRepository<Schedule> repository)
        {
            _repository = repository;
        }
       
        [HttpPost("api/schedules")]
        [SwaggerOperation(
        Summary = "Creates a new Schedule",
        Description = "Creates a new Schedule",
        OperationId = "schedules.create",
        Tags = new[] { "ScheduleEndpoints" })
    ]
        public  ActionResult<ScheduleDto> CreateSchedules(ScheduleRequest request)
        {
            var resp=new ScheduleDto();
            throw new NotImplementedException();
        }

      
    }
}
