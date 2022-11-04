using ClinicAppointment.Core.Aggregates;
using System;
using Xunit;

namespace TestProject1
{
    public class AppointmentSpecs
    {
        private readonly DateTime _startDate = new DateTime(2021, 01, 01, 10, 00, 00);
        private readonly DateTime _endDate = new DateTime(2021, 01, 01, 11, 00, 00);
        private readonly Guid _scheduleId = Guid.NewGuid();
        private readonly Guid _appointmentId = Guid.NewGuid();
        private readonly int _patientId = 2;
        private readonly int _doctorId = 5;
        private readonly string _title = "Patient with Headache";
        private readonly string _desc = "symptoms include headache,bodyacge,thyroid";

        [Fact]
        public void Create_Appointment_Successfully()
        {
            var appointment = new Appointment(_appointmentId,_title,_desc,_patientId,_doctorId,
                _startDate, _endDate,_scheduleId);
            Assert.Equal(_scheduleId, appointment.ScheduleId);
            Assert.Equal(_title, appointment.Title);
            Assert.Equal(_desc, appointment.Description);
            Assert.Equal(_patientId, appointment.PatientId);
            Assert.Equal(_doctorId, appointment.DoctorId);
            Assert.Equal(_scheduleId, appointment.ScheduleId);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ThrowsExceptionGivenInvalidClientId(int invalidPatientId)
        {
            void Action() =>  new Appointment(_appointmentId, _title, _desc, invalidPatientId, _doctorId,
                _startDate, _endDate, _scheduleId);

            Assert.Throws<ArgumentNullException>(Action);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ThrowsExceptionGivenInvalidTitle(string invalidTitle)
        {
            void Action() => new Appointment(_appointmentId, invalidTitle, _desc, _patientId, _doctorId,
                _startDate, _endDate, _scheduleId);
          
                Assert.Throws<ArgumentNullException>(Action);
            
        }

    }
}
