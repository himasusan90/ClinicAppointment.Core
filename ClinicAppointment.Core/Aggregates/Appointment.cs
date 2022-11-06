using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAppointment.Core.Common;

namespace ClinicAppointment.Core.Aggregates
{
    public class Appointment: BaseEntity<Guid>, IAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int PatientId { get;  set; }
        public int DoctorId { get;  set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid ScheduleId { get;  set; }
        private Appointment()
        {
            //for EF
        }
        public Appointment(Guid id,string title,string desc,int patientId,int doctorId,DateTime startDate,
            DateTime endDate,Guid scheduleId)
        {
            ValidateInputAppointmentValues(id, title, desc, patientId, doctorId,scheduleId,startDate,endDate);
            Id = id;
            Title= title;
            Description= desc;
            PatientId = patientId;
            DoctorId = doctorId;
            StartTime = startDate;
            EndTime = endDate;
            ScheduleId = scheduleId;
        }

        private void ValidateInputAppointmentValues(Guid id, string title, string desc, int patientId, int doctorId,Guid scheduleId, DateTime startDate,
            DateTime endDate)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (string.IsNullOrEmpty(desc))
            {
                throw new ArgumentNullException(nameof(desc));
            }
            if (patientId == 0 || patientId < 0)
            {
                throw new ArgumentNullException(nameof(patientId));
            }
            if (doctorId == 0 || doctorId < 0)
            {
                throw new ArgumentNullException(nameof(doctorId));
            }
            if (scheduleId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ScheduleId));
            }
            if (endDate < startDate)
            {
                throw new InvalidOperationException("End date and time should be before start date and time");
            }
        }


    }
}
