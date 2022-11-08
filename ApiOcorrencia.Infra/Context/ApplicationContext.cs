using ApiOcorrencia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiOcorrencia.Infra.Context
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext()
        { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
