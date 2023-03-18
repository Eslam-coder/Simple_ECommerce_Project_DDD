using _0___SharedKernel.Domain.ValueObject;
using System.ComponentModel;

namespace _1___Domain.Authentication.Entities
{
    public class Address : ValueObject
    {
        public string City { get; private set; }

        public string Country { get; private set; }
        
        public string ZipCode { get; private set; }
        
        public string Address1 { get; private set; }
        
        public string Address2 { get; private set; }

        [DisplayName("Phone")]
        public string PhoneNumber { get; private set; }

        public string Fax { get; private set; }

        private Address()
        {
        }

        public Address(string city, string country, string zipCode, string address1, string address2, string phoneNumber, string fax)
        {
            City = city;
            Country = country;
            ZipCode = zipCode;
            Address1 = address1;
            Address2 = address2;
            PhoneNumber = phoneNumber;
            Fax = fax;
        }

        protected override IEnumerable<object> GetValues()
        {
            yield return Country; 
            yield return City; 
            yield return ZipCode; 
            yield return Address1; 
            yield return Address2; 
            yield return PhoneNumber;
            yield return Fax;
        }
    }
}
