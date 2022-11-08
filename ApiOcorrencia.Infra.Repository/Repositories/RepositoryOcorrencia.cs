using ApiOcorrencia.Domain.Models;
using ApiOcorrencia.Infra.Context;
using ApiOcorrencia.Infra.Repository.Interfaces;
using ApiOcorrencia.Infra.Repository.Interfaces.Base;
using ApiOcorrencia.Infra.Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiOcorrencia.Infra.Repository.Repositories
{
    public class RepositoryOcorrencia : RepositoryBase<Ocorrencia>, IRepositoryOcorrencia
    {
        public readonly ApplicationContext _context;

        public RepositoryOcorrencia(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public Ocorrencia GetOcorrenciaByPedidoHora(DateTime HoraPedido)
        {
            var query = _context.Set<Ocorrencia>()
                .FirstOrDefault(a => a.HoraOcorrencia == HoraPedido);
            return query;
        }
    }
}
