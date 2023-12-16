using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ContactInfo { get; set; }
        public Policy Policy { get; set; }

        // Default constructor
        public Client() { }

        // Parameterized constructor
        public Client(int clientId, string clientName, string contactInfo, Policy policy)
        {
            ClientId = clientId;
            ClientName = clientName;
            ContactInfo = contactInfo;
            Policy = policy;
        }

        // ToString method
        public override string ToString()
        {
            return $"Client ID: {ClientId}, Client Name: {ClientName}, Contact Info: {ContactInfo}";
        }
    }
}
