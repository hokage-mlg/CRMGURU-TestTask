using System.Collections.Generic;
using TestTask.Domain.Entities;

namespace TestTask.Domain.Abstract
{
    /// <summary>
    /// Interface for country repository
    /// </summary>
    public interface ICountryRepository
    {
        /// <summary>
        /// Retrieves a list of countries
        /// </summary>
        /// <returns> List of countries </returns> 
        List<Country> GetCountries();
        /// <summary>
        /// Gets the country by its name
        /// </summary>
        /// <param name="countryName"> Name of the desired country </param>
        /// <returns> Searched country </returns>   
        Country GetCountryByName(string countryName);
        /// <summary>
        /// Adds a country
        /// </summary>
        /// <param name="country"> Country to add </param>
        /// <param name="capitalName"> Capital of this country </param>
        /// <param name="regionName"> Region in which this country is located </param>
        void AddCountry(Country country, string capitalName, string regionName);
        /// <summary>
        /// Updates country info
        /// </summary>
        /// <param name="country"> Country to update </param>
        /// <param name="capitalName"> Capital of this country </param>
        /// <param name="regionName"> Region in which this country is located  </param>
        void UpdateCountry(Country country, string capitalName, string regionName);
        /// <summary>
        /// Checks for the presence of a country
        /// </summary>
        /// <param name="countryCode"> Country name to check </param>
        /// <returns> "EXIST" - if the country exists and "NOT EXIST" otherwise </returns> 
        string CheckExistCountry(string countryCode);
    }
}
