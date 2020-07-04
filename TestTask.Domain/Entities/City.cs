using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Domain.Entities
{
    /// <summary>
    /// City entity
    /// </summary>
    [Table("Cities")]
    public class City
    {
        /// <summary>
        /// City identificator
        /// </summary>
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// City name
        /// </summary>
        [Display(Name = "City")]
        [Required(ErrorMessage = "Please, enter city name.")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z-()\s]*$",
            ErrorMessage = "Please enter a valid city name.")]
        public string Name { get; set; }
    }
}
