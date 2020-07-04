using System.Collections.Generic;
using TestTask.Domain.Entities;

namespace TestTask.Domain.Abstract
{
    /// <summary>
    /// Interface for region repository
    /// </summary>
    public interface IRegionRepository
    {
        /// <summary>
        /// Retrieves a list of regions
        /// </summary>
        /// <returns> List of regions </returns>
        List<Region> GetRegions();
        /// <summary>
        /// Gets the region by its identifier
        /// </summary>
        /// <param name="regionId"> Id of the desired region </param>
        /// <returns> Searched region </returns>   
        Region GetRegionById(int regionId);
        /// <summary>
        /// Gets the region by its name
        /// </summary>
        /// <param name="regionName"> Name of the desired region </param>
        /// <returns> Searched region </returns>    
        Region GetRegionByName(string regionName);
        /// <summary>
        /// Adds a region
        /// </summary>
        /// <param name="region"> Region to add </param>
        void AddRegion(Region region);
        /// <summary>
        /// Checks for the presence of a region
        /// </summary>
        /// <param name="regionName"> Region name to check </param>
        /// <returns> "EXIST" - if the region exists and "NOT EXIST" otherwise </returns>
        string CheckExistRegion(string regionName);
    }
}
