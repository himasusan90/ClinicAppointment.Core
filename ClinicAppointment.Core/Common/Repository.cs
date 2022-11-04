using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClinicAppointment.Core.Common
{
    public interface  IRepository<T>
        where T : class
    {
        public T GetById(long id);


        Task<T> AddAsync(T entity);

    }
}
