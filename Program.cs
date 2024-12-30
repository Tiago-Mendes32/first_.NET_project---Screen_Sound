// Screen Sound

List<string> bandas = new List<string> { "U2", "The Black Eyed Peas", "Taylor Swift", "Bruno Mars"};
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
            Console.WriteLine("Você selecionou a opção: " + opcaoEscolhidaNumerica);
            break;
        case 4:
            Console.WriteLine("Você selecionou a opção: " + opcaoEscolhidaNumerica);
            break;
        case 5:
            Console.WriteLine("Você selecionou a opção: " + opcaoEscolhidaNumerica);
            break;
        default: Console.WriteLine("Opção inválida"); break;
    }

}

void RegistrarBanda()
{
    Console.Clear();
    Console.WriteLine("**********************");
    Console.WriteLine("Registro de banda");
    Console.WriteLine("**********************");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandas.Add(nomeDaBanda);
    Console.WriteLine($"A banda {nomeDaBanda} foi cadastrada com sucesso!");
    Thread.Sleep(1000);
    Console.Clear();
    ExibirOpçõesMenu();
}

void MostrarBandas()
{
    Console.Clear();
    Console.WriteLine("**********************");
    Console.WriteLine("Bandas Registradas");
    Console.WriteLine("**********************");

    //for (int i = 0; i < bandas.Count; i++)
    //{
    //    Console.WriteLine();
    //    Console.WriteLine($"{i+1}° - {bandas[i].ToString()}");
    //}

    foreach (string banda in bandas)
    {
        Console.WriteLine();
        Console.WriteLine($"{bandas.IndexOf(banda) + 1}° - {banda}");
    }

    Console.WriteLine();
    Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirOpçõesMenu();
}
ExibirOpçõesMenu();
