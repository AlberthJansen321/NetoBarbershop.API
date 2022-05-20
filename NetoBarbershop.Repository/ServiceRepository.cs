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
    public class ServiceRepository : IServiceRepository
    {
        private readonly NetoBarbershopContext _context;
        public ServiceRepository(NetoBarbershopContext context)
        {
            _context = context;         
        }
        public async Task<Service> GetServiceByIdAsync(int id, bool includeServiceDone = false)
        {
            IQueryable<Service> query = _context.Services;

            if (includeServiceDone)
            {
                query = query.Include(
                    i => i.ServicesDones).ThenInclude(i => i.Service);
            }
            else
            {
                query = query.AsNoTracking();
            }
           
            query = query.OrderBy(o => o.Id).Where(w => w.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Service[]> GetServiceByNomeAsync(string nome, bool includeServiceDone = false)
        {
            IQueryable<Service> query = _context.Services;

            if (includeServiceDone)
            {
                query = query.Include(
                     i => i.ServicesDones).ThenInclude(i => i.Service);
            }

            query = query.OrderBy(o => o.Id).Where(w => w.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Service[]> GetAllServicesAsync(bool includeServiceDone = false)
        {
            IQueryable<Service> query = _context.Services;

            if (includeServiceDone)
            {
                query = query.Include(
                    i => i.ServicesDones).ThenInclude(i => i.Service);
            }

            query = query.OrderBy(o => o.Id);

            return await query.ToArrayAsync();
        }
    }
}
