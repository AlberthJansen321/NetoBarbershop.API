using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetoBarbershop.Domain.Models
{
    public class ServiceDone
    {
        [Key]
        public int Id { get; set; }
        public string ClienteNome { get; set; }
        public DateTime Data { get; set; }
        public bool Finalizado { get; set; }
        public bool Cancelado { get; set; }
        [ForeignKey("Usuario")]
        public string UsuarioID { get; set; }
        public virtual ApplicationUSER Usuario { get; set; }
        [ForeignKey("Service")]
        public int? ServiceID { get; set; }
        public virtual Service Service { get; set; }
    }
}
