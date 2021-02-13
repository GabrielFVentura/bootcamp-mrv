using System;
using bank_transaction.Classes.Enums;

namespace bank_transaction.Classes.Conta
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }
        
        public Conta(TipoConta _tipoConta, double _saldo, double _credito, string _nome)
        {
            TipoConta = _tipoConta;
            Saldo = _saldo;
            Credito = _credito;
            Nome = _nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (Saldo - valorSaque < Credito * -1)
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            Saldo -= valorSaque;
            
            Console.WriteLine("Saldo atual da conta de {0} é de {1}", Nome, Saldo);
            
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            
            Console.WriteLine("Saldo atual da conta de {0} é de {1}", Nome, Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public string Print()
        {
            string retorno = "";
            retorno += "TipoConta: " + TipoConta + " | ";
            retorno += "Nome: " + Nome + " | ";
            retorno += "Saldo: " + Saldo + " | ";
            retorno += "Credito: " + Credito + " | ";
            return retorno;
        }
        


        
    }
}