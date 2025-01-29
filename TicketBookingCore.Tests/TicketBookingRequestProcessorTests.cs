namespace TicketBookingCore.Tests
{
    public class TicketBookingRequestProcessorTests
    {
        private readonly TicketBookingRequestProcessor _processor;
        public TicketBookingRequestProcessorTests()
        {
            _processor = new TicketBookingRequestProcessor();
        }
        [Fact]
        public void ShouldReturnTicketBookingResultWithRequestValues()
        {
            //Arrange del i unit test
           
            var request = new TicketBookingRequest
            {
                FirstName = "Linnea",
                LastName = "Schilstr�m",
                Email = "Linnea@hotmail.com",
                Personnummer = "19950112"
            };

            // Del 2 Act
            //Andropa n�gon slagt booknings request
            //Book = klass
            TicketBookingResponse response = _processor.Book(request);

            //Del 3 Assert
            //Kolla samma egenskaper med equal
            Assert.NotNull(response); //till�ter inte null v�rde
            //Kolla egenskaper
            Assert.Equal(request.FirstName, response.FirstName);
            Assert.Equal(request.LastName, response.LastName);
            Assert.Equal(request.Email, response.Email);
            Assert.Equal(request.Personnummer, response.Personnummer);

           
        }
        [Fact]

        public void ShouldThrowExceptionWhenRequestIsNull()
        {
            //Arrange Hanterar
            var processor = new TicketBookingRequestProcessor();
            //Act kommer retrunera om man skickar in objektet som �r null - retrunerar argument
            var exeption = Assert.Throws<ArgumentNullException>(() => _processor.Book(null));

            //Assert
            Assert.Equal("request", exeption.ParamName);
            //Kontrolerar med parameter request

        }
        //k�r test resulterar i error eftersom book metod �r tom
        //L�gg till mer kod inf�r n�sta test

    }
}

//Referarar till TicketBookingCore projekt
//justerar tester s� de klarar drive kraven?
