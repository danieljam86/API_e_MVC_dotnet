using GTISolutionTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SysCliente.Service
{
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        void Add(Cliente c);

        [OperationContract]
        Cliente Get(int id);
    }
}
