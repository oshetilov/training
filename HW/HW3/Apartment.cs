using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    public class Apartment
    {
        public Apartment(int id, string name, string zipCode, string smartLocation, string country, float latitude, float longitude)
        {
            Id = id;
            Name = name;
            ZipCode = zipCode;
            SmartLocation = smartLocation;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ZipCode { get; private set; }
        public string SmartLocation { get; private set; }
        public string Country { get; private set; }
        public float Latitude { get; private set; }
        public float Longitude { get; private set; }

        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType() && this.GetHashCode() == obj.GetHashCode())
            {
                var apartment = (Apartment)obj;

                return
                    Id == apartment.Id &&
                    Name == apartment.Name &&
                    ZipCode  == apartment.ZipCode &&
                    SmartLocation == apartment.SmartLocation &&
                    Country   == apartment.Country &&
                    Latitude  == apartment.Latitude &&
                    Longitude == apartment.Longitude;   
            }
            return false;
        }

        public override int GetHashCode()
        {
          return 
              Id.GetHashCode() ^
              Name.GetHashCode() ^
              ZipCode.GetHashCode() ^
              SmartLocation.GetHashCode() ^
              Country.GetHashCode() ^
              Latitude.GetHashCode() ^
              Longitude.GetHashCode();
        }
    }
}