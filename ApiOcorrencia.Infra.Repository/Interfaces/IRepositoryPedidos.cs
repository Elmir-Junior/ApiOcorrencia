using ApiOcorrencia.Domain.Models;
using ApiOcorrencia.Infra.Repository.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiOcorrencia.Infra.Repository.Interfaces
{
    public interface IRepositoryPedido:IRepository<Pedido>
    {
    }
}
