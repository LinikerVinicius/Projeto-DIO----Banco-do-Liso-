using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();
                    
            while (OpcaoUsuario.ToUpper() !="X")
            {
                switch (OpcaoUsuario)
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
           
                OpcaoUsuario = ObterOpcaoUsuario();

            }
        
            Console.WriteLine("Obrigado por gastar meu tempo, seu LISO."); 
            Console.ReadLine();   
                       
        }

         private static void Sacar()
         {
            Console.Write("Digite o número da conta do Liso: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor praque vai ficar mais liso: ");
            double valorSaque = double.Parse(Console.ReadLine());
         
            listContas[indiceConta].Sacar(valorSaque);
         }

            private static void Depositar()
         {
            Console.Write("Digite o número da conta do Liso: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que você vai 'ajuntar': ");
            double valorDeposito = double.Parse(Console.ReadLine());
         
            listContas[indiceConta].Depositar(valorDeposito);
         }
            private static void Transferir()
         {
            Console.Write("Digite o número da conta do liso que vai ficar mais liso: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta do liso que vai ficar menos liso: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
         
            Console.Write("Digite o valor que você vai ficar mais liso: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }
        private static void InserirConta()
        {
            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Liso: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial do liso: ");
            double entradaTipoSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito do liso: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                     Saldo: entradaTipoSaldo,
                                     Credito: entradaCredito,
                                     Nome: entradaNome);
                                     
            listContas.Add(novaConta);     
        }
        private static void ListarContas()
        {
                Console.WriteLine("Listar contas dos Lisos");

                if (listContas.Count == 0)
                {
                    Console.WriteLine("Nenhum Liso cadastrado");
                    return;
                }

                for (int i = 0; i < listContas.Count; i++)
                {
                    Conta conta = listContas[i];
                    Console.Write("#{0} - ", i);
                    Console.WriteLine(conta);
                
                }
            }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Banco do Liso a seu dispor!!!");
            Console.WriteLine("Informe o que você quer e deixe de arrudei:");
            
            Console.WriteLine("1- Ver os Lisos");
            Console.WriteLine("2- Abrir conta para um liso");
            Console.WriteLine("3- Enviar dinheiro para um liso");
            Console.WriteLine("4- Tirar o pouco que tem");
            Console.WriteLine("5- Guardar o pouco que tem");
            Console.WriteLine("C- Fiz besteira, volta");
            Console.WriteLine("X- Deixa pra lá");

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}