
using Dapper.Contrib.Extensions;

namespace RandomPersonPicker.Domain.Models
{
    [Table("Person")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
    }
}
