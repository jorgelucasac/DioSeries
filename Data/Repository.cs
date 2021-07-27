using System;
using System.Collections.Generic;
using System.Linq;
using Estudos.Dio.AppSeries.Dominio;

namespace Estudos.Dio.AppSeries.Data
{
    public abstract class Repository<TEntitade> : IRepository<TEntitade> where TEntitade : Entitade
    {
        protected readonly IList<TEntitade> BancoDados;

        protected Repository()
        {
            BancoDados = new List<TEntitade>();
        }

        public void Adicionar(TEntitade entitade)
        {
            BancoDados.Add(entitade);
        }

        public TEntitade ObeterPorId(int id)
        {
            return BancoDados.FirstOrDefault(a => a.Id == id);
        }

        public List<TEntitade> ObterTodos()
        {
            return BancoDados.ToList();
        }

        public void Atualizar(TEntitade entidade)
        {
            BancoDados[entidade.Id] = entidade;
        }

        public IList<TEntitade> Buscar(Func<TEntitade, bool> predicate)
        {
            return BancoDados.Where(predicate).ToList();
        }

        public void Ativar(int id)
        {
            BancoDados[id].Ativar();
        }

        public void Desativar(int id)
        {
            BancoDados[id].Desativar();
        }

        public void Excluir(int id)
        {
            BancoDados[id].Excluir();
        }

        public int ObterProximoId()
        {
            return BancoDados.Count;
        }
    }
}