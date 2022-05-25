using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTISolutionTesteAPI.Models
{
    public class ClienteEnderecoDTO
    {
        public int Id { get; set; }
        public string cpf { get; set; }
        public string nome { get; set; }
        public string rg { get; set; }
        public DateTime dt_expedicao { get; set; }
        public string orgaoExpedicao { get; set; }
        public string UF { get; set; }
        public DateTime dt_nascimento { get; set; }
        public string sexo { get; set; }
        public string estadoCivil { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string UFEndereco { get; set; }
    }
}