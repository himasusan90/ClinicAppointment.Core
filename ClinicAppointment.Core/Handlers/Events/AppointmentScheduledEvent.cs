using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAppointment.Core.Aggregates;
using ClinicAppointment.Core.Common;

namespace ClinicAppointment.Core.Events
{
    public class AppointmentScheduledEvent: BaseDomainEvent
    {
        public AppointmentScheduledEvent(Appointment appointment)
        {
            AppointmentScheduled = appointment;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public Appointment AppointmentScheduled { get; private set; }
    }
}
