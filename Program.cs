// Screen Sound

//List<string> bandas = new List<string> { "U2", "The Black Eyed Peas", "Taylor Swift", "Bruno Mars"};

using System.Collections.Generic;

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>()
        {
            { "U2", new List<int>() { 10, 5, 8, 9, 7 } },
            { "The Black Eyed Peas", new List<int>(){ 6, 7, 4, 5, 7 } },
            { "Taylor Swift", new List<int>(){ 4, 3, 1, 3, 10 } },
            { "Bruno Mars", new List<int>(){ 10, 10, 10, 10, 10 } }
        };

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
}

void ExibirOpçõesMenu()
{
    ExibirLogo();

    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 mostrar media de avaliações de uma banda");
    Console.WriteLine("Digite 5 para sair");

    Console.Write("\nDigite sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandas();
            break;
        case 3:
            AvaliarBanda();
            break;
        case 4:
            MostrarMediaDeUmaBunda();
            break;
        case 5:
            Console.WriteLine("Você selecionou a opção: " + opcaoEscolhidaNumerica);
            break;
        default: Console.WriteLine("Opção inválida"); break;
    }

}

ExibirOpçõesMenu();

void ExibirTitulos(string titulo)
{
    int charactNumber = titulo.Length;
    string astericos = string.Empty.PadLeft(charactNumber, '*');

    Console.WriteLine(astericos);
    Console.WriteLine(titulo);
    Console.WriteLine(astericos + "\n");
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTitulos("Registro de banda");

    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi cadastrada com sucesso!");
    Thread.Sleep(1000);
    Console.Clear();
    ExibirOpçõesMenu();
}

void MostrarBandas()
{
    Console.Clear();
    ExibirTitulos("Bandas Registradas");

    //for (int i = 0; i < bandas.Count; i++)
    //{
    //    Console.WriteLine();
    //    Console.WriteLine($"{i+1}° - {bandas[i].ToString()}");
    //}

    int contador = 1;
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine();
        Console.WriteLine($"{contador}° - {banda}");
        contador++;
    }

    Console.WriteLine();
    Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirOpçõesMenu();
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTitulos("Avaliação de bandas");

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda)){
        Console.Write($"Qual nota você gostaria de dar para a banda {nomeDaBanda}? ");
        int nota = int.Parse(Console.ReadLine()!);

        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine("\nNota da banda registrada com sucesso");

        Console.WriteLine("\nDigite uma tecla para retornar ao menu principal");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine($"O nome {nomeDaBanda} não corresponde a nenhuma banda cadastrada.");
        Console.WriteLine("\nDigite qualquer tecla para retornar ao menu principal");
        Console.ReadKey();
    }

    Console.Clear();
    ExibirOpçõesMenu();
}

void MostrarMediaDeUmaBunda()
{
    Console.Clear();
    ExibirTitulos("Média de uma banda");

    Console.Write("Digite o nome da banda que deseja visualizar a média: ");
    string banda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(banda)){
        double media = CalcularMedia(banda);

        Console.WriteLine($"\nA nota média da banda {banda} é: {media}");

        Console.WriteLine("\nAperte qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("\nBanda não encontrada");
        Console.WriteLine("\nAperte qualquer tecla para retornar ao menu");
        Console.ReadKey();
    }
}

double CalcularMedia(string nomeBanda)
{
    List<int>bandas = bandasRegistradas[nomeBanda];
    int contador = 0;

    foreach(int banda in bandas){
        contador += banda;
    }

    return contador / bandas.Count();
}
