// Imports validation attributes such as Required.
using System.ComponentModel.DataAnnotations;

// Places the Ticket class inside the Models namespace.
namespace CampusSupportApi.Models
{
    // Declares a public class called Ticket.
    // Each Ticket object represents one support ticket.
    public class Ticket
    {
        // Stores the unique number used to identify the ticket.
        public int Id { get; set; }


        // Specifies that the student's name must be provided.
        [Required]

        // Stores the name of the student who created the ticket.
        public string StudentName { get; set; } = "";


        // Specifies that a module code must be provided.
        [Required]

        // Stores the module related to the support request.
        public string ModuleCode { get; set; } = "";


        // Specifies that the support issue cannot be empty.
        [Required]

        // Stores the problem described by the student.
        public string Issue { get; set; } = "";


        // Stores the current status of the ticket.
        // Every new ticket starts as Open.
        public string Status { get; set; } = "Open";
    }
}