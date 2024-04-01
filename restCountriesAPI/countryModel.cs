using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restCountriesAPI
{
    using System;
    using System.Collections.Generic;

    public class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
        public NativeName NativeName { get; set; }
    }

    public class NativeName
    {
        public Ara Ara { get; set; }
    }

    public class Ara
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }






    public class Maps
    {
        public string GoogleMaps { get; set; }
        public string OpenStreetMaps { get; set; }
    }


    public class Country
    {
        public Name Name { get; set; }
        public List<string> Tld { get; set; }
        public string Cca2 { get; set; }
        public string Ccn3 { get; set; }
        public string Cca3 { get; set; }
        public string Cioc { get; set; }
        public bool Independent { get; set; }
        public string Status { get; set; }
        public bool UnMember { get; set; }

        public List<string> Capital { get; set; }
        public List<string> AltSpellings { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }

        public List<double> Latlng { get; set; }
        public bool Landlocked { get; set; }
        public List<string> Borders { get; set; }
        public double Area { get; set; }

        public string Flag { get; set; }
        public Maps Maps { get; set; }
        public int Population { get; set; }
        public string Fifa { get; set; }

        public List<string> Timezones { get; set; }
        public List<string> Continents { get; set; }
        public List<string> Flags { get; set; }
    }

    public class RootObject
    {
        public List<Country> Countries { get; set; }
    }

}
