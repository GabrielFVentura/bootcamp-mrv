using System;

namespace api_mongodb.Models
{
    public class InfectadoDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Idade { get; set; }
    }
}