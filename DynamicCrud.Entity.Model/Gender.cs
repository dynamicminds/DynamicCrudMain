using System.ComponentModel.DataAnnotations;

namespace DynamicCrud.Entity.Model
{
    /// <summary>
    /// A Class represents the Genders Model
    /// </summary>
    public class Genders
    {
        public int Id { get; set; }
        //[Required]
        public char Gender { get; set; }
        //[Required]
        public string? Description { get; set; }
    }
}
