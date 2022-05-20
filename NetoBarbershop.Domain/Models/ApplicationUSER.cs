using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Domain.Models
{
    public class ApplicationUSER: IdentityUser
    {
        public string FullName { get; set; }

        [ForeignKey("UsuarioID")]
        public IEnumerable<ServiceDone> ServicesDones { get; set; }
    }
}
