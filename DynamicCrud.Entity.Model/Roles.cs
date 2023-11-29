using System.ComponentModel.DataAnnotations;

namespace DynamicCrud.Entity.Model
{
    /// <summary>
    /// A class that represents the Roles model.
    /// </summary>
    public class Roles
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
