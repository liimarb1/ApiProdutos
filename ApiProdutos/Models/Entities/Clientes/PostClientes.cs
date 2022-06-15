using System;
using System.ComponentModel.DataAnnotations;

namespace ApiProdutos.Models.Entities.Clientes
{
    public class PostClientes
    {
       
        [Required]
        public string Nome { get; set; }
        
    }
}
