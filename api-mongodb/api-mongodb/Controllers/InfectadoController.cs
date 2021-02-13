using System;
using api_mongodb.Data.Collections;
using api_mongodb.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api_mongodb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Api.Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Api.Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.Nome, dto.DataNascimento, dto.Sexo, dto.Idade, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }

        [HttpPut]
        public ActionResult AtualizarIdadeInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = _infectadosCollection.Find(Builders<Infectado>.Filter.Where(x => x.Nome == dto.Nome))
                .FirstOrDefault();
            _infectadosCollection.UpdateOne(
                Builders<Infectado>.Filter.Where(x => x.Nome == dto.Nome),
                Builders<Infectado>.Update.Set("idade", dto.Idade));

            var resp = new
            {
                IdadeAntes = infectado.Idade,
                IdadeDepois = dto.Idade
            };
            
            return Ok(resp);
        }

        [HttpDelete]
        public ActionResult DeletarInfectado(string nome)
        {
            _infectadosCollection.DeleteOne(
                Builders<Infectado>.Filter.Where(x => x.Nome == nome));

            return Ok("Delete com Sucesso");
        }
    }
}