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
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please, enter country name.")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z-()\s]*$",
            ErrorMessage = "Please enter a valid country name.")]
        public string Name { get; set; }

        [Display(Name = "Country code")]
        [Required(ErrorMessage = "Please, enter country code.")]
        [RegularExpression(@"^[A-Z]{1,3}$",
            ErrorMessage = "Please enter a valid country code.")]
        public string CountryCode { get; set; }

        [Display(Name = "Area")]
        [Required(ErrorMessage = "Please, enter area.")]
        [RegularExpression(@"^([0-9]*[1-9][0-9]*(\.[0-9]+)?|[0]+\.[0-9]*[1-9][0-9]*)$",
            ErrorMessage = "Please, enter a positive value for the area.")]
        public double Area { get; set; }

        [Display(Name = "Population")]
        [Required(ErrorMessage = "Please, enter population.")]
        [RegularExpression(@"^[1-9]\d*$",
            ErrorMessage = "Please, enter a positive integer value for the population.")]
        public int Population { get; set; }

        [ForeignKey("City")]
        public int CapitalId { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }
    }
}
