using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CqrsMediatR.Data
{
    public class Animal : IHasKeyEntry<int>
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimalKindId { get; set; }        
    }
}
