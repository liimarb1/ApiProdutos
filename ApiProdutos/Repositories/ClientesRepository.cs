using ApiProdutos.Models;
using ApiProdutos.Models.Entities.Clientes;

namespace ApiProdutos.Repositories
{
    public interface IClientesRepository 
    {
        public bool Create(PostClientes cliente);
    }
    public class ClientesRepository : IClientesRepository
    {
        private readonly _DbContext db;

        public ClientesRepository(_DbContext _db)
        {
           db = _db;
        }

        public bool Create(PostClientes cliente)
        {
              try
              {
                var cliente_db = new Clientes()
                {
                    Nome = cliente.Nome,
                    DataInicio = cliente.DataInicio,
                    DataFim = cliente.DataFim



                };

                db.clientes.Add(cliente_db);
                db.SaveChanges();

                  return true;   
              }
              catch
              {
                  return false;
              }
            }
        }
    }

