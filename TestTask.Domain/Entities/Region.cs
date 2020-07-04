using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Domain.Entities
{
    /// <summary>
    /// Region entity
    /// </summary>
    [Table("Regions")]
    public class Region
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Region")]
        [Required(ErrorMessage = "Please, enter region name.")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z-()\s]*$",
            ErrorMessage = "Please enter a valid region name.")]
        public string Name { get; set; }
    }
}
