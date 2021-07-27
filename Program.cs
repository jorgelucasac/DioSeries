using System;
using Estudos.Dio.AppSeries.Data;
using Estudos.Dio.AppSeries.Dominio;

namespace Estudos.Dio.AppSeries
{
    internal class Program
    {
        private static readonly ISerieRepository SerieRepository = new SerieRepository();

        private static void Main(string[] args)
        {
            var opcaoUsuario = ObterOpcaoUsuario();


            while (opcaoUsuario.ToUpper() != "0")
            {
                try
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            ListarSeries();
                            break;
                        case "2":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            InserirSerie();
                            break;
                        case "3":
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            AtualizarSerie();
                            break;
                        case "4":
                            Console.ForegroundColor = ConsoleColor.Red;
                            ExcluirSerie();
                            break;
                        case "5":
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            VisualizarSerie();
                            break;
                        case "6":
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            BuscarSeries();
                            break;
                        case "C":
                            Console.Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Opção inválida!!");
                }

                Console.ResetColor();
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            var indiceSerie = int.Parse(Console.ReadLine());

            SerieRepository.Excluir(indiceSerie);
        }

        private static void BuscarSeries()
        {
            Console.Write("Digite o termo para realizar a busca: ");
            var termoBusca = Console.ReadLine();

            var series = SerieRepository.BuscarPorTitulo(termoBusca);

            if (series.Count == 0)
            {
                Console.WriteLine("Nenhum registro correspondente encontrado");
                return;
            }

            foreach (var serie in series)
                Console.WriteLine($"#ID {serie.Id}: - {serie.Titulo} {(serie.Excluido ? "*Excluído*" : "")}");
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            var indiceSerie = int.Parse(Console.ReadLine());

            var serie = SerieRepository.ObeterPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            var indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Categoria)))
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
            Console.Write("Digite o gênero entre as opções acima: ");
            var entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            var entradaTitulo = Console.ReadLine();


            Console.Write("Digite a Descrição da Série: ");
            var entradaDescricao = Console.ReadLine();

            var serie = new Serie(indiceSerie,
                categoria: (Categoria) entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao);

            SerieRepository.Atualizar(serie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = SerieRepository.ObterTodos();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
                Console.WriteLine($"#ID {serie.Id}: - {serie.Titulo} {(serie.Excluido ? "*Excluído*" : "")}");
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Categoria)))
                Console.WriteLine($"{i}-{Enum.GetName(typeof(Categoria), i)}");
            Console.Write("Digite o gênero entre as opções acima: ");
            var entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            var entradaTitulo = Console.ReadLine();

            Console.Write("Digite a Descrição da Série: ");
            var entradaDescricao = Console.ReadLine();

            var novaSerie = new Serie(SerieRepository.ObterProximoId(),
                categoria: (Categoria) entradaGenero,
                titulo: entradaTitulo,
                descricao: entradaDescricao);

            SerieRepository.Adicionar(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Oque deseja fazer?");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6- Buscar séries");
            Console.WriteLine("c- Limpar Tela");
            Console.WriteLine("0- Sair");
            Console.WriteLine();

            var opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}