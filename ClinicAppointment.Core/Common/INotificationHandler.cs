using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointment.Core.Common
{
    public interface INotification
    {
    }
    public interface INotificationHandler<in TNotification> where TNotification : INotification
    {
    }
}
