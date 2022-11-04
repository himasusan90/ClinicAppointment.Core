using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Core.Common
{
    public abstract class BaseEntity<TId>
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();

        public TId Id { get; set; }
    }
}
