using System.Collections.Generic;

Dictionary<string, List<int>> registeredBands = new Dictionary<string, List<int>>()
{
    { "U2", new List<int>() { 10, 5, 8, 9, 7 } },
    { "The Black Eyed Peas", new List<int>(){ 6, 7, 4, 5, 7 } },
    { "Taylor Swift", new List<int>(){ 4, 3, 1, 3, 10 } },
    { "Bruno Mars", new List<int>(){ 10, 10, 10, 10, 10 } }
};

void DisplayLogo()
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

void DisplayMenuOptions()
{
    DisplayLogo();

    Console.WriteLine("\nEnter 1 to register a band");
    Console.WriteLine("Enter 2 to display all bands");
    Console.WriteLine("Enter 3 to rate a band");
    Console.WriteLine("Enter 4 to display a band's average rating");
    Console.WriteLine("Enter 5 to exit");

    Console.Write("\nEnter your choice: ");
    string chosenOption = Console.ReadLine()!;
    int numericOption = int.Parse(chosenOption);

    switch (numericOption)
    {
        case 1:
            RegisterBand();
            break;
        case 2:
            ShowBands();
            break;
        case 3:
            RateBand();
            break;
        case 4:
            ShowBandAverage();
            break;
        case 5:
            Console.WriteLine("You selected option: " + numericOption);
            break;
        default: Console.WriteLine("Invalid option"); break;
    }
}

DisplayMenuOptions();

void DisplayTitle(string title)
{
    string asterisks = new string('*', title.Length);

    Console.WriteLine(asterisks);
    Console.WriteLine(title);
    Console.WriteLine(asterisks + "\n");
}

void RegisterBand()
{
    Console.Clear();
    DisplayTitle("Band Registration");

    Console.Write("Enter the name of the band you want to register: ");
    string bandName = Console.ReadLine()!;
    registeredBands.Add(bandName, new List<int>());
    Console.WriteLine($"The band {bandName} has been successfully registered!");
    Thread.Sleep(1000);
    Console.Clear();
    DisplayMenuOptions();
}

void ShowBands()
{
    Console.Clear();
    DisplayTitle("Registered Bands");

    int counter = 1;
    foreach (string band in registeredBands.Keys)
    {
        Console.WriteLine($"{counter} - {band}");
        counter++;
    }

    Console.WriteLine("\nPress any key to return to the menu");
    Console.ReadKey();
    Console.Clear();
    DisplayMenuOptions();
}

void RateBand()
{
    Console.Clear();
    DisplayTitle("Band Rating");

    Console.Write("Enter the name of the band you want to rate: ");
    string bandName = Console.ReadLine()!;

    if (registeredBands.ContainsKey(bandName))
    {
        Console.Write($"What rating would you like to give the band {bandName}? ");
        int rating = int.Parse(Console.ReadLine()!);

        registeredBands[bandName].Add(rating);
        Console.WriteLine("\nRating successfully recorded");

        Console.WriteLine("\nPress any key to return to the main menu");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine($"The name {bandName} does not match any registered band.");
        Console.WriteLine("\nPress any key to return to the main menu");
        Console.ReadKey();
    }

    Console.Clear();
    DisplayMenuOptions();
}

void ShowBandAverage()
{
    Console.Clear();
    DisplayTitle("Band Average Rating");

    Console.Write("Enter the name of the band you want to see the average rating for: ");
    string bandName = Console.ReadLine()!;

    if (registeredBands.ContainsKey(bandName))
    {
        double average = CalculateAverage(bandName);

        Console.WriteLine($"\nThe average rating for the band {bandName} is: {average}");

        Console.WriteLine("\nPress any key to return to the menu");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("\nBand not found");
        Console.WriteLine("\nPress any key to return to the menu");
        Console.ReadKey();
    }
}

double CalculateAverage(string bandName)
{
    List<int> ratings = registeredBands[bandName];
    int total = 0;

    foreach (int rating in ratings)
    {
        total += rating;
    }

    return (double)total / ratings.Count;
}
