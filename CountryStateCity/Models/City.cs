
using System.ComponentModel.DataAnnotations.Schema;
using CountryStateCity.Controllers;

namespace WebApplication1.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public State? State { get; set; }
    }
}
