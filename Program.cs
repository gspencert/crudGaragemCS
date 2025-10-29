using System;

public class Program
{
    const int TAM = 20;
    static void cadastrarCarro(string[] placas, ref int qtdInseridos)
    {
        if (qtdInseridos == TAM)
        {
            Console.WriteLine("Garagem lotada, tente novamente mais tarde.");
        } else
        {
            Console.Write("Digite a placa: ");
            string placa = Console.ReadLine()!.ToUpper();

            for (int i = 0; i < qtdInseridos; i++)
            {
                if (placas[i] == placa)
                {
                    Console.WriteLine("Placa ja registrada.");
                    return;
                }
            }

            placas[qtdInseridos] = placa;
            qtdInseridos++;
            Console.WriteLine($"Placa {placa} foi registrada.");
        }
    }
    static void listarCarros(string[] placas, int qtdInseridos)
    {
        if (qtdInseridos == 0)
        {
            Console.WriteLine("Garagem vazia, deve adicionar um carro primeiro.");
        } else
        {
            Console.WriteLine("Placas na garagem: ");
            for (int i = 0; i < qtdInseridos; i++)
            {
                Console.WriteLine($"Placa {i + 1}: {placas[i]}");
            }

            Console.WriteLine($"Total de placas registradas: {qtdInseridos}");
        }
    }

    static void removerCarro(string[] placas, ref int qtdInseridos)
    {
        if (qtdInseridos == 0)
        {
            Console.WriteLine("Nenhum carro pra remover");
            return;
        }

        listarCarros(placas, qtdInseridos);

        Console.WriteLine("Digite um carro pra remover: ");
        int escolha = Convert.ToInt32(Console.ReadLine());

        if (escolha < 1 || escolha > qtdInseridos)
        {
            Console.WriteLine("Escolha inválida.");
            return;
        }

        int indice = escolha - 1;

        Console.WriteLine($"Removendo placa {placas[indice]}");

        for (int i = indice; i < qtdInseridos - 1; i++)
        {
            placas[i] = placas[i + 1];
        }
        qtdInseridos--;
        Console.WriteLine("Carro removido com sucesso.");
        return;
    }

    static void substituirPlaca(string[] placas, int qtdInseridos)
    {
        if (qtdInseridos == 0)
        {
            Console.WriteLine("Garagem vazia. Adicione um carro primeiro.");
            return;
        }

        listarCarros(placas, qtdInseridos);

        Console.Write("Digite o número do carro que deseja substituir a placa: ");
        
        if (!int.TryParse(Console.ReadLine(), out int escolha))
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }

        if (escolha < 1 || escolha > qtdInseridos)
        {
            Console.WriteLine("Escolha inválida.");
            return;
        }

        int indice = escolha - 1;
        string placaAntiga = placas[indice];

        Console.Write($"Digite a **nova placa** para substituir **{placaAntiga}**: ");
        string novaPlaca = Console.ReadLine()!.ToUpper();

        for (int i = 0; i < qtdInseridos; i++)
        {
            if (placas[i] == novaPlaca)
            {
                Console.WriteLine($"A placa {novaPlaca} já está registrada na posição {i + 1}. Substituição cancelada.");
                return;
            }
        }

        placas[indice] = novaPlaca;
        Console.WriteLine($"Placa substituída com sucesso: {placaAntiga} -> {novaPlaca}");
    }

    public static void Main()
    {
        string[] placas = new string[TAM];
        int qtdInseridos = 0;
        int opcao;

        do
        {
            Console.WriteLine("---- MENU ----");
            Console.WriteLine("1 - Adidionar carro");
            Console.WriteLine("2 - Listar carros");
            Console.WriteLine("3 - Substituir carro");
            Console.WriteLine("4 - Remover carro");
            Console.WriteLine("5 - Sair");
            Console.Write("Opção: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                opcao = 0;
            }

            switch (opcao)
            {
                case 1:
                    cadastrarCarro(placas, ref qtdInseridos);
                    break;
                case 2:
                    listarCarros(placas, qtdInseridos);
                    break;
                case 3:
                    substituirPlaca(placas, qtdInseridos);
                    break;
                case 4:
                    removerCarro(placas, ref qtdInseridos);
                    break;
                case 5:
                    Console.WriteLine("Saindo da garagem, volte sempre!");
                    break;    
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        } while (opcao != 4);
    }
}
