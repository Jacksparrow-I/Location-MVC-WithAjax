using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Location.Models
{
    public class Locations
    {
        //public int CountryId { get; set; }
        public string CountryName { get; set; }
       //public int StateId { get; set; }
        public string StateName { get; set; }
        //public int CityId { get; set; }
        public string CityName { get; set; }
    }

    public class StateLocations
    {
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
    }

    public class Locationssave
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        //public int CityId { get; set; }
        public string CityName { get; set; }

        public static implicit operator List<object>(Locationssave v)
        {
            throw new NotImplementedException();
        }
    }
}