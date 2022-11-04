using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAppointment.Core.Common;
using ClinicAppointment.Core.Events;

namespace ClinicAppointment.Core.Aggregates
{
    public class Schedule:BaseEntity<Guid>
    {
        public IList<Appointment> Appointments { get; set; }=new List<Appointment>(){ };
        public DateTime Date { get;  set; }
        public Schedule(Guid id, DateTime date)
        {
            Date = date;
            Id= id;
        }
        public void AddNewAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new InvalidOperationException("Appointment cant be null");
            }
            if ( Appointments.Any(x=>x.Id==appointment.Id))
            {
                throw new InvalidOperationException("Cannot create duplicate appointments");
            }

            Appointments.Add(appointment);

            var appointmentScheduledEvent = new AppointmentScheduledEvent(appointment);
            Events.Add(appointmentScheduledEvent);
        }

        public void DeleteAppointment(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new InvalidOperationException("Appointment cant be null");
            }
            var deleteAppointment = Appointments
                                      .Where(a => a.Id == appointment.Id)
                                      .FirstOrDefault();

            if (deleteAppointment != null)
            {
                Appointments.Remove(deleteAppointment);
            }

        }

        public void UpdateAppointment()
        {
        }

       
    }
}
