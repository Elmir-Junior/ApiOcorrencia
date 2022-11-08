using ApiOcorrencia.Domain.Models;
using ApiOcorrencia.Infra.Repository.Interfaces;
using ApiOcorrencia.Services.Interfaces;
using ApiOcorrencia.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiOcorrencia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciasController : ControllerBase
    {
        private readonly IServiceOcorrencia _serviceOcorrencia;

        public OcorrenciasController(IServiceOcorrencia serviceOcorrencia)
        {
            _serviceOcorrencia = serviceOcorrencia;
        }

        // GET: api/<OcorrenciasController>
        [HttpGet]
        public IEnumerable<Ocorrencia> Get()
        {
            return _serviceOcorrencia.GetAll();
        }

        // GET api/<OcorrenciasController>/5
        [HttpGet("{id}")]
        public Ocorrencia Get(int id)
        {
            return _serviceOcorrencia.GetById(id);
        }

        // POST api/<OcorrenciasController>
        [HttpPost]
        public void Post([FromBody] Ocorrencia Ocorrencia)
        {
            try
            {
            _serviceOcorrencia.Add(Ocorrencia);

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        // PUT api/<OcorrenciasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Ocorrencia Ocorrencia)
        {
            _serviceOcorrencia.Update(Ocorrencia);
        }

        // DELETE api/<OcorrenciasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _serviceOcorrencia.Remove(_serviceOcorrencia.GetById(id));
        }
    }
}
