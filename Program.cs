using Sistema_Hotel_Colifornia.Models;

List<Pessoa> clientes = new();
List<Suite> suites = new();
List<Reserva> reservas = new();

string option;

while (true)
{
    Console.WriteLine("╔════════════════════════════╗");
    Console.WriteLine("║  Sistema Hotel California  ║");
    Console.WriteLine("╠════════════════════════════╣");
    Console.WriteLine("║ 1 - Cadastrar Cliente      ║");
    Console.WriteLine("║ 2 - Cadastrar Suíte        ║");
    Console.WriteLine("║ 3 - Criar Reserva          ║");
    Console.WriteLine("║ 5 - Listar Clientes        ║");
    Console.WriteLine("║ 6 - Listar Suítes          ║");
    Console.WriteLine("║ 0 - Sair                   ║");
    Console.WriteLine("╚════════════════════════════╝");

 option = Console.ReadLine();

if (string.IsNullOrWhiteSpace(option))
    {
        Console.WriteLine("Opção inválida.");
        Console.ReadKey();
        continue;
    }


    switch (option)
    {
        case "1":
            Console.Write("Nome completo: ");
            string nome = Console.ReadLine();

            Console.Write("Celular: ");
            string celular = Console.ReadLine();

            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            clientes.Add(new Pessoa(nome, celular, cpf));

            Console.WriteLine("Cliente cadastrado.");
            Console.ReadKey();
            break;

        case "2":
            Console.Write("Tipo da suíte: ");
            string tipo = Console.ReadLine();

            Console.Write("Capacidade: ");
            int capacidade = int.Parse(Console.ReadLine());

            Console.Write("Valor da diária: ");
            decimal valor = decimal.Parse(Console.ReadLine());

            suites.Add(new Suite(tipo, capacidade, valor));

            Console.WriteLine("Suíte cadastrada.");
            Console.ReadKey();
            break;
        case "3":
            if (clientes.Count == 0 || suites.Count == 0)
            {
                Console.WriteLine("Cadastre clientes e suítes antes.");
                Console.ReadKey();
                break;
            }

            Console.Write("Dias da reserva: ");
            int dias = int.Parse(Console.ReadLine());

            Reserva reserva = new Reserva(dias);

            reserva.CadastrarSuite(suites[0]);

            reserva.CadastrarHospedes(new List<Pessoa> { clientes[0] });

            decimal valorTotal = reserva.CalcularValorDiaria();

            reservas.Add(reserva);

            Console.WriteLine($"Reserva criada com sucesso!");
            Console.WriteLine($"Total de hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor total da reserva: R$ {valorTotal:F2}");

            Console.ReadKey();
            break;

        case "5":
            foreach (var cli in clientes)
                Console.WriteLine(cli.NomeCompleto);

            Console.ReadKey();
            break;

        case "6":
            foreach (var suite in suites)
                Console.WriteLine($"{suite.TipoSuite} - R$ {suite.ValorDiaria}");

            Console.ReadKey();
            break;

        case "0":
            return;
    }
}
