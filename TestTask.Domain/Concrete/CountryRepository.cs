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
    /// Country repository implementing the corresponding interface
    /// </summary>
    public class CountryRepository : ICountryRepository
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        private readonly string _connectionString = null;
        /// <summary>
        /// Constructor for the country repository
        /// </summary>
        /// <param name="conn"> Database connection string </param>
        public CountryRepository(string conn) => _connectionString = conn;
        /// <summary>
        /// Retrieves a list of countries from the database
        /// </summary>
        /// <returns>
        /// In the case when the method functions normally, returns a list of countries from database.
        /// Otherwise, it displays a debug message and returns null.
        /// </returns>
        public List<Country> GetCountries()
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                return db.Query<Country>("SELECT * FROM Countries").ToList();
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("Country", "GetCountries", ex);
                return null;
            }
        }
        /// <summary>
        /// Gets the country from the database by its name
        /// </summary>
        /// <param name="countryName"> Name of the desired region  </param>
        /// <returns>
        /// In the case when the method functions normally, returns searched country from database.
        /// Otherwise, it displays a debug message and returns null.
        /// </returns>
        public Country GetCountryByName(string countryName)
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                return db.Query<Country>($"SELECT * FROM Countries WHERE Name = \'{countryName}\'").SingleOrDefault();
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("Country", "GetCountryByName", ex);
                return null;
            }
        }
        /// <summary>
        /// Adds a country to the database
        /// </summary>
        /// <param name="country"> Country to add </param>
        /// <param name="capitalName"> Capital of this country  </param>
        /// <param name="regionName">
        /// Region in which this country is located.
        /// When an exception occurs, it displays a debug message.
        /// </param>
        public void AddCountry(Country country, string capitalName, string regionName)
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                var capital = db.Query<City>($"SELECT * FROM Cities WHERE Name = \'{capitalName}\'").SingleOrDefault();
                var region = db.Query<Region>($"SELECT * FROM Regions WHERE Name = \'{regionName}\'").SingleOrDefault();
                var sqlQuery = "INSERT INTO Countries (Name, CountryCode, CapitalId, Area, Population, RegionId) VALUES" +
                    $" (@Name, @CountryCode, {capital.Id}, @Area, @Population, {region.Id});";
                db.Execute(sqlQuery, country);
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("Country", "AddCountry", ex);
            }
        }
        /// <summary>
        /// Updates country data in the database
        /// </summary>
        /// <param name="country"> Country to update </param>
        /// <param name="capitalName"> Capital of this country </param>
        /// <param name="regionName">
        /// Region in which this country is located.
        /// When an exception occurs, it displays a debug message.
        /// </param>
        public void UpdateCountry(Country country, string capitalName, string regionName)
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                var capital = db.Query<City>($"SELECT * FROM Cities WHERE Name = \'{capitalName}\'").SingleOrDefault();
                var region = db.Query<Region>($"SELECT * FROM Regions WHERE Name = \'{regionName}\'").SingleOrDefault();
                var sqlQuery = $"UPDATE Countries set Name = \'{country.Name}\', CapitalId = {capital.Id}, Area = {country.Area}," +
                    $"Population = {country.Population}, RegionId = {region.Id}" +
                    $"WHERE CountryCode = \'{country.CountryCode}\'";
                db.Execute(sqlQuery, country);
            }           
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("Country", "UpdateCountry", ex);
            }
        }
        /// <summary>
        /// Checks for the presence of a country in the database
        /// </summary>
        /// <param name="countryCode"> Country code to check </param>
        /// <returns>
        /// In the case when the method functions normally, returns 
        /// "EXIST" - if the country code exists in the database and "NOT EXIST" otherwise.
        /// When an exception occurs, it displays a debug message and returns null.
        /// </returns>
        public string CheckExistCountry(string countryCode)
        {
            try
            {
                var sqlQuery = $"SELECT CASE WHEN EXISTS(SELECT TOP 1 1 FROM Countries" +
                $" WHERE CountryCode = \'{countryCode}\') THEN 'EXIST' ELSE 'NOT EXIST' END;";
                using var db = new SqlConnection(_connectionString);
                return db.Query<string>(sqlQuery).FirstOrDefault();
            }         
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("Country", "CheckExistCountry", ex);
                return null;
            }
        }
    }
}
