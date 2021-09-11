using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcao = ObterOpcaoUsuario();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarConta();
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

                opcao = ObterOpcaoUsuario();               
            }

            Console.WriteLine("Obrigado por utilizar nosso serviço");
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para conta fisica ou 2 para Juridica");
            int entraTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            string entraNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entraTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entraNome);

            listaContas.Add(novaConta);
        }

        private static void ListarConta()
        {
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas");
                return;
            }

            for (var i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0} . ", (i+1));
                Console.WriteLine(conta);
            }
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            --indiceConta;

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            --indiceConta;

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número de conta de origem");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            --indiceContaOrigem;

            Console.Write("Digite o número de conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            --indiceContaDestino;

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            
            listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static string ObterOpcaoUsuario()
        {
           Console.WriteLine();
           Console.WriteLine("DIO Bank a seu dispor!!");
           Console.WriteLine("Informe a opção desejada");

           Console.WriteLine("1- Listar Contas");
           Console.WriteLine("2- Inserir nova conta");
           Console.WriteLine("3- Transferir");
           Console.WriteLine("4- Sacar");
           Console.WriteLine("5- Depositar");
           Console.WriteLine("C- Limpar Tela");
           Console.WriteLine("X- Sair");
           
           string opcaoUsuario = Console.ReadLine().ToUpper();
           Console.WriteLine();
           return opcaoUsuario;  
        }
    }

  
}
