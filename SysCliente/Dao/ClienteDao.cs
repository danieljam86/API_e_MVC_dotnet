using SysCliente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysCliente.Dao
{
	public class ClienteDao
	{
		private static List<Cliente> clientes = new List<Cliente>();

		public void Add(Cliente c)
		{
			ClienteDao.clientes.Add(c);
		}

		public Cliente Get(int id)
		{
			var resultado = ClienteDao.clientes.Where(x => x.id_cliente == id).First();

			return (Cliente)resultado;
		}
	}
}
