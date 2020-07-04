using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TestTask.Domain.Entities;
using TestTask.Domain.Abstract;
using TestTask.Domain.ExceptionHandlers;
using Dapper;

namespace TestTask.Domain.Concrete
{
    /// <summary>
    /// City repository implementing the corresponding interface
    /// </summary>
    public class CityRepository : ICityRepository
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        private readonly string _connectionString = null;
        /// <summary>
        /// Constructor for the city repository
        /// </summary>
        /// <param name="conn"> Database connection string </param> 
        public CityRepository(string conn) => _connectionString = conn;
        /// <summary>
        /// Retrieves a list of cities from the database
        /// </summary>
        /// <returns>
        /// In the case when the method functions normally, returns a list of cities from database.
        /// Otherwise, it displays a debug message and returns null.
        /// </returns>
        public List<City> GetCities()
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                return db.Query<City>("SELECT * FROM Cities").ToList();
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("City", "GetCities", ex);
                return null;
            }
        }
        /// <summary>
        /// Gets the city from the database by its identifier
        /// </summary>
        /// <param name="cityId"> Id of the desired city </param>      
        /// <returns>
        /// In the case when the method functions normally, returns searched city from database.
        /// Otherwise, it displays a debug message and returns null.
        /// </returns>
        public City GetCityById(int cityId)
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                return db.Query<City>($"SELECT * FROM Cities WHERE Id = {cityId}").SingleOrDefault();
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("City", "GetCityById", ex);
                return null;
            }
        }
        /// <summary>
        /// Gets the city from the database by its name
        /// </summary>
        /// <param name="cityName"> Name of the desired city </param>       
        /// <returns>
        /// In the case when the method functions normally, returns searched city from database.
        /// Otherwise, it displays a debug message and returns null.
        /// </returns>
        public City GetCityByName(string cityName)
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                return db.Query<City>($"SELECT * FROM Cities WHERE Name = \'{cityName}\'").SingleOrDefault();
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("City", "GetCityByName", ex);
                return null;
            }
        }
        /// <summary>
        /// Adds a city to the database
        /// </summary>
        /// <param name="city"> City to add </param> 
        public void AddCity(City city)
        {
            try
            {
                var sqlQuery = "INSERT INTO Cities (Name) VALUES (@Name);";
                using var db = new SqlConnection(_connectionString);
                db.Execute(sqlQuery, city);
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("City", "AddCity", ex);
            }
        }
        /// <summary>
        /// Checks for the presence of a city in the database
        /// </summary>
        /// <param name="cityName"> City name to check </param>
        /// <returns>
        /// In the case when the method functions normally, returns 
        /// "EXIST" - if the city exists in the database and "NOT EXIST" otherwise.
        /// When an exception occurs, it displays a debug message and returns null.
        /// </returns>
        public string CheckExistCity(string cityName)
        {
            try
            {
                var sqlQuery = $"SELECT CASE WHEN EXISTS(SELECT TOP 1 1 FROM Cities" +
                $" WHERE Name = \'{cityName}\') THEN 'EXIST' ELSE 'NOT EXIST' END;";
                using var db = new SqlConnection(_connectionString);
                return db.Query<string>(sqlQuery).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("City", "CheckExistCity", ex);
                return null;
            }
        }
    }
}
