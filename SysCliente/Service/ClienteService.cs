using SysCliente.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysCliente.Service
{
    public class ClienteService : IClienteService
    {
        public void Add(Cliente c)
        {
            ClienteDao dao = new ClienteDao();
            dao.Add(c);
        }

        public Cliente Get(int id)
        {
            ClienteDao clienteDao = new ClienteDao();
            return clienteDao.Get(id);
        }
    }
}
