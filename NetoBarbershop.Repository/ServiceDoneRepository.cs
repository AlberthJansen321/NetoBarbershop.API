using Microsoft.EntityFrameworkCore;
using NetoBarbershop.Domain.Models;
using NetoBarbershop.Repository.Contextos;
using NetoBarbershop.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository
{
    public class ServiceDoneRepository: IServiceDoneRepository
    {
        private readonly NetoBarbershopContext _context;
        public ServiceDoneRepository(NetoBarbershopContext context)
        {
            _context = context; 
        }
        public async Task<ServiceDone> GetServiceDoneByIdAsync(int id)
        {
            IQueryable<ServiceDone> query = _context.servicesDone;

            query = query.OrderBy(o => o.Id).Where(w => w.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ServiceDone[]> GetAllServicesDonesAsync()
        {
            IQueryable<ServiceDone> query = _context.servicesDone;

            query = query.OrderBy(o => o.Id);

            return await query.ToArrayAsync();
        }
    }
}
