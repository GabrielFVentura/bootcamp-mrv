using System.Collections.Generic;
using series_register.Interfaces.Repository;

namespace series_register.Classes.Serie.Repository
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> _listaSeries = new ();
        public List<Serie> Listar()
        {
            return _listaSeries;
        }

        public Serie? ProcurarPorId(int _id)
        {
            return _listaSeries[_id];
        }

        public void Inserir(Serie _entity)
        {
            _listaSeries.Add(_entity);
        }

        public void Excluir(int _id)
        {
            _listaSeries[_id].ExcluiSerie();
        }

        public void Atualiza(int _id, Serie _entity)
        {
            _listaSeries[_id] = _entity;
        }

        public int ProximoId()
        {
            return _listaSeries.Count;
        }
    }
}