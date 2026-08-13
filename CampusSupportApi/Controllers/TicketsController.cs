// Imports MVC features such as ApiController,
// Route, HttpGet, HttpPost and ControllerBase.
using Microsoft.AspNetCore.Mvc;


// Imports the Ticket model that we created.
using CampusSupportApi.Models;


// Places this controller inside the Controllers namespace.
namespace CampusSupportApi.Controllers
{
    // Tells ASP.NET Core that this class is a Web API controller.
    [ApiController]


    // Defines the URL used to access this controller.
    //
    // [controller] automatically uses the controller name
    // without the word "Controller".
    //
    // TicketsController therefore becomes:
    //
    // api/tickets
    [Route("api/[controller]")]


    // Declares the TicketsController.
    //
    // API controllers normally inherit from ControllerBase
    // because they return data rather than Views.
    public class TicketsController : ControllerBase
    {
        // Creates a temporary list that stores our tickets.
        //
        // static is used so that the same list remains available
        // while the application is running.
        private static readonly List<Ticket> tickets = new List<Ticket>
        {
            // Creates the first sample ticket.
            new Ticket
            {
                Id = 1,
                StudentName = "Lwazi Mthembu",
                ModuleCode = "PROG6221",
                Issue = "Cannot access ARC",
                Status = "Open"
            },


            // Creates the second sample ticket.
            new Ticket
            {
                Id = 2,
                StudentName = "Nomsa Dlamini",
                ModuleCode = "PROG6112",
                Issue = "Visual Studio installation problem",
                Status = "Resolved"
            },


            // Creates the third sample ticket.
            new Ticket
            {
                Id = 3,
                StudentName = "Sipho Ndlovu",
                ModuleCode = "PROG6221",
                Issue = "Unable to locate assessment instructions",
                Status = "Open"
            }
        };


        // Stores the number that will be assigned
        // to the next ticket that is created.
        private static int nextId = 4;


        // ----------------------------------------------------
        // GET ALL TICKETS
        // ----------------------------------------------------


        // Specifies that this action responds to HTTP GET.
        //
        // Because no additional route is supplied,
        // the URL is:
        //
        // GET api/tickets
        [HttpGet]


        // Declares an action that returns a collection of Ticket objects.
        public ActionResult<IEnumerable<Ticket>> GetAllTickets()
        {
            // Returns HTTP status 200 OK
            // together with the entire ticket list.
            return Ok(tickets);
        }


        // ----------------------------------------------------
        // GET ONE TICKET
        // ----------------------------------------------------


        // Specifies another HTTP GET request.
        //
        // {id:int} means that an integer ID must appear
        // inside the URL.
        //
        // Example:
        //
        // GET api/tickets/2
        [HttpGet("{id:int}")]


        // Receives the ID from the URL.
        public ActionResult<Ticket> GetTicketById(int id)
        {
            // Searches the list for the first ticket
            // whose Id matches the Id received in the URL.
            Ticket? ticket = tickets.FirstOrDefault(
                ticket => ticket.Id == id
            );


            // Checks whether the ticket was found.
            if (ticket == null)
            {
                // Returns HTTP 404 Not Found
                // when no ticket has the supplied ID.
                return NotFound(
                    $"Ticket with ID {id} was not found."
                );
            }


            // Returns HTTP 200 OK
            // together with the matching ticket.
            return Ok(ticket);
        }


        // ----------------------------------------------------
        // GET TICKETS BY STATUS
        // ----------------------------------------------------


        // Creates another GET endpoint.
        //
        // Example:
        //
        // GET api/tickets/status/Open
        //
        // GET api/tickets/status/Resolved
        [HttpGet("status/{status}")]


        // Receives the status value from the URL.
        public ActionResult<IEnumerable<Ticket>> GetTicketsByStatus(
            string status
        )
        {
            // Filters the ticket list.
            //
            // StringComparison.OrdinalIgnoreCase means that
            // Open, open and OPEN are treated the same.
            List<Ticket> matchingTickets = tickets
                .Where(ticket =>
                    ticket.Status.Equals(
                        status,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                .ToList();


            // Checks whether any matching tickets were found.
            if (matchingTickets.Count == 0)
            {
                // Returns 404 when no tickets have that status.
                return NotFound(
                    $"No tickets with status '{status}' were found."
                );
            }


            // Returns HTTP 200 and the filtered tickets.
            return Ok(matchingTickets);
        }


        // ----------------------------------------------------
        // POST: CREATE A TICKET
        // ----------------------------------------------------


        // Specifies that this action responds to HTTP POST.
        //
        // The URL is:
        //
        // POST api/tickets
        [HttpPost]


        // ASP.NET Core converts the JSON sent by the client
        // into a Ticket object and places it in this parameter.
        public ActionResult<Ticket> CreateTicket(Ticket ticket)
        {
            // Assigns the next available ticket number.
            ticket.Id = nextId;


            // Increases nextId so that the following
            // ticket gets a different number.
            nextId++;


            // Makes sure that every new ticket starts as Open.
            ticket.Status = "Open";


            // Adds the new ticket to our temporary list.
            tickets.Add(ticket);


            // Returns HTTP 201 Created.
            //
            // CreatedAtAction also provides the address
            // where the newly created ticket can be retrieved.
            return CreatedAtAction(
                nameof(GetTicketById),
                new { id = ticket.Id },
                ticket
            );
        }


        // ----------------------------------------------------
        // PUT: UPDATE A TICKET
        // ----------------------------------------------------


        // Specifies that this action responds to HTTP PUT.
        //
        // Example:
        //
        // PUT api/tickets/1
        [HttpPut("{id:int}")]


        // Receives:
        //
        // id            from the URL
        // updatedTicket from the JSON request body
        public IActionResult UpdateTicket(
            int id,
            Ticket updatedTicket
        )
        {
            // Searches for the ticket that must be updated.
            Ticket? existingTicket = tickets.FirstOrDefault(
                ticket => ticket.Id == id
            );


            // Checks whether the requested ticket exists.
            if (existingTicket == null)
            {
                // Returns HTTP 404 when the ticket is not found.
                return NotFound(
                    $"Ticket with ID {id} was not found."
                );
            }


            // Updates the student's name.
            existingTicket.StudentName =
                updatedTicket.StudentName;


            // Updates the module code.
            existingTicket.ModuleCode =
                updatedTicket.ModuleCode;


            // Updates the support issue.
            existingTicket.Issue =
                updatedTicket.Issue;


            // Updates the ticket status.
            existingTicket.Status =
                updatedTicket.Status;


            // Returns HTTP 204 No Content.
            //
            // This tells the client that the update succeeded,
            // but no response body needs to be returned.
            return NoContent();
        }


        // ----------------------------------------------------
        // DELETE A TICKET
        // ----------------------------------------------------


        // Specifies that this action responds to HTTP DELETE.
        //
        // Example:
        //
        // DELETE api/tickets/2
        [HttpDelete("{id:int}")]


        // Receives the ticket ID from the URL.
        public IActionResult DeleteTicket(int id)
        {
            // Searches for the ticket to delete.
            Ticket? ticket = tickets.FirstOrDefault(
                ticket => ticket.Id == id
            );


            // Checks whether the ticket exists.
            if (ticket == null)
            {
                // Returns HTTP 404 when it cannot be found.
                return NotFound(
                    $"Ticket with ID {id} was not found."
                );
            }


            // Removes the ticket from the list.
            tickets.Remove(ticket);


            // Returns HTTP 204 because the deletion succeeded.
            return NoContent();
        }
    }
}