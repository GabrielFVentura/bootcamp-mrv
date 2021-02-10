using System.Collections.Generic;
using series_register.Classes.Serie;

namespace series_register.Interfaces.Repository
{
    public interface IRepository<T>
    {
        List<T> Listar();
        Serie? ProcurarPorId(int _id);
        void Inserir(T _entity);
        void Excluir(int _id);
        void Atualiza(int _id, T _entity);
        int ProximoId();
    }
}