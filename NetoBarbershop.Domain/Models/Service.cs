using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetoBarbershop.Domain.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        [ForeignKey("ServiceID")]
        public IEnumerable<ServiceDone> ServicesDones { get; set; }
    }
}