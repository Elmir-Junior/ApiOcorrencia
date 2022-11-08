using ApiOcorrencia.Domain.Models;
using ApiOcorrencia.Infra.Context;
using ApiOcorrencia.Infra.Repository.Interfaces;
using ApiOcorrencia.Infra.Repository.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiOcorrencia.Infra.Repository.Repositories
{
    public class RepositoryPedido : RepositoryBase<Pedido>, IRepositoryPedido
    {
        public readonly ApplicationContext _context;

        public RepositoryPedido(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Pedido> GetAll()
        {
            return _context.Set<Pedido>().Include(a => a.Ocorrencias).ToList();
        }
        public override Pedido GetById(int id)
        {
            return _context.Set<Pedido>()
                .Include(a => a.Ocorrencias)
                .FirstOrDefault(a => a.Id == id);
        }
    }
}