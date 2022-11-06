using ClinicAppointment.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Core.Aggregates
{
    public class Doctor: BaseEntity<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Attending { get; set; }
    }
}
