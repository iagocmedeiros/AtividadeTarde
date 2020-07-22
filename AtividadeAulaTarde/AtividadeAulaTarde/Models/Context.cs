using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AtividadeAulaTarde.Models
{
    public class Context : DbContext
    {
        public DbSet<CadCep> Endereco { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
