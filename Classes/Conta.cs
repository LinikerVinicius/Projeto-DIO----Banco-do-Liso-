using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get;set;}
        private double Saldo { get;set;}
        private double Credito { get;set;}
        private string Nome { get;set;}

        public Conta(TipoConta tipoConta,double Saldo, double Credito, string Nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }

        public bool Sacar(double valorSaque)
        { 
            //Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Tá Liso");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("{0} só tem {1} guardado", this.Nome, this.Saldo);

            return true;
        }
        public void Depositar(double valorDeposito)
        { 
            this.Saldo += valorDeposito;

            Console.WriteLine("{0} agora tem {1} guardado", this.Nome, this.Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
           string retorno = "";
           retorno += "TipoConta " + this.TipoConta + " | ";
           retorno += "Nome " + this.Nome + " | ";
           retorno += "Saldo " + this.Saldo + " | ";
           retorno += "Crédito " + this.Credito;
           return retorno;
        }

    }

}

    
