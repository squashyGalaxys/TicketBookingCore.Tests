
namespace TicketBookingCore
{
    public class TicketBookingRequestProcessor
    {
        public TicketBookingRequestProcessor()
        {
        }

        public TicketBookingResponse Book(TicketBookingRequest request)
        {
            //För att nytt test för null ska bli grönt (request ska vara samma som i test alltså request)
            if(request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            //Refactor för att retrunera en ny ticketbookingresponse
            return new TicketBookingResponse
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Personnummer = request.Personnummer,

                //testset blir grönt efter att ha lagt till ovan i book metoden
            };
        }
    }
}



