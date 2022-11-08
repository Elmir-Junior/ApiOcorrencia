using ApiOcorrencia.Domain.Enum;
using ApiOcorrencia.Domain.Models;
using ApiOcorrencia.Infra.Repository.Interfaces;
using ApiOcorrencia.Services.Interfaces;
using ApiOcorrencia.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiOcorrencia.Services.Services
{
    public class ServiceOcorrencia : ServiceBase<Ocorrencia>, IServiceOcorrencia
    {
        public readonly IRepositoryOcorrencia _repositoryOcorrencia;
        public readonly IRepositoryPedido _repositoryPedido;

        public ServiceOcorrencia(IRepositoryOcorrencia repositoryOcorrencia, IRepositoryPedido repositoryPedido) : base(repositoryOcorrencia)
        {
            _repositoryOcorrencia = repositoryOcorrencia;
            _repositoryPedido = repositoryPedido;
        }
        public override void Add(Ocorrencia entity)
        {

            Pedido pedido = _repositoryPedido.GetById(entity.PedidoId); //busca de pedido pelo pedido informado
            
            if (pedido == null)
                throw new Exception("Pedido não encontrado");

            foreach (var a in pedido.Ocorrencias) //verificando as ocorrencias do pedido
            {
                if (entity.TipoOcorrencia == a.TipoOcorrencia &&  
                    a.HoraOcorrencia.AddMinutes(10) >= DateTime.Now) //verificando se o tipo e a hora é maior ou igual a 10 minutos
                {
                    throw new Exception("Não é possível cadastrar 2 ou mais ocorrências do " +
                        "mesmo tipo num intervalo de 10 minutos " +
                        "entre a última ocorrência cadastrado");
                }
                if (entity.TipoOcorrencia == TipoOcorrencia.EntregueSucesso) //Se a ocorrencia for do tipo entregue com sucesso é salvo como finalizado e o pedido como concluido
                {
                    entity.IndFinalizado = true;
                    pedido.StatusPedido = StatusPedido.IndConcluido;
                }
            }
            pedido.Ocorrencias.Add(entity);

            _repositoryOcorrencia.Add(entity);
            _repositoryPedido.Update(pedido);
        }
        public override void Remove(Ocorrencia entity)
        {
            var pedido = _repositoryPedido.GetById(entity.PedidoId);
            if (pedido.StatusPedido == StatusPedido.IndCancelado || pedido.StatusPedido == StatusPedido.IndConcluido)
            {
                throw new Exception("A ocorrência não pode ser removida");
            }

            _repositoryOcorrencia.Remove(entity);

        }
    }
}
