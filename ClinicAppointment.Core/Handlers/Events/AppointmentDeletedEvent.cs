using ClinicAppointment.Core.Aggregates;
using ClinicAppointment.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Core.Events
{
    public class AppointmentDeletedEvent : BaseDomainEvent
    {
        public AppointmentDeletedEvent(Appointment appointment)
        {
            AppointmentDeleted = appointment;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();

        public Appointment AppointmentDeleted { get; private set; }
    }
}
