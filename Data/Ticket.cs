
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata;

namespace nctutorial.Data
{
    
    public class Ticket
    {
 
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
    }
}
