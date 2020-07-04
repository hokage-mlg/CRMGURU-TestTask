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
    /// Region repository implementing the corresponding interface
    /// </summary>
    public class RegionRepository : IRegionRepository
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        private readonly string _connectionString = null;
        /// <summary>
        /// Constructor for the region repository
        /// </summary>
        /// <param name="conn"> Database connection string </param>
        public RegionRepository(string conn) => _connectionString = conn;
        /// <summary>
        /// Retrieves a list of regions from the database
        /// </summary>
        /// <returns>
        /// In the case when the method functions normally, returns a list of regions from database.
        /// Otherwise, it displays a debug message and returns null.
        /// </returns>
        public List<Region> GetRegions()
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                return db.Query<Region>("SELECT * FROM Regions").ToList();
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("Region", "GetRegions", ex);
                return null;
            }
        }
        /// <summary>
        /// Gets the region from the database by its identifier
        /// </summary>
        /// <param name="regionId"> Id of the desired region </param>       
        /// <returns>
        /// In the case when the method functions normally, returns searched region from database.
        /// Otherwise, it displays a debug message and returns null.
        /// </returns>
        public Region GetRegionById(int regionId)
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                return db.Query<Region>($"SELECT * FROM Regions WHERE Id = {regionId}").SingleOrDefault();
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("Region", "GetRegionById", ex);
                return null;
            }
        }
        /// <summary>
        /// Gets the region from the database by its name
        /// </summary>
        /// <param name="regionName"> Name of the desired region </param>       
        /// <returns>
        /// In the case when the method functions normally, returns searched region from database.
        /// Otherwise, it displays a debug message and returns null.
        /// </returns>
        public Region GetRegionByName(string regionName)
        {
            try
            {
                using var db = new SqlConnection(_connectionString);
                return db.Query<Region>($"SELECT * FROM Regions WHERE Name = \'{regionName}\'").SingleOrDefault();
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("Region", "GetRegionByName", ex);
                return null;
            }
        }
        /// <summary>
        /// Adds a region to the database
        /// </summary>
        /// <param name="region"> Region to add </param>       
        public void AddRegion(Region region)
        {
            try
            {
                var sqlQuery = "INSERT INTO Regions (Name) VALUES (@Name);";
                using var db = new SqlConnection(_connectionString);
                db.Execute(sqlQuery, region);
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("Region", "AddRegion", ex);
            }
        }
        /// <summary>
        /// Checks for the presence of a region in the database
        /// </summary>
        /// <param name="regionName"> Region name to check </param>
        /// <returns>
        /// In the case when the method functions normally, returns 
        /// "EXIST" - if the region exists in the database and "NOT EXIST" otherwise.
        /// When an exception occurs, it displays a debug message and returns null.
        /// </returns>
        public string CheckExistRegion(string regionName)
        {
            try
            {
                var sqlQuery = $"SELECT CASE WHEN EXISTS(SELECT TOP 1 1 FROM Regions" +
                $" WHERE Name=\'{regionName}\') THEN 'EXIST' ELSE 'NOT EXIST' END;";
                using var db = new SqlConnection(_connectionString);
                return db.Query<string>(sqlQuery).FirstOrDefault();
            }
            catch (Exception ex)
            {
                DebugMessage.ShowMessage("Region", "AddRegion", ex);
                return null;
            }
        }
    }
}
