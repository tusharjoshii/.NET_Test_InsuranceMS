using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Entities
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public string PolicyType { get; set; }
        public decimal CoverageAmount { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Default constructor
        public Policy() { }

        // Parameterized constructor
        public Policy(int policyId, string policyNumber, string policyType, double coverageAmount, double premiumAmount, DateTime startDate, DateTime endDate)
        {
            PolicyId = policyId;
            PolicyNumber = policyNumber;
            PolicyType = policyType;
            CoverageAmount = (decimal)coverageAmount;
            PremiumAmount = (decimal)premiumAmount;
            StartDate = startDate;
            EndDate = endDate;
        }

        // ToString method
        public override string ToString()
        {
            return $"Policy ID: {PolicyId}, Policy Number: {PolicyNumber}, Policy Type: {PolicyType}, Coverage Amount: {CoverageAmount}, Premium Amount: {PremiumAmount}, Start Date: {StartDate}, End Date: {EndDate}";
        }
    }

}
