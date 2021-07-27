using System;

namespace Estudos.Dio.AppSeries.Dominio
{
    public abstract class Entitade
    {
        protected Entitade()
        {
            Ativo = true;
            Excluido = false;
            DataCadastro = DateTime.Now;
        }

        public int Id { get; protected set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }
        public DateTime DataCadastro { get; }
        public DateTime? DataAlteracao { get; private set; }
        public DateTime? DataExclusao { get; private set; }

        public void Ativar()
        {
            if (Ativo) return;

            Ativo = true;
            DataAlteracao = DateTime.Now;
        }

        public void Desativar()
        {
            if (!Ativo) return;
            Ativo = false;
            DataAlteracao = DateTime.Now;
        }

        public void Excluir()
        {
            if (Excluido) return;
            Excluido = true;
            DataExclusao = DateTime.Now;
        }
    }
}