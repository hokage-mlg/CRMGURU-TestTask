using System.ComponentModel.DataAnnotations;
using TestTask.Domain.Entities;

namespace TestTask.WebUI.Models
{
    /// <summary>
    /// View model for country.
    /// Necessary for the correct display of the country entity
    /// (replacing the identifiers of the capital and region with their names)
    /// </summary>
    public class CountryViewModel
    {
        /// <summary>
        /// Country entity
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Name of the capital of the country
        /// </summary>
        [Display(Name = "Capital")]
        [Required(ErrorMessage = "Please, enter capital name.")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z-()\s]*$",
                            ErrorMessage = "Please enter a valid capital name.")]
        public string CapitalName { get; set; }

        /// <summary>
        /// Name of the region of the country
        /// </summary>
        [Display(Name = "Region")]
        [Required(ErrorMessage = "Please, enter region name.")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z-()\s]*$",
                            ErrorMessage = "Please enter a valid region name.")]
        public string RegionName { get; set; }
    }
}
