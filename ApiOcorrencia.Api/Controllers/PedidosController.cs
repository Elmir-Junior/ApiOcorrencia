using ApiOcorrencia.Domain.Models;
using ApiOcorrencia.Infra.Repository.Interfaces;
using ApiOcorrencia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiOcorrencia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IServicePedido _servicePedido;

        public PedidosController(IServicePedido _ServicePedido)
        {
            this._servicePedido = _ServicePedido;
        }

        // GET: api/<PedidosController>
        [HttpGet]
        public IEnumerable<Pedido> Get()
        {
            return _servicePedido.GetAll();
        }

        // GET api/<PedidosController>/5
        [HttpGet("{id}")]
        public Pedido Get(int id)
        {
            return _servicePedido.GetById(id);
        }

        // POST api/<PedidosController>
        [HttpPost]
        public void Post([FromBody] Pedido pedido)
        {

            _servicePedido.Add(pedido);
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pedido pedido)
        {
            _servicePedido.Update(pedido);
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _servicePedido.Remove(_servicePedido.GetById(id));
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
