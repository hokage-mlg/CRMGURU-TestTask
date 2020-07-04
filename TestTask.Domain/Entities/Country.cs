using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.Domain.Entities
{
    /// <summary>
    /// Country entity
    /// </summary>
    [Table("Countries")]
    public class Country
    {
        /// <summary>
        /// Country identificator
        /// </summary>
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Country name
        /// </summary>
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please, enter country name.")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z-()\s]*$",
            ErrorMessage = "Please enter a valid country name.")]
        public string Name { get; set; }

        /// <summary>
        /// Country code
        /// </summary>
        [Display(Name = "Country code")]
        [Required(ErrorMessage = "Please, enter country code.")]
        [RegularExpression(@"^[A-Z]{1,3}$",
            ErrorMessage = "Please enter a valid country code.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Country area
        /// </summary>
        [Display(Name = "Area")]
        [Required(ErrorMessage = "Please, enter area.")]
        [RegularExpression(@"^([0-9]*[1-9][0-9]*(\.[0-9]+)?|[0]+\.[0-9]*[1-9][0-9]*)$",
            ErrorMessage = "Please, enter a positive value for the area.")]
        public double Area { get; set; }

        /// <summary>
        /// Country population
        /// </summary>
        [Display(Name = "Population")]
        [Required(ErrorMessage = "Please, enter population.")]
        [RegularExpression(@"^[1-9]\d*$",
            ErrorMessage = "Please, enter a positive integer value for the population.")]
        public int Population { get; set; }

        /// <summary>
        /// Capital identificator, primary key in Cities table
        /// </summary>
        [ForeignKey("City")]
        public int CapitalId { get; set; }

        /// <summary>
        /// Region identificator, primary key in Regions table
        /// </summary>
        [ForeignKey("Region")]
        public int RegionId { get; set; }
    }
}
