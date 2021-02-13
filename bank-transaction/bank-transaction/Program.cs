using System;
using System.Collections.Generic;
using bank_transaction.Classes.Conta;
using bank_transaction.Classes.Enums;

namespace bank_transaction
{
    class Program
    {
        private static List<Conta> listaContas = new ();
        static void Main(string[] args)
        {
            string? operacao = ObterOperacao();

            while (operacao?.ToUpper() != "X")
            {
                switch (operacao)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                operacao = ObterOperacao();
            }
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o Número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDepositado = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDepositado);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o Número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSacado = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSacado);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o Número da Conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Número da Conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            
            listaContas[indiceContaOrigem].Transferir(valorTransferencia, 
                listaContas[indiceContaDestino]);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas: ");
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta cadastrada ");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta.Print());
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            
            Console.WriteLine("Digite 1 para Conta Fisica 2 para Conta Juridica");
            int inputTipoConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Nome do Cliente: ");
            string inputNome = Console.ReadLine();
            
            Console.WriteLine("Digite o Saldo Inicial: ");
            double inputSaldoInicial = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Credito: ");
            double inputCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                _tipoConta: (TipoConta) inputTipoConta,
                _nome: inputNome,
                _saldo: inputSaldoInicial,
                _credito: inputCredito);
            
            listaContas.Add(novaConta);
        }

        private static string? ObterOperacao()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar Contas: ");
            Console.WriteLine("2 - Inserir nova Conta: ");
            Console.WriteLine("3 - Transferir: ");
            Console.WriteLine("4 - Sacar ");
            Console.WriteLine("5 - Depositar ");
            Console.WriteLine("C - Limpar Tela ");
            Console.WriteLine("X - Sair");

            string? operacaoUsuario = Console.ReadLine()?.ToUpper();
            Console.WriteLine();
            return operacaoUsuario;
        }
    }
}

