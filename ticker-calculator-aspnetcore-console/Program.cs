using ticker_calculator_aspnetcore_console.Models;
using ticker_calculator_aspnetcore_console.Services;

namespace ticker_calculator_aspnetcore_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new TicketService();

            Console.WriteLine("Digite a idade:");
            int age = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite a quantidade de bilhetes:");
            int quantity = int.Parse(Console.ReadLine()!);

            var request = new TicketRequest { Age = age, Quantity = quantity };

            try
            {
                var total = service.CalculateTotalPrice(request);
                Console.WriteLine($"Preço total: R$ {total}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
