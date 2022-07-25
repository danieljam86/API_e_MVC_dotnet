using System;

public class ClienteDao
{
	public ClienteDao()
	{
		private statis List<Cliente> clientes = new List<Cliente>();

		void add(Cliente c)
        {
			ClienteDao.clientes.Add(c);
        }

		public Cliente Get(int id)
        {
			var resutado = ClienteDao.clientes.Where(x => x.id == id).First();

			return (Cliente)resultado;
        }

	}
}
