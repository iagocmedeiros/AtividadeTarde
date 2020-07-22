using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AtividadeAulaTarde.Models;
using AtividadeAulaTarde.DAO;

namespace AtividadeAulaTarde.Controllers
{
    [Route("api/Endereco")]
    [ApiController]
    public class CepAPIController : ControllerBase
    {


        //Iago Canez Medeiros ------ 1833441




        private readonly ConsultaDao _consultaDao;
        public CepAPIController(ConsultaDao consultaDao)
        {
            _consultaDao = consultaDao;
        }




        // GET: api/Endereco/ListarEnderecos
        [HttpGet]
        [Route("ListarEnderecos")]
        public List<CadCep> Listar()
        {
            return _consultaDao.Listar();
        }




        // GET: api/Endereco/ListarEndereco/{81730000}
        [HttpGet]
        [Route("ListarEndereco/{cep}")]
        public string ListarEndereco(string cep)
        {
            return _consultaDao.ListarEndereco(cep);
        
        }




        // POST: api/Endereco/CadastrarEndereco
        [HttpPost]
        [Route("CadastrarEndereco")]
        public IActionResult CadastrarEndereco(CadCep cadcep)
        {
            _consultaDao.Cadastrar(cadcep);

            return Created("", cadcep);
        }




        // PUT: api/Endereco/AlterarEndereco  
        [HttpPut]
        [Route("AlterarEndereco")]
        public void AlterarEndereco(CadCep cadCep)
        {
            _consultaDao.Atualizar(cadCep);

        }




        // DELETE: api/Endereco/DeletarEndereco/{id}
        [HttpDelete]
        [Route("DeletarEndereco/{id}")]
        public void DeletarEndereco(int id)
        {
            _consultaDao.Deletar(id);
        }


    }
}
