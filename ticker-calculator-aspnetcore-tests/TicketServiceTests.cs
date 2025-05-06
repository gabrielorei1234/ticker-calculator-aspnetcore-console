using ticker_calculator_aspnetcore_console.Models;
using ticker_calculator_aspnetcore_console.Services;

namespace ticker_calculator_aspnetcore_tests
{
    public class TicketServiceTests
    {
        private readonly TicketService _service = new TicketService();

        [Theory]
        [InlineData(5, 1, 10)]
        [InlineData(30, 2, 60)]
        [InlineData(65, 3, 45)]
        [InlineData(12, 1, 10)]
        [InlineData(13, 1, 30)]
        [InlineData(59, 1, 30)]
        [InlineData(60, 1, 15)]
        public void CalculateTotalPrice_ValidInputs_ReturnsCorrectTotal(int age, int quantity, decimal expectedTotal)
        {
            // Arrange
            var request = new TicketRequest { Age = age, Quantity = quantity };

            // Act
            var result = _service.CalculateTotalPrice(request);

            // Assert
            Assert.Equal(expectedTotal, result);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(30, 6)]
        [InlineData(60, -1)]
        public void CalculateTotalPrice_InvalidQuantities_ThrowsException(int age, int quantity)
        {
            // Arrange
            var request = new TicketRequest { Age = age, Quantity = quantity };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _service.CalculateTotalPrice(request));
        }

        [Fact]
        public void CalculateTotalPrice_NegativeAge_ThrowsException()
        {
            // Arrange
            var request = new TicketRequest { Age = -5, Quantity = 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _service.CalculateTotalPrice(request));
        }
    }
}
