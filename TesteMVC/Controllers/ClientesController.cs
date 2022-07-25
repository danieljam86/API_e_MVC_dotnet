using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GTISolutionTeste.Models;

namespace GTISolutionTeste.Controllers
{
    public class ClientesController : Controller
    {
        private Contexto db = new Contexto();
        public static string linkAPI = "http://localhost/api/";

        // GET: Clientes
        public ActionResult Index()
        {
            IEnumerable<Cliente> clientes = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(linkAPI);

                //HTTP GET
                var responseTask = client.GetAsync("clientes");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Cliente>>();
                    readTask.Wait();
                    clientes = readTask.Result;
                }
                else
                {
                    clientes = Enumerable.Empty<Cliente>();
                    TempData["ERRO"] = "Erro no servidor. Contate o Administrador.";
                }
                return View(clientes);
            }
        }

        // GET: Clientes/Create
        [HttpGet]
        public ActionResult Create()
        {
            List<GetAPIConsulta.EstadosConsulta> estados = new List<GetAPIConsulta.EstadosConsulta>();
            estados = GetAPIConsulta.ConsultaEstado();
            ViewBag.EstadosCliente = new SelectList(estados, "sigla", "sigla");
            ViewBag.EstadosEndereco = new SelectList(estados, "sigla", "sigla");;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (cliente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {   
                var enderecoCliente = new EnderecoCliente();
                enderecoCliente.cep = Request["cep"];
                enderecoCliente.logradouro = Request["logradouro"];
                enderecoCliente.numero = Request["numero"];
                enderecoCliente.complemento = Request["complemento"];
                enderecoCliente.bairro = Request["bairro"];
                enderecoCliente.cidade = Request["cidade"];
                enderecoCliente.UF = Request["EstadosEndereco"];
                cliente.UF = Request["EstadosCliente"];
                cliente.EnderecoCliente.Add(enderecoCliente);

                client.BaseAddress = new Uri(linkAPI);

                cliente.cpf = cliente.cpf.Replace(".", "");
                cliente.cpf = cliente.cpf.Replace("-", "");
                //HTTP POST
                var postTask = client.PostAsJsonAsync<Cliente>("clientes", cliente);
                postTask.Wait();
                var result = postTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["SUCESSO"] = "Usuário " + cliente.nome + " cadastrado com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ERRO"] = "Erro no servidor. Contate o Administrador. Erro " + result.StatusCode + " " + result.RequestMessage + " " + result.ReasonPhrase;
                }
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<GetAPIConsulta.EstadosConsulta> estados = new List<GetAPIConsulta.EstadosConsulta>();
            estados = GetAPIConsulta.ConsultaEstado();
            

            ClienteEnderecoDTO clientes = null;

            using (var client = new HttpClient())
            {
                

                client.BaseAddress = new Uri(linkAPI + "clientes");

                //HTTP GET
                var responseTask = client.GetAsync("?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClienteEnderecoDTO>();
                    readTask.Wait();
                    clientes = readTask.Result;
                }
                
            }
            ViewBag.EstadosCliente = new SelectList(estados, "sigla", "sigla", clientes.UF);
            
            ViewBag.EnderecoCliente = clientes.EnderecoCliente;
            foreach(var item in clientes.EnderecoCliente)
            {
                ViewBag.EstadosEndereco = new SelectList(estados, "sigla", "sigla", item.UF);
            }
           
            return View(clientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (cliente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var client = new HttpClient())
            {

                var enderecoCliente = new EnderecoCliente();
                enderecoCliente.cep = Request["cep"];
                enderecoCliente.logradouro = Request["logradouro"];
                enderecoCliente.numero = Request["numero"];
                enderecoCliente.complemento = Request["complemento"];
                enderecoCliente.bairro = Request["bairro"];
                enderecoCliente.cidade = Request["cidade"];
                enderecoCliente.UF = Request["EstadosEndereco"];
                enderecoCliente.Cliente_id_cliente = Convert.ToInt32(Request["id"]);
                enderecoCliente.id_endereco = Convert.ToInt32(Request["id_endereco"]);

                cliente.EnderecoCliente.Add(enderecoCliente);

                cliente.UF = Request["EstadosCliente"];
                cliente.id_cliente = Convert.ToInt32(Request["id"]);

                client.BaseAddress = new Uri(linkAPI);
                cliente.cpf = cliente.cpf.Replace(".", "");
                cliente.cpf = cliente.cpf.Replace("-", "");
                //HTTP PUT
                var putTask = client.PutAsJsonAsync<Cliente>("clientes", cliente);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["SUCESSO"] = "Alterações no usuário: " + cliente.nome + " realizada com sucesso.";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Clientes/Delete/5
        public ActionResult DeletarCliente(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<GetAPIConsulta.EstadosConsulta> estados = new List<GetAPIConsulta.EstadosConsulta>();
            estados = GetAPIConsulta.ConsultaEstado();


            ClienteEnderecoDTO clientes = null;

            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(linkAPI + "clientes");

                //HTTP GET
                var responseTask = client.GetAsync("?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ClienteEnderecoDTO>();
                    readTask.Wait();
                    clientes = readTask.Result;
                }

            }
            ViewBag.EstadosCliente = new SelectList(estados, "sigla", "sigla", clientes.UF);

            ViewBag.EnderecoCliente = clientes.EnderecoCliente;
            foreach (var item in clientes.EnderecoCliente)
            {
                ViewBag.EstadosEndereco = new SelectList(estados, "sigla", "sigla", item.UF);
            }
            return PartialView(clientes);
        }


        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(linkAPI);
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("clientes/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    TempData["SUCESSO"] = "Cliente excluído com sucesso.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ERRO"] = "Erro no servidor. Contate o Administrador. Erro " + result.StatusCode + " " + result.RequestMessage + " " + result.ReasonPhrase;
                }
            }
            return View(cliente);
        }

    protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
