using System;
using System.Collections.Generic;
using Estudos.Dio.AppSeries.Dominio;

namespace Estudos.Dio.AppSeries.Data
{
    public interface IRepository<TEntitade> where TEntitade : Entitade
    {
        void Adicionar(TEntitade entity);
        TEntitade ObeterPorId(int id);
        List<TEntitade> ObterTodos();
        void Atualizar(TEntitade entity);
        IList<TEntitade> Buscar(Func<TEntitade, bool> predicate);

        void Ativar(int id);
        void Desativar(int id);
        void Excluir(int id);
        int ObterProximoId();
    }
}