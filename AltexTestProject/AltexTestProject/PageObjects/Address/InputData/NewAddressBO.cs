using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltexTestProject.PageObjects.Address.InputData
{
    public class NewAddressBO
    {
        public string FirstName { get; set; } = "Test Name";
        public string LastName { get; set; } = "Test Name";
        public string Street { get; set; } = "Strada Test Nr Test";
        public string Telephone { get; set; } = "0231563245";
        public int CustomerType { get; set; } = 1;
    }
}
