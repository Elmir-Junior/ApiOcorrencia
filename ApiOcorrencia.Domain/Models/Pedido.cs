using ApiOcorrencia.Domain.Enum;
using ApiOcorrencia.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiOcorrencia.Domain.Models
{
    public class Pedido:Entity
    {
        public int NumeroPedido { get; set; }
        public List<Ocorrencia> Ocorrencias { get; set; }
        public DateTime HoraPedido { get; set; }
        public StatusPedido StatusPedido { get; set; }
    }
}
