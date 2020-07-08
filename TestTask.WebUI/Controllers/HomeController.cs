using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTask.WebUI.Models;
using TestTask.Domain.Abstract;
using TestTask.Domain.Entities;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TestTask.WebUI.Controllers
{
    /// <summary>
    /// Main controller
    /// </summary>
    public class HomeController : Controller
    {
        // Interfaces
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IRegionRepository _regionRepository;

        /// <summary>
        /// Constructor for the controller
        /// </summary>
        /// <param name="cityRepo"> Interface for city repository </param>
        /// <param name="countryRepo"> Interface for country repository </param>
        /// <param name="regionRepo"> Interface for region repository </param>
        public HomeController(ICityRepository cityRepo, ICountryRepository countryRepo, IRegionRepository regionRepo)
        {
            _cityRepository = cityRepo;
            _countryRepository = countryRepo;
            _regionRepository = regionRepo;
        }
        /// <summary>
        /// Main page
        /// </summary>
        /// <returns> View of main page </returns>
        [Route("")]
        public IActionResult Index() => View();
        /// <summary>
        /// List of countries
        /// </summary>
        /// <returns> View with list of countries </returns>
        [Route("CountryList")]
        public IActionResult ShowAll()
        {
            var coutriesVM = new List<CountryViewModel>();
            foreach (var c in _countryRepository.GetCountries())
            {
                coutriesVM.Add(new CountryViewModel
                {
                    Country = c,
                    CapitalName = _cityRepository.GetCityById(c.CapitalId).Name,
                    RegionName = _regionRepository.GetRegionById(c.RegionId).Name
                });
            }
            return View(coutriesVM);
        }
        /// <summary>
        /// Page with panel for searching countries by name
        /// </summary>
        /// <returns> View of search panel </returns>
        [Route("Search")]
        public IActionResult SearchPanel() => View();
        /// <summary>
        /// Post version of page with panel for searching countries by name
        /// </summary>
        /// <param name="countryName"> Name of the country to search </param>
        /// <returns> 
        /// If a country exists in the database, returns information about it,
        /// otherwise returns a page with a failure message and a proposal to add a country.
        /// </returns>
        [Route("Search")]
        [HttpPost]
        public IActionResult SearchPanel(string countryName)
        {
            var country = _countryRepository.GetCountryByName(countryName);
            if (country == null)
                return View("NotFound");
            else
            {
                var coutryVM = new CountryViewModel
                {
                    Country = country,
                    CapitalName = _cityRepository.GetCityById(country.CapitalId).Name,
                    RegionName = _regionRepository.GetRegionById(country.RegionId).Name
                };
                return View("CountryInfo", coutryVM);
            }
        }
        /// <summary>
        /// Page with panel for searching countries by name via url with API
        /// </summary>
        /// <returns> View of search panel </returns>
        [Route("SearchAPI")]
        public IActionResult SearchPanelAPI() => View();
        /// <summary>
        /// Post version of page with panel for searching countries by name via url with API
        /// </summary>
        /// <param name="url"> url with country data API </param>
        /// <returns> 
        /// If a country exists in the database, returns information about it,
        /// otherwise returns a page with a failure message and a proposal to add a country.
        /// </returns>
        [Route("SearchAPI")]
        [HttpPost]
        public IActionResult SearchPanelAPI(string url)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    if (json != null)
                    {
                        var dataObj = JArray.Parse(json);
                        var country = _countryRepository.GetCountryByName($"{dataObj[0]["name"].Value<string>()}");
                        if (country == null)
                            return View("NotFoundAPI");
                        else
                        {
                            var coutryVM = new CountryViewModel
                            {
                                Country = country,
                                CapitalName = _cityRepository.GetCityById(country.CapitalId).Name,
                                RegionName = _regionRepository.GetRegionById(country.RegionId).Name
                            };
                            return View("CountryInfo", coutryVM);
                        }
                    }
                    else
                        return View("NotFoundAPI");
                };
            }
            catch
            {
                TempData["errorMessage"] = string.Format("Invalid link. Try again.");
                return View();
            }
        }
        /// <summary>
        /// Page with form for adding the country
        /// </summary>
        /// <returns> View of form for adding the country </returns>
        [Route("Add")]
        public IActionResult AddCountry() => View();
        /// <summary>
        /// Post version of page with form for adding the country.
        /// </summary>
        /// <param name="countryVM"> Country view model </param>
        /// <returns>
        /// If successful, adds or updates the country and redirects to the main page.
        /// In case of failure returns the same page in order to correct or
        /// supplement the data necessary to add the country.
        /// </returns>
        [Route("Add")]
        [HttpPost]
        public IActionResult AddCountry(CountryViewModel countryVM)
        {
            if (ModelState.IsValid)
            {
                City cityDB;
                Region regionDB;
                if (_cityRepository.CheckExistCity(countryVM.CapitalName) == "EXIST")
                    cityDB = _cityRepository.GetCityByName(countryVM.CapitalName);
                else
                {
                    _cityRepository.AddCity(new City { Name = countryVM.CapitalName });
                    cityDB = _cityRepository.GetCityByName(countryVM.CapitalName);
                }
                if (_regionRepository.CheckExistRegion(countryVM.RegionName) == "EXIST")
                    regionDB = _regionRepository.GetRegionByName(countryVM.RegionName);
                else
                {
                    _regionRepository.AddRegion(new Region { Name = countryVM.RegionName });
                    regionDB = _regionRepository.GetRegionByName(countryVM.RegionName);
                }
                if (_countryRepository.CheckExistCountry(countryVM.Country.CountryCode) == "NOT EXIST")
                {
                    _countryRepository.AddCountry(countryVM.Country, cityDB.Name, regionDB.Name);
                    TempData["successMessage"] = string.Format($"{countryVM.Country.Name}" +
                        " has been successfully added to the database.");
                    return RedirectToAction("Index");
                }
                else
                {
                    _countryRepository.UpdateCountry(countryVM.Country, cityDB.Name, regionDB.Name);
                    TempData["successMessage"] = string.Format($"{countryVM.Country.Name} has been successfully updated.");
                    return RedirectToAction("Index");
                }
            }
            else
                return View(countryVM);
        }
        /// <summary>
        /// Page with form for adding the country via API url
        /// </summary>
        /// <returns> View of panel for adding the country url API </returns>
        [Route("AddAPI")]
        public IActionResult AddCountryByAPI() => View();
        /// <summary>
        /// Post version of page with form for adding the country.
        /// </summary>
        /// <param name="url"> url with API </param>
        /// <returns>
        /// If successful, adds or updates the country and redirects to the main page.
        /// In case of failure returns the same page in order to correct or
        /// supplement the data necessary to add the country.
        /// </returns>
        [Route("AddAPI")]
        [HttpPost]
        public IActionResult AddCountryByAPI(string url)
        {
            try
            {
                using (var wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    if (json != null)
                    {
                        var dataObj = JArray.Parse(json);
                        City cityDB;
                        Region regionDB;
                        var capitalName = $"{dataObj[0]["capital"].Value<string>()}";
                        var regionName = $"{dataObj[0]["region"].Value<string>()}";
                        var countryCode = $"{dataObj[0]["alpha3Code"].Value<string>()}";
                        var countryName = $"{dataObj[0]["name"].Value<string>()}";
                        var countryPopulation = dataObj[0]["population"].Value<int>();
                        var countryArea = dataObj[0]["area"].Value<double>();
                        if (_cityRepository.CheckExistCity(capitalName) == "EXIST")
                            cityDB = _cityRepository.GetCityByName(capitalName);
                        else
                        {
                            _cityRepository.AddCity(new City { Name = capitalName });
                            cityDB = _cityRepository.GetCityByName(capitalName);
                        }
                        if (_regionRepository.CheckExistRegion(regionName) == "EXIST")
                            regionDB = _regionRepository.GetRegionByName(regionName);
                        else
                        {
                            _regionRepository.AddRegion(new Region { Name = regionName });
                            regionDB = _regionRepository.GetRegionByName(regionName);
                        }
                        if (_countryRepository.CheckExistCountry(countryCode) == "NOT EXIST")
                        {
                            _countryRepository.AddCountry(new Country
                            {
                                Name = countryName,
                                CountryCode = countryCode,
                                Area = countryArea,
                                Population = countryPopulation
                            },
                            cityDB.Name,
                            regionDB.Name);
                            TempData["successMessage"] = string.Format($"{countryName}" +
                                " has been successfully added to the database.");
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            _countryRepository.UpdateCountry(new Country
                            {
                                Name = countryName,
                                CountryCode = countryCode,
                                Area = countryArea,
                                Population = countryPopulation
                            },
                            cityDB.Name,
                            regionDB.Name);
                            TempData["successMessage"] = string.Format($"{countryName} has been successfully updated.");
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        TempData["errorMessage"] = string.Format("Invalid link. Try again.");
                        return View();
                    }
                };
            }
            catch
            {
                TempData["errorMessage"] = string.Format("Invalid link. Try again.");
                return View();
            }
        }
        /// <summary>
        /// Error handler
        /// </summary>
        /// <returns> Error view</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}