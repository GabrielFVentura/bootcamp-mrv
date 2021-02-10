using System;
using series_register.Classes.Serie;
using series_register.Classes.Serie.Repository;
using series_register.Enums;
using System.Linq;

namespace series_register
{
    class Program
    {
        private static SerieRepository _repository = new ();
        static void Main(string[] args)
        {
            Serie minhaSerie = new ();

            string? operacao = ObterOperacao();

            while (operacao?.ToUpper() != "X")
            {
                switch (operacao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                operacao = ObterOperacao();
            }
            
            Console.WriteLine(minhaSerie.Print());
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da serie a ser visualizada: ");
            int idSerie = int.Parse(Console.ReadLine() ?? string.Empty);

            Serie? serie = _repository.ProcurarPorId(idSerie);
            
            if (serie != null)
            {
                Console.Write(serie.Print());
            }
            else
            {
                Console.Write("Serie não encontrada");
            }
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id da serie a ser excluída: ");
            int idSerie = int.Parse(Console.ReadLine() ?? string.Empty);
            
            var lista = _repository.Listar();
            var existeId = lista.Any(s => s.Id == idSerie);

            if (existeId)
            {
                _repository.Excluir(idSerie);
            }
            else
            {
                Console.WriteLine("ID não encontrada");
            }
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da serie a ser atualizada: ");
            int idSerie = int.Parse(Console.ReadLine() ?? string.Empty);
            
            var lista = _repository.Listar();
            var existeId = lista.Any(s => s.Id == idSerie);
            
            if (existeId)
            {
                Console.WriteLine("Atualizar uma série");
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }

                var (inputGenero,
                    inputTitulo,
                    inputAno,
                    inputDescricao,
                    inputProdutora) = Inputs();

                Serie serieAtualizada = new(
                    _id: _repository.ProximoId(),
                    _genero: (Genero) inputGenero,
                    _titulo: inputTitulo,
                    _descricao: inputDescricao,
                    _anoLancamento: inputAno,
                    _produtora: inputProdutora
                );

                _repository.Atualiza(idSerie, serieAtualizada);
            }
            else
            {
                Console.WriteLine("ID não encontrada");
            }
            
        }

        public static void ListarSeries()
        {

            var lista = _repository.Listar();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada!");
                return;
            }
            
            Console.WriteLine("Listar séries Cadastradas");

            foreach (var serie in lista)
            {
                bool excluido = serie.GetExcluido;
                Console.WriteLine("{0} - {1} - {2}", serie.GetId, serie.GetTitulo, excluido ? "*Excluido" : "");
            }
        }

        public static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            var (inputGenero, 
                inputTitulo, 
                inputAno, 
                inputDescricao, 
                inputProdutora) = Inputs();

            Serie serieInserida = new(
                _id: _repository.ProximoId(),
                _genero: (Genero) inputGenero,
                _titulo: inputTitulo,
                _descricao: inputDescricao,
                _anoLancamento: inputAno,
                _produtora: inputProdutora
            );
            
            _repository.Inserir(serieInserida);
        }

        private static (int inputGenero, 
            string inputTitulo,
            int inputAno, 
            string inputDescricao, 
            string inputProdutora) Inputs() {
            Console.Write("Digite o Genêro entre as opções acima: \n");
            int inputGenero = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Digite o Titulo da Série: \n");
            string? inputTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento da Série: \n");
            int inputAno = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Digite a Descrição da Série: \n");
            string? inputDescricao = Console.ReadLine();

            Console.Write("Digite a Produtora responsável pela série: \n");
            string? inputProdutora = Console.ReadLine();
            
            return (inputGenero, inputTitulo, inputAno, inputDescricao, inputProdutora)!;
        }

        private static string? ObterOperacao()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar Séries: ");
            Console.WriteLine("2 - Inserir nova série: ");
            Console.WriteLine("3 - Atualizar série: ");
            Console.WriteLine("4 - Excluir série ");
            Console.WriteLine("5 - Visualizar série ");
            Console.WriteLine("C - Limpar Tela ");
            Console.WriteLine("X - Sair");

            string? operacaoUsuario = Console.ReadLine()?.ToUpper();
            Console.WriteLine();
            return operacaoUsuario;
        }
    }
}
