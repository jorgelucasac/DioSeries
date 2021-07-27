using System;

namespace Estudos.Dio.AppSeries.Dominio
{
    public class Serie : Entitade
    {
        public Serie(int id, string titulo, string descricao, Categoria categoria)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Categoria = categoria;
        }

        public string Titulo { get; }
        public string Descricao { get; }
        public Categoria Categoria { get; }

        public override string ToString()
        {
            var retorno = "";
            retorno += "Categoria: " + Categoria + Environment.NewLine;
            retorno += "Titulo: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Excluido: " + Excluido;
            return retorno;
        }
    }
}