using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtividadeAulaTarde.DAO;
using Newtonsoft.Json;
using System.Net;
using AtividadeAulaTarde.Models;

namespace AtividadeAulaTarde.Controllers

{


    //Iago Canez Medeiros ------ 1833441




    public class CepController : Controller 
    {
        private readonly ConsultaDao _consultaDao;
        public CepController(ConsultaDao consultaDao)
        {
            _consultaDao = consultaDao;
        }



        public IActionResult Index()
        {
            var model = _consultaDao.Listar();
            return View(model);
        }



        [HttpPost]
        public IActionResult ConsultaCep(string txtCep)
        {
            var url = $@"https://viacep.com.br/ws/{txtCep}/json/";

            WebClient client = new WebClient();

            TempData["Endereco"] = client.DownloadString(url);

            if (TempData["Endereco"] != null)
            {
                string result = TempData["Endereco"].ToString();
                TempData["Endereco"] = null;
                CadCep consulta = JsonConvert.DeserializeObject<CadCep>(result);
                consulta.Cep = consulta.Cep.Replace("-", "");
                _consultaDao.Cadastrar(consulta);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
//Teste de Comit
