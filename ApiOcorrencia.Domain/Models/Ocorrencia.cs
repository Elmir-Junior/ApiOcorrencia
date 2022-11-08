using ApiOcorrencia.Domain.Enum;
using ApiOcorrencia.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiOcorrencia.Domain.Models
{
    public class Ocorrencia:Entity
    {
        public Ocorrencia()
        {
            HoraOcorrencia = DateTime.Now;
        }
        public TipoOcorrencia TipoOcorrencia { get; set; }
        public DateTime HoraOcorrencia { get; set; }
        public bool IndFinalizado { get; set; }
        public int PedidoId { get; set; }
    }
}
