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
                LastName = "Schilström",
                Email = "Linnea@hotmail.com",
                Personnummer = "19950112"
            };

            // Del 2 Act
            //Andropa någon slagt booknings request
            //Book = klass
            TicketBookingResponse response = _processor.Book(request);

            //Del 3 Assert
            //Kolla samma egenskaper med equal
            Assert.NotNull(response); //tillåter inte null värde
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
            //Act kommer retrunera om man skickar in objektet som är null - retrunerar argument
            var exeption = Assert.Throws<ArgumentNullException>(() => _processor.Book(null));

            //Assert
            Assert.Equal("request", exeption.ParamName);
            //Kontrolerar med parameter request

        }
        //kör test resulterar i error eftersom book metod är tom
        //Lägg till mer kod inför nästa test

    }
}

//Referarar till TicketBookingCore projekt
//justerar tester så de klarar drive kraven?
