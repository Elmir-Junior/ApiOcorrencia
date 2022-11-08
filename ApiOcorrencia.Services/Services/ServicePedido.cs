using ApiOcorrencia.Domain.Models;
using ApiOcorrencia.Infra.Repository.Interfaces;
using ApiOcorrencia.Infra.Repository.Interfaces.Base;
using ApiOcorrencia.Services.Interfaces;
using ApiOcorrencia.Services.Services.Base;
using System;
using System.Linq;

namespace ApiOcorrencia.Services.Services
{
    public class ServicePedido : ServiceBase<Pedido>, IServicePedido
    {
        public readonly IRepositoryPedido _repositoryPedido;
        public ServicePedido(IRepositoryPedido repositoryPedido) : base(repositoryPedido)
        {
            _repositoryPedido = repositoryPedido;
        }
        public override void Add(Pedido entity)
        {
            if (entity.Ocorrencias != null)
                throw new Exception("Cadastre as ocorrencias somente depois de salvar o Pedido");

            _repositoryPedido.Add(entity);

        }
    }
}
