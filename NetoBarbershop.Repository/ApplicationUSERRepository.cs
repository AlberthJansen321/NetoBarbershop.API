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
    public class ApplicationUSERRepository : IApplicationUSERRepository
    {
        private readonly NetoBarbershopContext _context;
        public ApplicationUSERRepository(NetoBarbershopContext context)
        {
            _context = context;
        }
        public async Task<ApplicationUSER> GetUserByIdAsync(string id, bool includeServiceDone = false)
        {

            IQueryable<ApplicationUSER> query = _context.Users;

            if (includeServiceDone)
            {
                query = query.Include(
                    i => i.ServicesDones).ThenInclude(i => i.Service);
            }

            query = query.OrderBy(o => o.Id).Where(w => w.Id.ToString() == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ApplicationUSER[]> GetAllUsersAsync(bool includeServiceDone = false)
        {
            IQueryable<ApplicationUSER> query = _context.Users;

            if (includeServiceDone)
            {
                query = query.Include(
                    i => i.ServicesDones).ThenInclude(i => i.Service);
            }

            query = query.OrderBy(o => o.Id);

            return await query.ToArrayAsync();
        }

        public async Task<ApplicationUSER[]> GetUsersByNomeAsync(string nome, bool includeServiceDone = false)
        {
            IQueryable<ApplicationUSER> query = _context.Users;

            if (includeServiceDone)
            {
                query = query.Include(
                    i => i.ServicesDones).ThenInclude(i => i.Service);
            }

            query = query.OrderBy(o => o.Id).Where(w => w.FullName == nome);

            return await query.ToArrayAsync();
        }
    }
}
