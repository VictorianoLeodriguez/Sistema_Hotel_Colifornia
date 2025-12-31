// See https://aka.ms/new-console-template for more information
string options;

while (true)
{
    Console.WriteLine("╔════════════════════════════╗");
    Console.WriteLine("╔  Sistema Hotel California  ╗");
    Console.WriteLine("╠════════════════════════════╣");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();

 options = Console.ReadLine();

    Console.Clear();

    if (string.IsNullOrWhiteSpace(options))
    {
        Console.WriteLine("Opção inválida.");
        Console.ReadKey();
        continue;
    }

}