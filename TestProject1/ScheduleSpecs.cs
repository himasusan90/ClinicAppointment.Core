using ClinicAppointment.Core.Aggregates;
using ClinicAppointment.Core.Aggregates;
using System.Linq;
using System;
using Xunit;

namespace ClinicAppointment.Tests
{
    public class ScheduleSpecs
    {
        private readonly Guid _scheduleId = Guid.Parse("4a17e702-c20e-4b87-b95b-f915c5a794f7");
        private readonly DateTime _date = DateTime.Today.AddDays(1);
  


        [Fact]
        public void AddsAppointmentScheduledEvent()
        {
            var schedule = new Schedule(_scheduleId, _date);
            var doctorId = 2;
            var patientId = 3;

            DateTime testStartTime = new DateTime(2021, 01, 01, 10, 00, 00);
            DateTime testEndTime = new DateTime(2021, 01, 01, 11, 00, 00);
   
            var testTitle = "Test Appointment";
            var testDesc = "Test Appointment";
            var TestAppointment = new Appointment(Guid.NewGuid(),testTitle,testDesc, doctorId,patientId, testStartTime,testEndTime,_scheduleId);
            schedule.AddNewAppointment(TestAppointment);

            DateTime mimiStartTime = new DateTime(2021, 01, 01, 12, 00, 00);
            DateTime mimiEndTime = new DateTime(2021, 01, 01, 14, 00, 00);
            var mimiTitle = "Mimi Appointment";
            var mimiDesc = "Mimi Appointment";
            var mimiAppointment = new Appointment(Guid.NewGuid(),mimiTitle,mimiDesc,patientId,doctorId,mimiStartTime,mimiEndTime,_scheduleId);
            schedule.AddNewAppointment(mimiAppointment);

            Assert.Equal(2, schedule.Appointments.Count);
        
        }

        [Fact]
        public void RemovesAppointment()
        {
            var schedule = CreateScheduleWithAppointment();

            schedule.DeleteAppointment(schedule.Appointments.First());

            Assert.False(schedule.Appointments.Any());
        }

        private Schedule CreateScheduleWithAppointment()
        {
            var schedule = new Schedule(_scheduleId, _date);
            var doctorId = 2;
            var patientId = 3;


            DateTime testStartTime = new DateTime(2021, 01, 01, 10, 00, 00);
            DateTime testEndTime = new DateTime(2021, 01, 01, 11, 00, 00);

            var testTitle = "Test Appointment";
            var testDesc = "Test Appointment";
            var TestAppointment = new Appointment(Guid.NewGuid(), testTitle, testDesc, doctorId, patientId, testStartTime, testEndTime, _scheduleId);
            schedule.AddNewAppointment(TestAppointment);

            return schedule;
        }
    }
}

