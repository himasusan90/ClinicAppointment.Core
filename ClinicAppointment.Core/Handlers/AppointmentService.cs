using ClinicAppointment.Core.Common;
using ClinicAppointment.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Core.Handlers
{
    public class AppointmentService : INotificationHandler<AppointmentScheduledEvent>
    {
        public AppointmentService()
        {

        }
        public async Task Handle(AppointmentScheduledEvent appointmentScheduledEvent)
        {
           //Raise an event to notify Appointment has been scheduled 
           
        }
    }
}
