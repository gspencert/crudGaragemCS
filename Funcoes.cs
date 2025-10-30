public static class Funcoes
{
    public const int TAM = 20;

    public static void cadastrarCarro(string[] placas, ref int qtdInseridos)
    {
        if (qtdInseridos == TAM)
        {
            Console.WriteLine("Garagem lotada.");
            return;
        }

        Console.Write("Digite a placa: ");
        string placa = Console.ReadLine()!.ToUpper();

        for (int i = 0; i < qtdInseridos; i++)
        {
            if (placas[i] == placa)
            {
                Console.WriteLine("Placa já registrada.");
                return;
            }
        }

        placas[qtdInseridos] = placa;
        qtdInseridos++;
        Console.WriteLine($"Placa {placa} registrada com sucesso.");
    }

    public static void listarCarros(string[] placas, int qtdInseridos)
    {
        if (qtdInseridos == 0)
        {
            Console.WriteLine("Garagem vazia.");
            return;
        }

        Console.WriteLine("Placas registradas:");
        for (int i = 0; i < qtdInseridos; i++)
            Console.WriteLine($"{i + 1} - {placas[i]}");
    }

    public static void removerCarro(string[] placas, ref int qtdInseridos)
    {
        if (qtdInseridos == 0)
        {
            Console.WriteLine("Não há carros para remover.");
            return;
        }

        listarCarros(placas, qtdInseridos);
        Console.Write("Informe o número do carro para remover: ");
        int escolha = int.Parse(Console.ReadLine()!);

        if (escolha < 1 || escolha > qtdInseridos)
        {
            Console.WriteLine("Número inválido.");
            return;
        }

        for (int i = escolha - 1; i < qtdInseridos - 1; i++)
            placas[i] = placas[i + 1];

        qtdInseridos--;
        Console.WriteLine("Carro removido.");
    }

    public static void substituirPlaca(string[] placas, int qtdInseridos)
    {
        if (qtdInseridos == 0)
        {
            Console.WriteLine("Garagem vazia.");
            return;
        }
        listarCarros(placas, qtdInseridos);
        Console.Write("Qual carro deseja substituir a placa? ");
        int escolha = int.Parse(Console.ReadLine()!);

        Console.Write("Digite a nova placa: ");
        string nova = Console.ReadLine()!.ToUpper();

        placas[escolha - 1] = nova;
        Console.WriteLine("Placa substituída com sucesso.");
    }
}
