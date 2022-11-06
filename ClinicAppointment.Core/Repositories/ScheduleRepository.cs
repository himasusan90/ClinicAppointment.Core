using ClinicAppointment.Core.Aggregates;
using ClinicAppointment.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClinicAppointment.Core.Repositories
{
    public class ScheduleRepository :IScheduleRepository
    {
        public void Add(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Schedule>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Schedule>> GetAllAsync<TProperty>(Expression<Func<Schedule, TProperty>> include)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Schedule entity)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> SingleOrDefaultAsync(Expression<Func<Schedule, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Schedule entity)
        {
            throw new NotImplementedException();
        }
    }
}
