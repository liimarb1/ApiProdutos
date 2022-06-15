using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutos.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(120)]
        public string Nome { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;


    }
}
