using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SysCliente.Service
{

    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int id_cliente { get; set; }
        [DataMember]
        public string cpf { get; set; }
        [DataMember]
        public string nome { get; set; }
        [DataMember]
        public string rg { get; set; }
        [DataMember]

        public DateTime? dt_expedicao { get; set; }
        [DataMember]
        public string orgaoExpedicao { get; set; }
        [DataMember]
        public string UF { get; set; }
        [DataMember]

        public DateTime? dt_nascimento { get; set; }
        [DataMember]
        public string sexo { get; set; }
        [DataMember]
        public string estadoCivil { get; set; }
    }
}
