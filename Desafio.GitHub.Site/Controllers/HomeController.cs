using Desafio.GitHub.Site.Models;
using Desafio.GitHub.Site.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Desafio.GitHub.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(RepositorioRetornoDto model)
        {
            if(model.Name != null)
            {
                List<RepositorioRetornoDto> repositorios = (Session["Repositorios"] as List<RepositorioRetornoDto>);

                ViewData["RepositoriosFiltrados"] = repositorios.Where(p => p.Name.ToUpper().Contains(model.Name.ToUpper())).ToList();
                ViewData["FiltroRealizado"] = true;
            }
            else
            {
                RestClient _proxyContaCorrente = new RestClient($"https://localhost:44388/api/v1/Repositorios/ListarRepositorios");
                var request = new RestRequest(Method.GET);
                IRestResponse<ListarRepositoriosRetornoDto> response = _proxyContaCorrente.Execute<ListarRepositoriosRetornoDto>(request);

                Session["Repositorios"] = JsonConvert.DeserializeObject<ListarRepositoriosRetornoDto>(response.Content).repositorios;
                ViewData["FiltroRealizado"] = false;
            }

            return View();
        }

        //public ActionResult Index(RepositorioRetornoDto model)
        //{


        //    return View();
        //}

        public ActionResult Favoritar(long id)
        {
            RestClient _proxyContaCorrente = new RestClient($"https://localhost:44388/api/v1/Repositorios/FavoritarRepositorio?id={id}");
            var request = new RestRequest(Method.POST);
            IRestResponse<FavoritarRepositorioRetornoDto> response = _proxyContaCorrente.Execute<FavoritarRepositorioRetornoDto>(request);
            
            ViewData["Favoritar"] = JsonConvert.DeserializeObject<FavoritarRepositorioRetornoDto>(response.Content);

            return View();
        }

        public ActionResult Favoritos()
        {
            RestClient _proxyContaCorrente = new RestClient($"https://localhost:44388/api/v1/Repositorios/ListarRepositoriosFavoritados");
            var request = new RestRequest(Method.GET);
            IRestResponse<ListarRepositoriosFavoritadosRetornoDto> response = _proxyContaCorrente.Execute<ListarRepositoriosFavoritadosRetornoDto>(request);

            ViewData["Favoritos"] = JsonConvert.DeserializeObject<ListarRepositoriosFavoritadosRetornoDto>(response.Content);

            return View();
        }

        public ActionResult Desfavoritar(long id)
        {
            RestClient _proxyContaCorrente = new RestClient($"https://localhost:44388/api/v1/Repositorios/DesfavoritarRepositorio?id={id}");
            var request = new RestRequest(Method.POST);
            IRestResponse<DesfavoritarRepositorioRetornoDto> response = _proxyContaCorrente.Execute<DesfavoritarRepositorioRetornoDto>(request);

            ViewData["Desfavoritar"] = JsonConvert.DeserializeObject<DesfavoritarRepositorioRetornoDto>(response.Content);

            return View();
        }

        public ActionResult Detalhar(long id)
        {
            var repositorio = (Session["Repositorios"] as List<RepositorioRetornoDto>).Where(p => p.Id == id).FirstOrDefault();

            ViewData["Repositorio"] = repositorio;

            return View();
        }
    }
}