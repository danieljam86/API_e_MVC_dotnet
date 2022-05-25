using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GTISolutionTeste.Models
{
    public class GetAPIConsulta
    {
        public class EstadosConsulta
        {
            public int id { get; set; }
            public string sigla { get; set; }
            public string nome { get; set; }

        }

        public class MunicipiosConsulta
        {
            public int idMunicipio { get; set; }
            public string nomeMunicipio { get; set; }
        }

        public class CEPConsulta
        {
            public string code { get; set; }
            public string state { get; set; }
            public string city { get; set; }
            public string district { get; set; }
            public string address { get; set; }
        }

        public static List<EstadosConsulta> ConsultaEstado()
        {
            EstadosConsulta estadosConsulta = new EstadosConsulta();
            IEnumerable<EstadosConsulta> estados = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://servicodados.ibge.gov.br/api/v1/localidades/");

                //HTTP GET
                var responseTask = client.GetAsync("estados?orderBy=nome");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<EstadosConsulta>>();
                    //foreach (var item in readTask.Result)
                    //{
                    //    estadosConsulta.id = item.id;
                    //    estadosConsulta.sigla = item.sigla;
                    //    estadosConsulta.nome = item.nome;
                    //}
                    readTask.Wait();
                    estados = readTask.Result;
                }
                else
                {
                    estados = Enumerable.Empty<EstadosConsulta>();
                }
            }
            return estados.ToList();
        }
    }
}