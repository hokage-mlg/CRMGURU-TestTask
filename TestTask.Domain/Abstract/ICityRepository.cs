using System.Collections.Generic;
using TestTask.Domain.Entities;

namespace TestTask.Domain.Abstract
{
    /// <summary>
    /// Interface for city repository
    /// </summary>
    public interface ICityRepository
    {
        /// <summary>
        /// Retrieves a list of cities
        /// </summary>
        /// <returns> List of cities </returns>       
        List<City> GetCities();
        /// <summary>
        /// Gets the city by its identifier
        /// </summary>
        /// <param name="cityId"> Id of the desired city </param>
        /// <returns> Searched city </returns>           
        City GetCityById(int cityId);
        /// <summary>
        /// Gets the city by its name
        /// </summary>
        /// <param name="cityName"> Name of the desired city </param>
        /// <returns> Searched city </returns>    
        City GetCityByName(string cityName);
        /// <summary>
        /// Adds a city
        /// </summary>
        /// <param name="city"> City to add </param> 
        void AddCity(City city);
        /// <summary>
        /// Checks for the presence of a city
        /// </summary>
        /// <param name="cityName"> City name to check </param>
        /// <returns> "EXIST" - if the city exists and "NOT EXIST" otherwise </returns>
        string CheckExistCity(string cityName);
    }
}
