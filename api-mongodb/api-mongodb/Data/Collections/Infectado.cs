using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace api_mongodb.Data.Collections
{
    public class Infectado
    {
        public Infectado(string nome, DateTime datanascimento, string sexo, int idade, double latitude, double longitude)
        {
            Nome = nome;
            DataNascimento = datanascimento;
            Sexo = sexo;
            Idade = idade;
            Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
        public int Idade { get; set; }
    }
}