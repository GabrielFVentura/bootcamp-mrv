using System;
using series_register.classes.Base;
using series_register.Enums;

namespace series_register.Classes.Serie
{
    public class Serie : Entity
    {
        public Serie()
        {
            Random rd = new ();
            Id = rd.Next(1, 15);
        }
        public Serie(int _id, string? _titulo, string? _descricao, int _anoLancamento, string? _produtora, Genero _genero)
        {
            Titulo = _titulo;
            Descricao = _descricao;
            AnoLancamento = _anoLancamento;
            Produtora = _produtora;
            Genero = _genero;
            Random rd = new ();
            Id = _id;
            Excluido = false;
        }

        private string? Titulo { get; set; }
        private string? Descricao { get; set; }
        private int? AnoLancamento { get; set; }
        private string? Produtora { get; set; }
        private Genero? Genero { get; set; }
        private bool Excluido { get; set; }

        public string Print()
        {
            string retorno = "";
            retorno += "Id : " + Id + Environment.NewLine;
            retorno += "Titulo : " + Titulo + Environment.NewLine;
            retorno += "Descrição : " + Descricao + Environment.NewLine;
            retorno += "Ano de Lançamento : " + AnoLancamento + Environment.NewLine;
            retorno += "Gênero : " + Genero + Environment.NewLine;
            retorno += "Produtora : " + Produtora + Environment.NewLine;
            return retorno;
        }

        public void ExcluiSerie()
        {
            Excluido = true;
        }

        public string? GetTitulo => Titulo;
        public int GetId => Id;
        public bool GetExcluido => Excluido;
    }
}