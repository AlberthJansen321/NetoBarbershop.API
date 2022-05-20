using NetoBarbershop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Repository.Interfaces
{
    public interface IApplicationUSERRepository
    {
        //APPLICATIONUSER
        Task<ApplicationUSER[]> GetAllUsersAsync(bool includeServiceDone = false);
        Task<ApplicationUSER> GetUserByIdAsync(string id, bool includeServiceDone = false);
        Task<ApplicationUSER[]> GetUsersByNomeAsync(string nome, bool includeServiceDone = false);
    }
}
