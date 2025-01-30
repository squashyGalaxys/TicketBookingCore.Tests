using Moq;

namespace TicketBookingCore.Tests
{
    public class TicketBookingRequestProcessorTests
    {
        private readonly Mock<ITicketBookingRepository> _ticketBookingRepositoryMock;
        private readonly TicketBookingRequestProcessor _processor;
        private readonly TicketBookingRequest _request;
        
        public TicketBookingRequestProcessorTests()
        {
            _ticketBookingRepositoryMock = new Mock<ITicketBookingRepository>();
            _processor = new TicketBookingRequestProcessor(_ticketBookingRepositoryMock.Object);
            _request = new TicketBookingRequest
            {
            FirstName = "Joakim",
            LastName = "Banan",
            Email  = "test@test.com"

            };
        }

        [Fact]
        public void ShouldReturnTicketBookningResultWithRequestValues()
        {
           
            // Act
            TicketBookingResponse response = _processor.Book(_request);
            // Assert
            Assert.NotNull(response);
            Assert.Equal(response.FirstName, _request.FirstName);
            Assert.Equal(response.LastName, _request.LastName);
            Assert.Equal(response.Email, _request.Email);
        }
        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.Book(null));

            //Assert
            Assert.Equal("request", exception.ParamName);
        }

        /// <summary>
        /// This test will fail because the method is not implemented yet.
        /// </summary>
        [Fact]
        public void ShouldSaveToDatabase()
        {
            // Arrange
            TicketBooking savedTicketBooking = null;

            // Setup the Save method to capture the saved ticket booking
            _ticketBookingRepositoryMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
            .Callback<TicketBooking>((ticketBooking) =>
            {
                savedTicketBooking = ticketBooking;
            });

            // Act 
            _processor.Book(_request);
            /// Verify that the Save method was called once 
            _ticketBookingRepositoryMock.Verify(x => x.Save(It.IsAny<TicketBooking>()),
        Times.Once);
            
            // Assert
            Assert.NotNull(savedTicketBooking);
            Assert.Equal(_request.FirstName, savedTicketBooking.FirstName);
            Assert.Equal(_request.LastName, savedTicketBooking.LastName);
            Assert.Equal(_request.Email, savedTicketBooking.Email);
        }
    }
}