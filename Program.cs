using System;

public class Program
{
    public static void Main()
    {
        string[] placas = new string[Funcoes.TAM];
        int qtdInseridos = 0;
        int opcao;

        do
        {
            Console.WriteLine("---- MENU ----");
            Console.WriteLine("1 - Adicionar carro");
            Console.WriteLine("2 - Listar carros");
            Console.WriteLine("3 - Substituir carro");
            Console.WriteLine("4 - Remover carro");
            Console.WriteLine("5 - Sair");
            Console.Write("Opção: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcao))
                opcao = 0;

            switch (opcao)
            {
                case 1:
                    Funcoes.cadastrarCarro(placas, ref qtdInseridos);
                    break;
                case 2:
                    Funcoes.listarCarros(placas, qtdInseridos);
                    break;
                case 3:
                    Funcoes.substituirPlaca(placas, qtdInseridos);
                    break;
                case 4:
                    Funcoes.removerCarro(placas, ref qtdInseridos);
                    break;
                case 5:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 5);
    }
}