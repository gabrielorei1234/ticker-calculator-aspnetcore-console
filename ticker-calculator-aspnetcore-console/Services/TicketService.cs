using ticker_calculator_aspnetcore_console.Enums;
using ticker_calculator_aspnetcore_console.Models;

namespace ticker_calculator_aspnetcore_console.Services
{
    public class TicketService
    {
        private const int MaxTicketsPerPerson = 5;

        public decimal CalculateTotalPrice(TicketRequest request)
        {
            if (request.Quantity < 1 || request.Quantity > MaxTicketsPerPerson)
                throw new ArgumentException("Quantidade inválida de bilhetes. Máximo permitido é 5.");

            var price = GetTicketPriceByAge(request.Age);
            return price * request.Quantity;
        }

        public decimal GetTicketPriceByAge(int age)
        {
            if (age <= 12)
                return (decimal)TicketPriceType.Child;
            else if (age >= 60)
                return (decimal)TicketPriceType.Senior;
            else
                return (decimal)TicketPriceType.Adult;
        }
    }
}
