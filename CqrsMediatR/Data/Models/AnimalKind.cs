using System.ComponentModel.DataAnnotations;

namespace CqrsMediatR.Data
{
    public class AnimalKind : IHasKeyEntry<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
