using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtividadeAulaTarde.Models;
using Newtonsoft.Json;

namespace AtividadeAulaTarde.DAO
{
    public class ConsultaDao
    {
        private readonly Context _context;
        public ConsultaDao(Context context)
        {
            _context = context;

        }


        public void Cadastrar(CadCep endereco)
        {
            _context.Add(endereco);
            _context.SaveChanges();
        }

        public string ListarEndereco(string cep)
        {

            var consulta = _context.Endereco.Where(consulta => consulta.Cep == cep);

            var result = JsonConvert.SerializeObject(consulta);

            return result;
        }


        public List<CadCep> Listar()
        {
            return _context.Endereco.ToList();
        }



        public void Atualizar(CadCep consulta)
        {
            _context.Update(consulta);
            _context.SaveChanges();
        }


        public void Deletar(int id)
        {
            CadCep consulta = _context.Endereco.Find(id);
            _context.Endereco.Remove(consulta);
            _context.SaveChanges();
        }
    }
}
