using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Core.Common
{
    public abstract class BaseDomainEvent :INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;

    }
}
